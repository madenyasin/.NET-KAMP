-- tüm çalışanlar

select	*
from	Employees


select EmployeeID, FirstName, LastName, BirthDate
from	Employees


-- isimlendirme

SELECT EMPLOYEEID AS [PERSONEL NUMARASI], FIRSTNAME AS 'AD', LASTNAME AS 'SOYAD', BIRTHDATE AS [DUGUM TARIHI]
FROM	EMPLOYEES


SELECT EMPLOYEEID [PERSONEL NUMARASI], FIRSTNAME 'AD', LASTNAME 'SOYAD', BIRTHDATE [DUGUM TARIHI]
FROM	EMPLOYEES

SELECT ISIM = FIRSTNAME, SOYISIM=LASTNAME FROM EMPLOYEES


SELECT 5+6 'TOPLAM'


-- title+ title of coursty + isim + soyisim

select Title+' '+TitleOfCourtesy+space(2)+FirstName+SPACE(2)+LastName as Ünvan
from Employees


-- tekil kayıtları listelemek

select	distinct Country
from	Customers


-- distinct

-- birim fiyat bilgisi 300dep;'den fazla olan ürünlerin ad soyad fiyat bilgisini getir.

select ProductID, ProductName, UnitPrice
from Products
where UnitPrice > 150




select CategoryID, CategoryName
from Categories
where CategoryName = 'beverages'


select FirstName, LastName, Country
from Employees
where Country = 'USA' AND (TitleOfCourtesy = 'ms.' or TitleOfCourtesy = 'mrs.')

select * from
Employees
where ReportsTo = (select EmployeeID from Employees where FirstName = 'andrew')


select * from Employees
where Region is null

-- BETWEEN : arasında kalmak iki ismin, tarihin, sayının

select * 
from Employees
where BirthDate BETWEEN '01-01-1950' AND '01-01-1961'


select * 
from Employees
where YEAR(BirthDate) between 1950 and 1961

select * 
from Employees
where FirstName BETWEEN 'andrew' AND 'janet'
-- not: between sınırları da dahil eder. yanı geitirir.


--- IN: içinde olmak. sunulan seçeneklerden biriyse

select * from Employees where YEAR(BirthDate) IN (1955, 1960)

select * from Employees where TitleOfCourtesy IN ('dr.', 'mr.')

--- TOP: en tepedeki x adet

select top 3 * from categories

--- LIKE

select * from Customers where CompanyName like '%a'


select * from Customers where CompanyName like '%s%'

select * from Customers where CompanyName like '%[rt]%'

select * from Customers where CompanyName like '[a-k]%'


select * from Customers where CompanyName like '__a%'
-------------------------------------------------------------

--- SIRALAMA İŞLEMLERİ : ORDERBY
-- defaultta asc (ascending) olarak az -> çok'a sıralanır. dec (descending) çoktan aza sıralar.


select FirstName, LastName from Employees order by FirstName

select * from Products 
where UnitPrice between 20 and 50 
order by UnitsInStock desc

INSERT INTO Employees (LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country)
VALUES ('Yılmaz', 'Ahmet', 'Satış Temsilcisi', 'Bay', '1990-05-15 00:00:00', '2023-08-01 00:00:00', 'Merkez Mah. Cadde 1', 'İstanbul', NULL, '34000', 'Türkiye');

INSERT INTO Employees (LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country)
VALUES ('Demir', 'Ahmet', 'Pazarlama Uzmanı', 'Bay', '1992-10-20 00:00:00', '2023-08-05 00:00:00', 'Sahil Yolu Sokak 2', 'İstanbul', NULL, '34100', 'Türkiye');

INSERT INTO Employees (LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country)
VALUES ('Çelik', 'Ahmet', 'Yazılım Geliştirici', 'Bay', '1995-03-01 00:00:00', '2023-08-10 00:00:00', 'Bağlarbaşı Bulvarı No:3', 'İstanbul', NULL, '34200', 'Türkiye');

INSERT INTO Employees (LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country)
VALUES ('Kaya', 'Ahmet', 'Veri Analisti', 'Bay', '1998-12-25 00:00:00', '2023-08-15 00:00:00', 'Tepeüstü Mevkii Sokak 4 Daire 5', 'İstanbul', NULL, '34300', 'Türkiye');

select * from Employees
order by FirstName asc, LastName desc 

-- kolon sırasına göre sıralayabiliriz. lastname göre 
select firstName, LastName from Employees
order by 1 asc, 2 desc 


SELECT TOP 3 
FIRSTNAME + SPACE(1)+ LASTNAME +SPACE(1)+ CONVERT(NVARCHAR(90) , DATEDIFF(YEAR, BIRTHDATE, GETDATE())) + ' - ' AS FORMATLIAD
FROM EMPLOYEES
ORDER BY BIRTHDATE 

