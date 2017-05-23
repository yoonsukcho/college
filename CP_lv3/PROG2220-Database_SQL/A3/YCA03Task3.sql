
SELECT '' AS 'Yoonsuk Cho' ;
SELECT '' AS 'PROG2220: Section 4' ;
SELECT '' AS 'Assignment 3: Task 3' ;

SELECT SYSDATE() AS 'Current System Date';

USE swexpert;

SELECT '';
SELECT '' AS '*** Task 3, Q1. SWE Exercise 1 [2 points] ***';

INSERT INTO consultant
VALUES
	(106, 'Cho', 'Yoonsuk', 'Y', '123 King st.', 
    'Kitchener', 'ON', '98765', '5195550123', 
    'yoonsukcho@swexpert.com');

SELECT ROW_COUNT() AS 'INSERT: rows affected';    

SELECT '';
SELECT '' AS '*** Task 3, Q2. SWE Exercise 2 [2 points] ***';

INSERT INTO client
VALUES
	(17, 'City of Waterloo', 'Jaworsky', 'Dave', '5198861550');

SELECT ROW_COUNT() AS 'INSERT: rows affected';    

SELECT '';
SELECT '' AS '*** Task 3, Q3. SWE Exercise 3 [3 points] ***';

INSERT INTO project
VALUES
	(88, 'ION Rapid Transit', NULL, 106, NULL);

SELECT ROW_COUNT() AS 'INSERT: rows affected';    

SELECT '';
SELECT '' AS '*** Task 4, Q4. SWE Exercise 4 [3 points] ***';

UPDATE project 
SET parent_p_id = 88
WHERE parent_p_id IS NULL
	AND p_id <> 88;

SELECT ROW_COUNT() AS 'UPDATE: rows affected';    

