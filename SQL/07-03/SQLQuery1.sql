/*
	STORED PROCEDURE
	
	*saklı yöntem yordam anlamında kullanılır
	*belirli bir işi, görevi yerine getirmek için yazılmış bir veya daha fazla sorguyu birleştiren kod parçalarıdır.
	kısaca: derlenmiş sql cümleleridir diyebiliriz
	*normal her sorgu yazılıp okunduğunda önce derlenir sonra çalışır. ancak sp'ler zaten kayılı sorgular olduğundan
	execution plan'ları zaten bir kez hazırlanmıştır ve doğrudan çalışır. o yüzden kayıtlı sql cümleleridir denir.
	* bu yüzden normal sorgualardan daha hızlı çalışır.
	* veritabanı nesneleri olduğundan ddl üzerinden işlem yapılır ve ayrıca içinde de dml ile işlemler yaptırılır.
	* isterse geriye değern dönebilir.
	* subquery içinde kullanılmazlar. kendilerine başlıbaşına iş yapar.
	* güvenliği yüksektir.
	* birbirleri içinde çağrılabilir
	** İÇİNDE TRANSACTION KULLANILABİLİR(fonksiyonlarda kullanılamaz)
	* parametreleri opsiyoneldir
	* out parametresi var
syntax: create procedure/proc isim
as
çağrı: execute/exe isim


*/

-- soru: ürün güncelleyebilen sp yazınız ürünad,kategori id, fiyat bilgiler alsın

create procedure Updateproduct @urunAd nvarchar(100), @kategoriId int , @fiyat money, @urunıd int
as
update products set ProductName = @urunAd, CategoryID = @kategoriId, UnitPrice=@fiyat
where ProductID = @urunıd

exec Updateproduct 'Elmalar', 4, 200, 78



-- yeni bir ürünm ekleyelim, kategorisi ile beraber, ancak bende böyle bir kategori varsa eklesin ürünü yoksa eklemesin

alter procedure AddProduct5 @name nvarchar(100), @discontinued bit, @kategoriId int
as
declare @isNullvalue nvarchar(100)

	select @isNullvalue = CategoryID from Categories where CategoryID=@kategoriId
	--IF @kategoriId < 0 or @kategoriId > 8 
	
	IF @isNullvalue is null
	begin
		PRINT N'eklenemedi.'
		return
		end
	ELSE
	begin
		insert into Products (ProductName, Discontinued, CategoryID) values (@name, @discontinued, @kategoriId)
		end


exec AddProduct4 'zeytin2', 0, 5

create procedure YeniUrunEkle(@name nvarchar(100), @discontinued bit, @kategoriId int)
as
if exists(select 1 from Categories where CategoryID=@kategoriId)
insert Products (ProductName, Discontinued,CategoryID) values (@name, @discontinued, @kategoriId)
else print 'urun eklenemedi'


exec YeniUrunEkle 'mercimek', 486, 5
exec YeniUrunEkle 'mercimek', 486, 15

alter procedure YeniUrunEkle(@name nvarchar(100), @discontinued bit, @CategoryName nvarchar(100))
as
	declare @categoryId int

	if not exists(select 1 from Categories where CategoryName=@CategoryName)
		insert Categories(CategoryName) values (@CategoryName)
	select @categoryId = CategoryID from Categories where CategoryName=@CategoryName
	insert Products (ProductName, Discontinued, CategoryID) values (@name, @discontinued, @categoryId)
		

exec YeniUrunEkle 'mercimek', 486, 5
exec YeniUrunEkle 'mercimek', 486, 'Condiments'



-- yeni bir kargo firması ekleyerek eklenen kargo firmasının id bilgisini out ile dışarı çıkartınız
CREATE PROC KARGOFIRMAEKLE(@FIRMAAD NVARCHAR(40), @FIRMAID INT OUT)
AS
INSERT SHIPPERS (COMPANYNAME) VALUES (@FIRMAAD)

-- SET LAST ID
SET @FIRMAID = @@IDENTITY
SET @FIRMAID = SCOPE_IDENTITY()

DECLARE @KARGOFIRMAID INT

EXEC KARGOFIRMAEKLE 'ARAS KARGO', @FIRMAID = @KARGOFIRMAID OUTPUT

SELECT @KARGOFIRMAID


-- MAKSİMUM 10 KARAKTERLİK BİR PARAMETRE ALAN VE İSMİNDE BU İFADE GEÇEN TÜM ÇALIŞANLARIMIN AD VE SOYAD BİLGİSİNİ GETİREN SP YAZ


CREATE PROCEDURE GET_PERSONAL_DATA
@STR NVARCHAR(10)
AS
--IF LEN(@STR) > 10
--	RETURN
SELECT FIRSTNAME, LASTNAME FROM EMPLOYEES WHERE FIRSTNAME LIKE '%' + @STR + '%'

EXEC GET_PERSONAL_DATA 'NA'

