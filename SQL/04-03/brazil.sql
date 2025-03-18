-- brezilyada yaþayan müþterilerimden en yüksek sipariþin tutarý nedir?




-- brezilyada yaþayan müþteriler
select CustomerID from Customers where country = 'Brazil'


-- brezilyada yaþayan müþterilerin tüm sipariþleri


-- brezilyada yaþayan müþterilerin verdikleri order id'leri
select OrderID from Orders where CustomerID in (
	select CustomerID from Customers where country = 'Brazil'
)


-- brezilyada yaþayan müþterilerin verdikleri sipariþlerdeki tüm ürünler
select * from [Order Details] where OrderID in (
	select OrderID from Orders where CustomerID in (
		select CustomerID from Customers where country = 'Brazil'
	)
)

-- her bir satýrdan kazanýlan para
select OrderID, ((UnitPrice * Quantity) * (1 - Discount)) [Gelir] from [Order Details] where OrderID in (
	select OrderID from Orders where CustomerID in (
		select CustomerID from Customers where country = 'Brazil'
	)
)

-- order id'ye göre gruplarým, gruptaki toplam geliri bulurum.

select OrderID, sum((UnitPrice * Quantity) * (1 - Discount)) [Toplam Gelir] from [Order Details] where OrderID in (
	select OrderID from Orders where CustomerID in (
		select CustomerID from Customers where country = 'Brazil'
	)
)
group by OrderID
order by [Toplam Gelir] desc


--final 1
select top 1 sum((UnitPrice * Quantity) * (1 - Discount)) [Toplam Gelir] from [Order Details] where OrderID in (
	select OrderID from Orders where CustomerID in (
		select CustomerID from Customers where country = 'Brazil'
	)
)
group by 
	OrderID
order by 
	[Toplam Gelir] desc


-- final 2
select max([Gelir]) from (
	select sum((UnitPrice * Quantity) * (1 - Discount)) [Gelir] from [Order Details] where OrderID in (
		select OrderID from Orders where CustomerID in (
			select CustomerID from Customers where country = 'Brazil'
		)
	)
	group by 
		OrderID
) as gelirler