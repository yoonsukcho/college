-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\create_databases.sql
-- mysql -u root -p < G:\mysql\YCA01Task1.sql > G:\mysql\YCA01Task1.out

SELECT '' AS 'Yoonsuk Cho' ;
SELECT '' AS 'PROG2220: Section 4' ;
SELECT '' AS 'Assignment 2: Task 1' ;

SELECT SYSDATE() AS 'Current System Date';

USE my_guitar_shop;

SELECT '';
SELECT '' AS '*** Task 1, Q1. MGS Exercise 4-1 [5 points] ***';

SELECT category_name, product_name, list_price
FROM products p
	JOIN categories c
		ON p.category_id = c.category_id
ORDER BY category_name, product_name;


SELECT '';
SELECT '' AS '*** Task 1, Q2. MGS Exercise 4-2 [5 points] ***';

SELECT first_name, last_name, line1, city, state, zip_code
FROM addresses a
	JOIN customers c
		ON a.customer_id = c.customer_id
WHERE c.email_address =  'allan.sherwood@yahoo.com';       


SELECT '';
SELECT '' AS '*** Task 1, Q3. MGS Exercise 4-4 [5 points] ***';

SELECT c.last_name, c.first_name, o.order_date, p.product_name, 
       oi.item_price, oi.discount_amount, oi.quantity
FROM customers c
	JOIN orders o
		ON c.customer_id = o.customer_id
    JOIN order_Items oi
		ON oi.order_id = o.order_id
    JOIN products p
		ON oi.product_id = p.product_id 
ORDER BY c.last_name, o.order_date, p.product_name;


SELECT '';
SELECT '' AS '*** Task 1, Q4. MGS Exercise 4-5 [5 points] ***';

SELECT p1.product_id, p1.product_name, p1.list_price
FROM products p1
	JOIN products p2
		ON p1.product_id <> p2.product_id AND 
		   p1.list_price = p2.list_price;


SELECT '';
SELECT '' AS '*** Task 1, Q5. MGS Exercise 4-7 [5 points] ***';

	SELECT 'SHIPPED' AS 'ship_status', order_id, order_date
	FROM orders
	WHERE ship_date IS NOT NULL
UNION
	SELECT 'NOT SHIPPED' AS 'ship_status', order_id, order_date
	FROM orders
	WHERE ship_date IS NULL
ORDER BY order_date;