--- AGGREGATE FUNCTIONS (TOPLAM TOPLAMALI FONSKSİYONLAR) :		COUNT	AVG	SUM	MİN	MAX

/*
count(*,kolon adı): * ifadesiilgili gruptaki herklesi sayar, kolonadı kullanılırsa o kolonun altındaki DOLU satırları sayar. 
tercihen not null veya primary key olan kolono seçeriz.

*/

--kaç adet ürünüm var
select count(*) as SatirSayisi from products

select count(ProductID) as SatirSayisi from products

select count(QuantityPerUnit) as SatirSayisi from products


--- AVG(kolonadı) : ilgili kolonun ortalamasını alır. FAKAT kolon metinsel ya da tarşhsel bir tip ise işlem yapamaz hata verir.

select avg(year(GETDATE()) - year(BirthDate))
from Employees


select sum(UnitsInStock) 'TOPLAM STOK ADETİ'
from Products

select sum(Freight) 'TOPLAM KARGO ÜCRETİ'
from Orders

---------------------------------------------
/*
GROUP BY: gruplama işlemleri için kullanılır.
*/

select Country, count(*) [MUSTERI SAYISI]
from Customers
group by Country
order by [MUSTERI SAYISI] desc

SELECT CategoryName
FROM CATEGORIES
WHERE CATEGORYID IN (
	SELECT CATEGORYID
	FROM PRODUCTS
	WHERE UNITPRICE >  40
	GROUP BY CATEGORYID
)

------------------------------
/*
SUBQUERY(iç içe sorgu)
*/

--select CategoryName, CategoryID from Categories where CategoryID in (

--)


select ProductName from Products
where UnitPrice > (select avg(UnitPrice) from Products)


select TerritoryID from Territories where RegionID = (
	select RegionID from Region where RegionDescription = 'Northern'
)



select FirstName +space(1)+ LastName +space(1)+ convert(nvarchar(5), EmployeeID) from Employees where EmployeeID in (
	select EmployeeID from EmployeeTerritories where TerritoryID in (
		select TerritoryID from Territories where RegionID = (
			select RegionID from Region where RegionDescription = 'Northern'
		)
	)
)




--select CustomerID from Customers where CompanyName LIKE '%romero%'



select * from Orders where CustomerID in (select CustomerID from Customers where Country = 'Brazil'
)

select top 1 
UnitPrice * Quantity * (1-Discount) from [Order Details] where OrderID in (
	select OrderID from Orders where CustomerID in (
		select CustomerID from Customers where Country = 'Brazil'
	)
)
order by UnitPrice * Quantity * (1-Discount) desc

-- brezilyada yaşayan müşterilerimden en yüksek siparişin tutarı nedir?

select ProductID from Products where UnitPrice > (select avg(UnitPrice) from Products)

select OrderID from [Order Details] where ProductID in (select ProductID from Products where UnitPrice > (select avg(UnitPrice) from Products)
)

select CustomerID from orders where OrderID in (select OrderID from [Order Details] where ProductID in (select ProductID from Products where UnitPrice > (select avg(UnitPrice) from Products)
))

select CompanyName from Customers where CustomerID not in (
	select CustomerID from orders where OrderID in (
		select OrderID from [Order Details] where ProductID in (
			select ProductID from Products where UnitPrice > (
				select avg(UnitPrice) from Products
			)
		)
	)
)

-- order details tablosundaki ürünlerden ortalamadan pahalı olan order'lar
select OrderID from [Order Details] where ProductID in (
			select ProductID from Products where UnitPrice > (
				select avg(UnitPrice) from Products
			)
		)

-- ortalamadan pahalı ürünler
select ProductID from Products where UnitPrice > (
	select avg(UnitPrice) from Products
)


-- ortalama fiyat
select avg(UnitPrice) from Products



--select ProductID from [Order Details] where OrderID in (select OrderID from orders where EmployeeID = (select EmployeeID from Employees where FirstName = 'steven')
--)

--select SupplierID from Products where ProductID in (select ProductID from [Order Details] where OrderID in (select OrderID from orders where EmployeeID = (select EmployeeID from Employees where FirstName = 'steven')
--))

select CompanyName from Suppliers where SupplierID in (
	select SupplierID from Products where ProductID in (
		select ProductID from [Order Details] where OrderID in (
			select OrderID from orders where EmployeeID = (
				select EmployeeID from Employees where FirstName = 'steven'
			)
		)
	)
)






select FirstName, LastName from Employees where EmployeeID in (
	select EmployeeID from Orders where CustomerID in (
		select CustomerID from Customers where CompanyName like '%romero%'
	)
)