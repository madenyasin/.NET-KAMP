-- kategorilerine göre toplam stok miktarını bulunuz.

select CategoryID, sum(UnitsInStock) [Stok Adeti] from products
group by CategoryID

select 
	c.CategoryName, 
	sum(UnitsInStock) [Stok Adeti] from products p 
join Categories c on p.CategoryID = c.CategoryID
group by c.CategoryName

-- her bir çalışanımın (ad soyad) toplamda ne kadarlık satış yaptığını bulalaım ve çoktan aza sıralayalım.

select 
	FirstName, 
	LastName, 
	sum(od.UnitPrice*od.Quantity*(1-od.Discount)) as [Toplam Satis Tutari] 
from Employees e	join Orders o on e.EmployeeID = o.EmployeeID
					join [Order Details] od on od.OrderID = o.OrderID
group by FirstName, LastName
order by [Toplam Satis Tutari] desc



-- federal shipping ile taşınan ve nancy adlı çalışanım tarafından onaylanan siparişler hangileridir?

select distinct od.OrderID from Orders o	join Shippers s on o.ShipVia = s.ShipperID
						join Employees e on o.EmployeeID = e.EmployeeID
						join [Order Details] od on o.OrderID = od.OrderID
where s.CompanyName = 'federal shipping' and e.FirstName = 'nancy'

-- hangi kadın çalışanlarımın yaptığı satışların indirimsiz tutarı 2000'in üzerindedir.

select FirstName, LastName from Employees e	join Orders o on e.EmployeeID = o.EmployeeID
							join [Order Details] od on o.OrderID = od.OrderID
where e.TitleOfCourtesy in ('Mrs.','Ms.')
group by FirstName, LastName
having  sum(od.UnitPrice * od.Quantity) > 2000
---------------------------------------------------------------------------------

-- her bir kargo firmasına toplamda ne kadar ödeme yapmışım.
select s.CompanyName, sum(Freight) from Orders o join Shippers s on o.ShipVia=s.ShipperID
group by s.CompanyName



-- sipariş adetleri 70'den fazla olan çalışanlarımızı bulalım ad soyad beraber
select e.FirstName + SPACE(1) + e.LastName, count(e.EmployeeID)
from Employees e
join Orders o on e.EmployeeID=o.EmployeeID
group by e.EmployeeID, e.FirstName, e.LastName
having count(e.EmployeeID) > 70


-- kategorilerie göre kazancımı bulmak istersem, en çok kazandıran 3 kategori nedir

select top 3
c.CategoryName,sum(od.Quantity * od.UnitPrice * (1-od.Discount)) as kazanc from Categories c 
join Products p on c.CategoryID = p.CategoryID
join [Order Details] od on od.ProductID = p.ProductID
group by c.CategoryName
order by kazanc desc

--1997 yılında alınan siparişleri hangi çalışanım almış

select FirstName + ' ' + LastName
from Employees e
join Orders o on e.EmployeeID = o.EmployeeID
where year(o.OrderDate) = 1997
group by e.FirstName, e.LastName