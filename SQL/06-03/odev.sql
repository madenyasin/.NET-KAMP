--1------------------------------------------------------------
create	function GetOrderDetails(@order_id int)
returns table
as
return
	select 
		count(*) [Toplam Kalem Sayýsý], 
		sum(od.Quantity) [Toplam Ürün Sayýsý],
		sum(od.UnitPrice * od.Quantity * (1-od.Discount)) [Toplam Kazanc Miktari]
	from 
		orders o join [Order Details] od on o.OrderID = od.OrderID
	where 
		od.OrderID = @order_id


select * from GetOrderDetails(10248)

--------------------------------------------------------------


select count(*) [Kalem Sayýsý],* from orders o join [Order Details] od on o.OrderID = od.OrderID
where od.OrderID = 10248


select 
	count(*) [Toplam Kalem Sayýsý], 
	sum(od.Quantity) [Toplam Ürün Sayýsý],
	sum(od.UnitPrice * od.Quantity * (1-od.Discount)) [Toplam Kazanc Miktarý]
from 
	orders o join [Order Details] od on o.OrderID = od.OrderID
where 
	od.OrderID = 10248

--2------------------------------------------------------------

create function CreateBarcode3(@CustomerName nvarchar(100))
returns nvarchar(100)
as
begin
	declare @Barcode nvarchar(100)
	set
		@Barcode =	upper(substring(@CustomerName, 1,1)) +
					substring(@CustomerName, 2,1) +
					upper(substring(@CustomerName, 3,1)) +
					substring(@CustomerName, 4, len(@CustomerName) - 3)
	declare @city nvarchar(100)

	select 
		@city = City 
	from 
		Customers
	where
		CompanyName = @CustomerName

	set
		@Barcode =	@Barcode + 
					lower(substring(@city, 1, 2)) +
					substring(@city, 3, len(@city) - 2)

	set
		@Barcode = @Barcode + REVERSE(@CustomerName)
return @Barcode
end

select dbo.CreateBarcode3('FISSA Fabrica Inter. Salchichas S.A.')
