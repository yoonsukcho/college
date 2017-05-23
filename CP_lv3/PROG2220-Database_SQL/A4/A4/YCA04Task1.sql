-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\create_databases.sql
-- mysql -u root -p < G:\mysql\YCA01Task1.sql > G:\mysql\YCA01Task1.out

SELECT '' AS 'Yoonsuk Cho' ;
SELECT '' AS 'PROG2220: Section 4' ;
SELECT '' AS 'Assignment 4: Task 1' ;

SELECT SYSDATE() AS 'Current System Date';

USE my_guitar_shop;

SELECT '';
SELECT '' AS '*** Task 1, Q1. MGS Exercise 6-1 [3 points] ***';

SELECT COUNT(*) AS 'order_count', SUM(tax_amount) AS 'tax_total'
FROM orders;

SELECT '';
SELECT '' AS '*** Task 1, Q2. MGS Exercise 6-2 [4 points] ***';

SELECT category_name, COUNT(product_id) AS 'product_count', 
       MAX(list_price) AS'most_expensive_product'
FROM products p
    JOIN categories c
	    ON p.category_id = c.category_id
GROUP BY p.category_id;

SELECT '';
SELECT '' AS '*** Task 1, Q3. MGS Exercise 6-6 [3 points] ***';

SELECT product_name, SUM((item_price - discount_amount) * quantity) AS product_total
FROM orders o
    JOIN order_items i
        ON o.order_id = i.order_id
    JOIN products p
        ON i.product_id = p.product_id
GROUP BY product_name WITH ROLLUP;

SELECT '';
SELECT '' AS '*** Task 1, Q4. MGS Exercise 7-3 [3 points] ***';

SELECT category_name
FROM categories c
WHERE NOT EXISTS 
	(SELECT category_id 
	 FROM products 
     WHERE category_id = c.category_id);




