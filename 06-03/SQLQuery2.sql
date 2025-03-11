/* self join : bir tablonun kendisiyle join işlemine tabi tutulmasıdır. 
hiyerarşik verileri sorgulamak ya da aynı tablodaki satırları sorgulamak için kullanılır.
karışıklık olmaması için tablolara alias takma ad verilmelidir.


*/ 
--soru: tüm çalışanlarım ve varsa yöneticilerini getiriniz.

select e1.FirstName+' '+e1.LastName calisanAd, e2.FirstName+' '+e2.LastName yonetici
from Employees e1 left join Employees e2 on e1.ReportsTo=e2.EmployeeID
order by calisanAd



--soru: aynı kategorideki ürünlerimi getiriniz.
select p1.ProductID as u1, p2.ProductID as u2, p1.CategoryID
from Products p1 join Products p2 on p1.CategoryID=p2.CategoryID



-------------------------------------------------------
--- SORGULARIN BİRLEŞTİRİLMESİ
/*
UNION		:iki vr daha fazla select sorgusunun sonuclarını birleştirir. duplicate olanları göstermez.
	birleşen sorgu sonuçlarının tipi,adeti aynı olmalıdır.

UNION ALL	: yine iki veya daha fazla sorgu sonucunu birleştirir. ancak tekrarlı veriyi de gösyerir.

*/

select city from customers
union
select city from Suppliers


select city from customers
union all
select city from Suppliers

-- aynı ülkedeki müşteri ve tedarikçilerin ad ve ülkelerini birleştirelim.


select Country from Suppliers
union
select Country from Customers

select CompanyName ,country from Customers where country = 'brazil'
union 
select CompanyName ,country from Suppliers where country = 'brazil'

select CompanyName ,country from Customers where country = 'brazil'
union all 
select CompanyName ,country from Suppliers where country = 'brazil'


--soru: ürünle tablosunda olup satışı olmayan satılmayan ürünler

select ProductID from Products
except
select ProductID from [Order Details]

insert Products(ProductName,Discontinued) values('patates',0)

-- intersect kesişim


select UnitPrice, ProductID from Products
intersect
select UnitPrice, ProductID from [Order Details]


/*
	TARİHSEL FONKSİYONLAR

	DATEPART() : BİR TARİH BİLGİSİNDEN İSTEDİĞİMİZ KISMI ALIRIZ
	DATEDIFF(X,Y,Z) : İKİ TARİH ARASINDA İSTENEN TİPTEN BİR FARK ALIR.

*/

select FirstName,LastName, DATEPART(YYYY,BirthDate) from Employees

select FirstName,LastName, DATEDIFF(YEAR,BirthDate,GETDATE()) AS yas from Employees

select FirstName,LastName, DATEDIFF(DAY,BirthDate,GETDATE()) AS gunSayisi from Employees

select FirstName,LastName, DATEDIFF(DAY,BirthDate,HireDate) AS [ise giris yasi] from Employees


/*
	STRING FONSKİYONLARI
	ASCII()
	LOWER()
	UPPER()
	LEFT()
	RIGHT()
	CHAR()
	LEN()
	REPLACE()
	SUBSTRING()
	CAST()
*/

SELECT LEFT('MERHABA',3) as [soldan karakter al]
SELECT RIGHT('MERHABA',3) as [SAĞDAN karakter al]
SELECT ASCII('S') [CHAR TO ASCII]
SELECT CHAR(83) [ASCII TO CHAR]
SELECT LEN('YASİN MDEN') AS [KARAKTER SAYISI]
SELECT REPLACE('BİR BİR BİRBİRLERİNE', 'BİR', 'İKİ')
SELECT SUBSTRING('GAZİ ANTEP',2,5)


SELECT 1/3
SELECT 1/3.0
SELECT CAST(1 AS FLOAT)/3

----------------------------------------------------------------------

/*
	FUNCTIONS
	
	-TEMELDE 4 TİP FONSKSİYONDAN BAHSEDEBİLİRİZ
	1- SCALAR VALUED FUNC.
	2- TABLE VALUE FUNC.
	3- AGGREGATE FUNC.
	4- SYSTEM FUNC.

UDF yani UserDefine fonnksiyonlar ibizm tarafımızdan tanımlanan fonk. ve scalar / table value olabilir.
Fonsksiyonlar alışkın olduğumuz bildiğimiz mantıkta hesaplamalar ve bazı işlemlerde kullancağımız yapılar olacaktır

return / returns ile geriye değer döner
parametre alabilir 
fonksiyonlar birer database nesnesi olduğundan DDL komutları onlar için de geçerlidir.
Subquery'ler içinde kullanılabilirler.
table value fonk sadece select ile kullanılacaktır.
*/

-- soru: aldığı tutar ve vergi oranı ile, ödenmesi gereken vergili tutarı dönen fonksiyon yazalım.

create function VergiliTutarHesapla(@AnaPara money, @Oran float)
returns money

as begin
return @AnaPara*(1 + @Oran / 100)
end 

select dbo.VergiliTutarHesapla(200,25) as [Vergili Tutar]


select 
	ProductName,
	UnitPrice,
	dbo.VergiliTutarHesapla(UnitPrice,13) as [Vergili Tutar] from Products


create function YasHesapla2(@DogumTarihi datetime)
returns int
as
begin

