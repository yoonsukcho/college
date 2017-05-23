
SELECT '' AS 'Yoonsuk Cho' ;
SELECT '' AS 'PROG2220: Section 4' ;
SELECT '' AS 'Assignment 1: Task 2' ;

SELECT SYSDATE() AS 'Current System Date';

USE my_guitar_shop;

SELECT '';
SELECT '' AS '*** Task 2, Q1. MGS Exercise 3-1 [2 points] ***';

SELECT product_code, product_name, list_price, discount_percent
FROM products
ORDER BY list_price DESC; 


SELECT '';
SELECT '' AS '*** Task 2, Q2. MGS Exercise 3-3 [5 points] ***';

SELECT product_name, list_price, date_added
FROM products
WHERE list_price > 500 AND list_price < 2000
ORDER BY date_added DESC; 


SELECT '';
SELECT '' AS '*** Task 2, Q3. MGS Exercise 3-5 [5 points] ***';

SELECT item_id, item_price, discount_amount, quantity, item_price * quantity AS price_total,
       discount_amount * quantity AS discount_total, (item_price - discount_amount) * quantity AS item_total 
FROM order_items
WHERE (item_price - discount_amount) * quantity > 500
ORDER BY item_total DESC; 


SELECT '';
SELECT '' AS '*** Task 2, Q4. MGS Exercise 3-6 [5 points] ***';

SELECT order_id, order_date, ship_date
FROM orders
WHERE ship_date IS NULL;


SELECT '';
SELECT '' AS '*** Task 2, Q5. MGS Exercise 3-8 [3 points] ***';

SELECT 100 AS price, .07 AS tax_rate, (SELECT price) * (SELECT tax_rate) AS tax_amount, (SELECT price) + (SELECT tax_amount) AS 'total';