-- customers tablosuna ekleme yapalım, yeni bir müşteri ekleyelim ancak içerde ABC isminde bir firma varsa ben abc ya da 
-- yada ABc ekleyemeyeyim.

alter procedure ADD_CUSTOMER

@customer_name nvarchar(40),
@cutomer_id nvarchar(40)

as
declare @name nvarchar(40)
select @name= CompanyName from Customers where CustomerID=@cutomer_id
if lower(@name) = lower(@customer_name)
	begin
	print 'icerde aynı isimda başla bir firma var'
	return
	end
insert Customers(CustomerID,CompanyName) values (@cutomer_id, @customer_name)

exec ADD_CUSTOMER 'aaa',123


create proc ciroHesapla
@yil int
as
select sum(Quantity * od.UnitPrice * (1-Discount))from Orders o join [Order Details] od on o.OrderID=od.OrderID
where year(OrderDate)=@yil

exec ciroHesapla 1997



/*

-- yeni bir sipariş geldiğinden ilgili ürünün kendi stoğunu azaltalım ancak ürün yoksa ürünün kendi 
-- stoğu negatif olduysa yaptığımız işlemleri geri alarak hiçbirşey yapmamış olalım. (order eklememiş olalım mesela)

-- ardışık yapılan işlenmlerde bir hata meysana geldiğinde yapılan tüm işlemleri almamız yada işlemleri tamamlamamızı sağlayan

	TRANSACTION yapısı mevcuttur. c# tarafında benzer işi transactionscope yapacak. 
	buradaki transaction içindeki commit: işlem başarılı derken, 
	roolback: hata oluştu yaptıklarımızı geri al der. 

	transaction yapısı genellikle try cath yapısıyla desteklenir ki bilinmeyen x sebepten hata 
	alırsam da işlem havada kalması ve geri alınsın.

*/
-- product stok - alınmak istenen stok, müşteri var mı, calisan id var mı

ALTER PROC SIPRAISOLUSTUR
	@URUNID INT,
	@SIPARISADET INT,
	@CALISANIID INT,
	@MUSTERIID NVARCHAR(5)
AS
BEGIN TRANSACTION
	BEGIN TRY
		DECLARE @ORDERID INT
		DECLARE @GUNCELSTOK INT
		INSERT ORDERS (EMPLOYEEID, CUSTOMERID, SHIPCITY) VALUES (@CALISANIID, @MUSTERIID, 'ANKARA')	
		SET @ORDERID = @@IDENTITY

		-- MÜŞTERI VAR MI
		IF NOT EXISTS(SELECT 1 FROM CUSTOMERS WHERE CUSTOMERID=@MUSTERIID)
			BEGIN
				PRINT 'BÖYLE BIR MÜŞTERI YOK'
				ROLLBACK
				RETURN
			END

		-- CALISAN VA MI
		IF NOT EXISTS(SELECT 1 FROM EMPLOYEES WHERE EMPLOYEEID=@CALISANIID)
			BEGIN
				PRINT 'BÖYLE BIR CALISAN YOK'
				ROLLBACK
				RETURN
			END


		-- ÜRÜN VAR MI?
		IF NOT EXISTS(SELECT 1 FROM PRODUCTS WHERE PRODUCTID=@URUNID)
			BEGIN
				PRINT 'BÖYLE BIR ÜRÜN OLMADIĞINDAN SIPARIŞINIZ IPTAL EDILDI'
				ROLLBACK
				RETURN
			END

		SELECT @GUNCELSTOK=UNITSINSTOCK FROM PRODUCTS WHERE PRODUCTID=@URUNID

		-- YETERSIZ STOK
		IF @GUNCELSTOK < @SIPARISADET
			BEGIN
				PRINT 'YETERSIZ STOK'
				ROLLBACK
				RETURN
			END


		INSERT INTO [ORDER DETAILS](PRODUCTID, QUANTITY, UNITPRICE, ORDERID,DISCOUNT) 
		VALUES(@URUNID, @SIPARISADET,200,@ORDERID,0)

		--ÜRÜN STOK AZALTALIM
		UPDATE PRODUCTS SET UNITSINSTOCK=UNITSINSTOCK - @SIPARISADET WHERE PRODUCTID=@URUNID
		
		SELECT @GUNCELSTOK=UNITSINSTOCK FROM PRODUCTS WHERE PRODUCTID=@URUNID

		IF @GUNCELSTOK> 0
			BEGIN
				PRINT 'STOK MÜKTARIMIZ YETERLI OLMADIĞINDAN SIPARIŞIIĞZ IPTAL EDILDI.'
				ROLLBACK
				RETURN
			END

		PRINT 'SIPARIŞINIZ ALINMIŞTIR, TEŞEKKÜR EDERIZ'
		COMMIT --TRANSACTION TAMAMLANDI
	END TRY

	BEGIN CATCH
		PRINT 'HATA OLUSTU, TÜM IŞLEMLER IPTAL EDILI'
		ROLLBACK
		RETURN
	END CATCH

