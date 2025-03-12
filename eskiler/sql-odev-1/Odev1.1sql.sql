-- Mevcut veri (Product_id 1 artýrýlacak)
-- Id	Product_id	Size_id	Color	In_stock
-- 1	1	2	K-Black	2
-- 2	1	2	DB-Dark Blue	4
-- 3	1	3	K-Black	3
-- 4	1	4	NULL	NULL
-- 5	2	3	R-Red	10
-- 6	2	3	RB-RedBlue	1
-- 7	2	4	R-Red	3
-- 8	2	4	RB-RedBlue	8
-- 9	3	2	K-Black	10
-- 10	3	3	K-Black	2
-- 11	4	2	G-Gray	3
-- 12	4	3	G-Gray	0
-- 13	5	1	R-Red	6
-- 14	6	1	RB-RedBlue	3
-- 15	7	2	B-Blue	10
-- 16	7	3	B-Blue	1
-- 17	8	2	GK-Gray Black	5
-- 18	8	3	GK-Gray Black	4
-- 19	8	4	GK-Gray Black	NULL

-- Her satýr için ayrý INSERT ifadeleri (Product_id + 1)

INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (1 + 1, 2, 'K-Black', 2);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (1 + 1, 2, 'DB-Dark Blue', 4);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (1 + 1, 3, 'K-Black', 3);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (1 + 1, 4, NULL, NULL);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (2 + 1, 3, 'R-Red', 10);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (2 + 1, 3, 'RB-RedBlue', 1);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (2 + 1, 4, 'R-Red', 3);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (2 + 1, 4, 'RB-RedBlue', 8);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (3 + 1, 2, 'K-Black', 10);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (3 + 1, 3, 'K-Black', 2);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (4 + 1, 2, 'G-Gray', 3);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (4 + 1, 3, 'G-Gray', 0);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (5 + 1, 1, 'R-Red', 6);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (6 + 1, 1, 'RB-RedBlue', 3);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (7 + 1, 2, 'B-Blue', 10);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (7 + 1, 3, 'B-Blue', 1);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (8 + 1, 2, 'GK-Gray Black', 5);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (8 + 1, 3, 'GK-Gray Black', 4);
INSERT INTO product_variants (Product_id, Size_id, Color, In_stock) VALUES (8 + 1, 4, 'GK-Gray Black', NULL);

-- (Ýsteðe baðlý) Tablo içeriðini kontrol et:
SELECT * FROM product_variants;