return Datediff(year,@DogumTarihi, getdate())
end

select dbo.YasHesapla('07.07.2001')


------------------------------------------------------

-- alınan ad soyad param göre ad.soayd@gmail.com


create function CreateMail(@Ad nvarchar(50),@Soyad nvarchar(50))
returns nvarchar(100)

as
begin
return @Ad+'.'+@Soyad+'@gmail.com'
end

select dbo.CreateMail('yasin','maden')

-----------------------------
--alınan product id bilgisine gör eilgili ürünün stok miktaı 0 ise 0-yok 1-10 az 10+ stok var

create function StokKontrol(@Id int)
returns nvarchar(100)
as
begin
	declare @ret nvarchar(100)
	select @ret = UnitsInStock from Products p where p.ProductID=@Id
	if(@ret is null)
		set @ret ='yok'
	else if (CONVERT(int, @ret) = 0)
		set @ret ='yok'
	else if (CONVERT(int, @ret) <= 10)
		set @ret ='stok az'
	else
		set @ret ='stok var'
	return @ret
end

create function StokKontrol4(@Id int)
returns nvarchar(100)
as
begin
	declare @result int
	select @result = UnitsInStock from Products p where p.ProductID=@Id
	if(@result is null or @result = 0)
		return 'yok'
	else if (@result  <= 10)
		return 'stok az'
	
return 'stok var'
	
end



select UnitsInStock ,[dbo].[StokKontrol4](ProductID) from Products

-----------------------------------------------
-- çalışan isimlerinde dışarıdan girilen harf ile başlayan çalışanların tüm bilgilerini getirecek fonskyion


create function ilkHarf2(@harf char)
returns table
as
return 
	select * from Employees where FirstName like @harf+'%'


select *  from dbo.ilkHarf2('a')


----- kategori id bilgisi alan ve bu kategoriden kaç adet ürün satıldığı bilgisini dönen func

create function SatisBilgi(@id int)
returns int

as
begin
	declare @result int
	select @result = count(p.CategoryID)
					from 
						[Order Details] od join Products p on od.ProductID=p.ProductID
											join Categories c on c.CategoryID = p.CategoryID
					GROUP BY p.CategoryID
					having p.CategoryID = @id
	return @result
end


select dbo.SatisBilgi2(3)

------------------

create function SatisBilgi2(@id int)
returns int

as
begin
	declare @result int

	select @result = 
		sum(od.Quantity)
	from 
			[Order Details] od	join Products p on od.ProductID=p.ProductID
								join Categories c on c.CategoryID = p.CategoryID
	GROUP BY p.CategoryID
	having p.CategoryID = @id

	return @result
end

----------------------
select 
	count(p.CategoryID), p.CategoryID
from 
	[Order Details] od join Products p on od.ProductID=p.ProductID
						join Categories c on c.CategoryID = p.CategoryID
GROUP BY p.CategoryID
having p.CategoryID = 2


----------------------------------------------
-- alınan 2 tarih arasındaki geciken siparişlerin tüm bilgilerini getir.

create function GecikenSiparisler2(@d1 date, @d2 date)
returns table
as
return select * from Orders where ShippedDate > RequiredDate and (RequiredDate > @d1 and RequiredDate < @d2)

select * from GecikenSiparisler2('07.07.1990','07.07.2024')

-- alınan şehir bilgisine göre o şehirli müşterilerin bana ne kadar kazandırdıklarını bulan fonk.

create function SehirKazanc(@sehir nvarchar(100))
returns table
as
return select 
			sum(Quantity * UnitPrice *(1-Discount)) as [Toplam Kazanc]
		from Customers c	join Orders o on c.CustomerID = o.CustomerID
							join [Order Details] od on od.OrderID=o.OrderID
							where c.city = @sehir
							group by c.CustomerID

select * from dbo.SehirKazanc('barcelona')

-- orderid -> hangi kargo

create function getShipper(@order_id int)
returns nvarchar(100)
as
begin
	declare @res nvarchar(100)
	select @res =
		s.CompanyName
	from 
		Orders o	join Shippers s on o.ShipVia=s.ShipperID
	where o.OrderID = @order_id


return @res
end

select dbo.getShipper(OrderID) from orders

--
select 
		CompanyName
	from 
		Orders o	join Shippers s on o.ShipVia=s.ShipperID
	where o.OrderID = 10248

	---------------------
	-- müşteri 

create function MusteriTuru3(@musteri_id nvarchar(1000), @tutar money)
returns nvarchar(100)
as
begin
	declare @res int
	select @res = sum(Freight) from Customers c join Orders o on c.CustomerID=o.CustomerID
	where o.CustomerID = @musteri_id
	group by o.CustomerID

	if @res > @tutar
		return 'altın musteri'
	return 'normal musteri'

end

select dbo.MusteriTuru3(CustomerID, 1000.0) from Customers

-- SORU: alınan OrderId bilgisine göre o OrderId içinde kaç kalem ürün olduğunu ve ne kadar tuttuğunu bulan fonk.
-- SORU: müşretirinin adını alarak 1. ve 3. harflerini büyük harfe çeviren 
-- + city bilgisinin ilk iki harfini küçültüp ekleyen
-- + iletişimde bulunduğum kişinin ismini ters çeviren ve o tabloya özel bir barkod oluşturup dönen bir fonk yazınız

-- sp, view, trigger, index