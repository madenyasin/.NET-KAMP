-- brezilyada ya�ayan m��terilerimden en y�ksek sipari�in tutar� nedir?




-- brezilyada ya�ayan m��teriler
select CustomerID from Customers where country = 'Brazil'


-- brezilyada ya�ayan m��terilerin t�m sipari�leri


-- brezilyada ya�ayan m��terilerin verdikleri order id'leri
select OrderID from Orders where CustomerID in (
	select CustomerID from Customers where country = 'Brazil'
)


-- brezilyada ya�ayan m��terilerin verdikleri sipari�lerdeki t�m �r�nler
select * from [Order Details] where OrderID in (
	select OrderID from Orders where CustomerID in (
		select CustomerID from Customers where country = 'Brazil'
	)
)

-- her bir sat�rdan kazan�lan para
select OrderID, ((UnitPrice * Quantity) * (1 - Discount)) [Gelir] from [Order Details] where OrderID in (
	select OrderID from Orders where CustomerID in (
		select CustomerID from Customers where country = 'Brazil'
	)
)

-- order id'ye g�re gruplar�m, gruptaki toplam geliri bulurum.

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