---------------------------------------------
/*
	view

	bir veya birden fazla tablodan seçili alanları sanal tablo gibi görüntülenmesini sağlar.
	amacımız: karmaşık sorguları birleştirmek, veriyi tekrar tekrar kullanılabilir hale getirmek,
	sorgu tekrarını önlemeki yetkili/yetkisiz kişilere kaynakları açık açık paylaşmadan
	bilgi vermek...

	view'larda birer database nesnesidir. DDL komutları onlar üzerinde de çalışır.

	tek tablo üzerinde insert, update, delete yapılabilir ancak daha fazlasını yapamazlar.

	dışarıdan parametre alamazlar

	özellikle raporlama ve güvenlik için kullanılır

	no column name bırakılmamalıdır

*/

--od tablosundaki kolonları ve her satırdaki toplam tutarı gösteriniz.

alter view order_details_view as
select OrderID, ProductID, UnitPrice, Quantity, Discount, (UnitPrice * Quantity *(1-Discount)) as 'Toplam tutar' from [Order Details]

select * from order_details_view

-- ürün adı, kategori adı, tedarikçi adı

create view vw_productData as

select p.ProductName, c.CategoryName, s.CompanyName from Products p join Suppliers s on p.SupplierID=p.SupplierID
						join Categories c on c.CategoryID = p.CategoryID

select * from vw_productData
-- yıllara göre her yılınm ilk 3 ayında ne kadar kazandığımı bulan view

create view kazanUcAy as
select 
	year(OrderDate) [Yil] , sum(Quantity * UnitPrice * (1-Discount)) [Ilk 3 aylik gelir]
from 
	Orders o join [Order Details] od on o.OrderID=od.OrderID
where MONTH(OrderDate) in (1,2,3)
group by year(OrderDate)

select * from kazanUcAy

/*
	TRIGGER

	triggerlar otomatik olarak çalışan sp lerdir
	otomatik tetiklenirler bizim tarafımızdan değil
	bir tablo üzerinde insert update delete yaptığımızda devreye girmesini istediğimiz işlemleri triggerlara yazarız

	veritabanı nesnesidir ddl kopmutları ile oluşur

	otomatik işlemlerde bize yardımcı olmak amacıyla inserted ve deleted adında iki sanal tablo bulunur, 
	eklenen ve silinenleri buradabn takip ederiz
	updated yoktur, gerek de yoktur

	3 çesş,it triggerdan bahsedebiliriz

	dml trigger - insert update delete
	ddl trigger - create alter drop
	LOGON trigger

	DML triggerlar : after (for) ve instead of olmak üzere ikiye ayrılır


*/

-- çalışan tablosuna yeni bir çalışan eklendikten sonra sgk ya bildirdiniz mi yazalım
alter trigger trg_calisanEkle
on Employees
after insert
as
begin
	print 'Çalışanınızı SGK ya bildirdiniz mi?'
end

insert Employees (FirstName, LastName) values ('yasin', 'maden')


create trigger trg_stokMiktariniAzalt
on [order details]
after insert
as
begin
	declare @satilan_urun_id int
	declare @satilan_adet int

	select @satilan_urun_id = ProductID, @satilan_adet=Quantity from inserted
	update Products set UnitsInStock -= @satilan_adet where ProductID = @satilan_urun_id
end

select * from [Order Details]	
insert into [Order Details] values (10248, 1, 10, 2,0)
select * from Products
select * from inserted


-- order details tablosunda yapılan güncelleme sonucunda productın stok bilgisini güncelleyiniz.

create trigger trg_odinsert
on [order details]
after insert
as
begin
	declare @satilan_urun_id int
	declare @satilan_adet int

	select @satilan_urun_id = ProductID, @satilan_adet=Quantity from inserted
	update Products set UnitsInStock -= @satilan_adet where ProductID = @satilan_urun_id
end


create trigger trg_oddelete
on [order details]
after delete
as
begin
	declare @silinen_urun_id int
	declare @silinen_adet int

	select @silinen_urun_id = ProductID, @silinen_adet=Quantity from deleted
	update Products set UnitsInStock += @silinen_adet where ProductID = @silinen_urun_id
end

create trigger karisik
on [order details]
after UPDATE, INSERT, DELETE
as
if exists(SELECT * from inserted) and exists (SELECT * from deleted)
	print 'update'
If exists (Select * from inserted) and not exists(Select * from deleted)
	print 'insert'
If exists(select * from deleted) and not exists(Select * from inserted)
	print 'delete'


insert into [Order Details] values (10249, 1, 10, 2,0)
delete from [Order Details] where OrderID=10249 and ProductID=1 and UnitPrice=10 and Quantity = 2 and Discount=1
update [Order Details] set Discount=1 where OrderID=10249 and ProductID=1 and UnitPrice=10 and Quantity = 2 and Discount=0

-----------------------------------------------------

