---  HAVING: sorgu sonucu dönen kümede aggregate func. bağlı olacak şekilde bir filtreleme işlemi yapılacaksa 
-- where değil having kullanılır. Eğer agg fonksiyon yok ise where ile having aynı işi yapar
-- dikkat etmemiz gereken neye göre filtrelediğimizdir.


/*


	İŞLEM SIRASI	AŞAMA
		5			SELECT
		1			FROM
		2			WHERE
		3			GROUP BY
		4			HAVING
		6			ORDER BY


Tüm hepsainin kullanıldığı bir sorguda sıralama bu şekilde olur. herhangi biri olmadığında da akış aynen devam eder.

*/

-- toplam tutar bilgisi 2600 ile 3500 arasında olan siparişleimi çoktan aza sıralıyoeuz.

select OrderID, sum(UnitPrice * Quantity * (1 - Discount)) as Kazanc
from [Order Details]
group by OrderID
having sum(UnitPrice * Quantity * (1 - Discount)) between 2600 and 3500
order by kazanc desc


-- her bir siparişteki toplam ürün stok sayısı 200den az olanları getiriniz.
select OrderID, sum(Quantity)as  [Toplam Miktar] from [Order Details]
group by OrderID
having sum(Quantity) < 100