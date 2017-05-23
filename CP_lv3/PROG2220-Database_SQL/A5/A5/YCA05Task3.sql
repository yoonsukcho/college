-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\create_databases.sql
-- mysql -u root -p < G:\mysql\YCA05Task3.sql > G:\mysql\YCA05Task3.out

SELECT '' AS 'Yoonsuk Cho' ;
SELECT '' AS 'PROG2220: Section 4' ;
SELECT '' AS 'Assignment 5: Task 3' ;

SELECT SYSDATE() AS 'Current System Date';

USE my_guitar_shop;

SELECT '';
SELECT '' AS '*** Task 3, Q1. MGS Exercise 12-3 [5 points] ***';

CREATE VIEW YC_order_item_products AS
       SELECT o.order_id, 
              o.order_date, 
              o.tax_amount, 
              o.ship_date, 
              i.item_price, 
              i.discount_amount, i.item_price - i.discount_amount AS 'final_price', 
              i.quantity, 
              (i.item_price - i.discount_amount) * i.quantity AS 'item_total', 
              p.product_name
       FROM order_items i
			JOIN orders o
                 ON o.order_id = i.order_id
	        JOIN products p
                 ON p.product_id = i.product_id;

SELECT '';
SELECT '' AS '*** Task 3, Q2. MGS Exercise 12-4 [2 points] ***';

SELECT order_id, product_name, item_total
FROM YC_order_item_products
ORDER BY item_total DESC;

SELECT '';
SELECT '' AS '*** Task 3, Q3. MGS Exercise 12-5 [4 points] ***';

CREATE VIEW YC_product_summary AS
       SELECT product_name, 
              COUNT(*) AS 'order_count', 
              SUM(item_total) AS 'order_total'
	   FROM YC_order_item_products
       GROUP BY product_name;

SELECT '';
SELECT '' AS '*** Task 3, Q4. MGS Exercise 12-6 [2 points] ***';

SELECT product_name, order_total
FROM YC_product_summary
ORDER BY order_total DESC
LIMIT 5;





