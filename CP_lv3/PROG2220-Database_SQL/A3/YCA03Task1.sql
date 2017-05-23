-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\create_databases.sql
-- mysql -u root -p < G:\mysql\YCA01Task1.sql > G:\mysql\YCA01Task1.out

SELECT '' AS 'Yoonsuk Cho' ;
SELECT '' AS 'PROG2220: Section 4' ;
SELECT '' AS 'Assignment 3: Task 1' ;

SELECT SYSDATE() AS 'Current System Date';

USE ap;

SELECT '';
SELECT '' AS '*** Task 1, Q1. Textbook Exercise 5-04 (page 164) [2 points] ***';

INSERT INTO invoices
VALUES
	(DEFAULT, 32, 'AX-014-027',	'2014-08-01', 434.58, 0, 0, 2, '2014-08-31', NULL);

SELECT ROW_COUNT() AS 'INSERT: rows affected';

SELECT '';
SELECT '' AS '*** Task 1, Q2. Textbook Exercise 5-05 (page 165) [2 points] ***';

INSERT INTO invoice_line_items
VALUES
	(LAST_INSERT_ID(), 1, 160, 180.23, 'Hard Drive') , 
	(LAST_INSERT_ID(), 2, 527, 254.35, 'Exchange Server update');

SELECT ROW_COUNT() AS 'INSERT: rows affected';    

SELECT '';
SELECT '' AS '*** Task 1, Q3. Textbook Exercise 5-06 (page 165) [2 points] ***';

UPDATE invoices 
SET credit_total = invoice_total * .1 , 
    payment_total = invoice_total - credit_total
WHERE invoice_id = LAST_INSERT_ID();

SELECT ROW_COUNT() AS 'UPDATE: rows affected';    

SELECT '';
SELECT '' AS '*** Task 1, Q4. Textbook Exercise 5-09 (page 165) [4 points] ***';

DELETE FROM invoice_line_items 
WHERE invoice_id = LAST_INSERT_ID();

SELECT ROW_COUNT() AS 'DELETE: rows affected';  

DELETE FROM invoices 
WHERE invoice_id = LAST_INSERT_ID();

SELECT ROW_COUNT() AS 'DELETE: rows affected';  




