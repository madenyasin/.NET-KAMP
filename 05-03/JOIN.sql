CREATE DATABASE MATBAA

CREATE TABLE YAZARLAR(
	ID INT IDENTITY PRIMARY KEY,
	AD NVARCHAR(40) NOT NULL,
	SOYAD NVARCHAR(40) NOT NULL,
	DOGUM_YERI NVARCHAR(50),
)

CREATE TABLE KITAPLAR(
	ID INT IDENTITY PRIMARY KEY,
	AD NVARCHAR(40) NOT NULL,
	SAYFA_SAYISI INT,
	YAZAR_ID INT,

	CONSTRAINT FK_YAZARLAR FOREIGN KEY(YAZAR_ID) REFERENCES YAZARLAR(ID)
)

--------------------------------------- JOIN : BİRLEŞİM --------------------------------------------------------
/*
1- (INNER) JOIN

2- (OUTER) JOIN
	LEFT (OUTER) JOIN
	RIGHT (OUTER) JOIN
	FULL (OUTER) JOIN

	ortak anatarı üzerinden ilişikisi bulunna tablolar birleştirilerek tek tek tablo gibi davranır ve üzerinden sorgulamalar yapılır. 
	Kalıcı bir değişiklik değildir.
	JOIN ifadesinin sağında kalan hep RIGHT TABLE, solunda kalan hep LEFT TABLE kabul edilir. 
*/

--inner
SELECT * FROM YAZARLAR Y JOIN KITAPLAR K ON Y.ID = K.YAZAR_ID

--LEFT

SELECT * FROM YAZARLAR Y LEFT JOIN KITAPLAR K ON Y.ID = K.YAZAR_ID

-- adında leka geçen tedarikçimin tedarik ettiği ürünlerden ne kdar kaandım?

select * from Suppliers s join Products p on s.SupplierID = p.SupplierID join [Order Details] od on p.ProductID = od.ProductID
where CompanyName like '%leka%'


select  c.CustomerID, c.CompanyName from Customers c join Orders o on c.CustomerID=o.CustomerID

							join [Order Details] od on o.OrderID = od.OrderID
							group by c.CustomerID, c.CompanyName



select  c.CustomerID, c.CompanyName from Customers c join Orders o on c.CustomerID=o.CustomerID

							join [Order Details] od on o.OrderID = od.OrderID
							group by c.CustomerID, c.CompanyName


--select  sum(od.UnitPrice * Quantity) * sum() from Customers c join Orders o on c.CustomerID=o.CustomerID

--							join [Order Details] od on o.OrderID = od.OrderID
--							group by c.CustomerID, c.CompanyName




select * from Employees where ReportsTo = (
	select EmployeeID from Employees where FirstName = 'andrew' and LastName='fuller'
)




select * from Employees e join (
	select * from Employees where FirstName = 'andrew' and LastName='fuller'
) as x on e.EmployeeID = x.EmployeeID


select (year(HireDate) - year(BirthDate)) 'İşe başlama yaşı', FirstName, LastName from Employees


select max(UnitsInStock) from Products


SELECT CompanyName FROM EMPLOYEES E	JOIN ORDERS O ON E.EMPLOYEEID = O.EMPLOYEEID
							JOIN SHIPPERS S ON O.SHIPVIA = S.SHIPPERID
							JOIN CUSTOMERS C ON C.CUSTOMERID = O.CUSTOMERID
WHERE (FirstName = 'robert' or
	FirstName = 'margaret' or
	FirstName = 'anne') and o.ShipCity='madrid'




select distinct CompanyName from orders o join Shippers s on o.ShipVia=s.ShipperID
where RequiredDate < ShippedDate





















select ProductName, CategoryName from Products join Categories on Products.CategoryID = Categories.CategoryID



select
	ProductName, CategoryName , p.CategoryID 
from Products p left join Categories c 
	on p.CategoryID = c.CategoryID

select
	ProductName, CategoryName , p.CategoryID 
from Categories c right join Products p 
	on p.CategoryID = c.CategoryID

select
	ProductName, CategoryName , p.CategoryID 
from Categories c full join Products p 
	on p.CategoryID = c.CategoryID


















