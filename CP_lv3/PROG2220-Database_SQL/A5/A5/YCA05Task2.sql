-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\create_databases.sql
-- mysql -u root -p < G:\mysql\YCA05Task2.sql > G:\mysql\YCA05Task2.out

SELECT '' AS 'Yoonsuk Cho' ;
SELECT '' AS 'PROG2220: Section 4' ;
SELECT '' AS 'Assignment 5: Task 2' ;

SELECT SYSDATE() AS 'Current System Date';

USE swexpert;

SELECT '';
SELECT '' AS '*** Task 2, Q1. SWE Exercise 1 [4 points] ***';

SELECT ROUND(AVG(e.score), 2) AS 'average'
FROM evaluation e
	JOIN consultant c
	     ON c.c_id = e.evaluatee_id
WHERE CONCAT_WS(' ', c.c_first, c.c_last) = 'Janet Park';

SELECT '';
SELECT '' AS '*** Task 2, Q2. SWE Exercise 2 [4 points] ***';

SELECT RPAD(p_id, 4, ' ') AS 'p_id', 
       RPAD(c_id, 4, ' ') AS 'c_id', 
       LPAD(TRUNCATE(DATEDIFF(roll_off_date, roll_on_date)/30.4, 0), 6, ' ') AS 'months'
FROM project_consultant;

SELECT '';
SELECT '' AS '*** Task 2, Q3. SWE Exercise 3 [5 points] ***';

SELECT LPAD(cs.c_id, 4, ' ') AS 'c_id', 
	   RPAD(CONCAT_WS(', ', c.c_last, c.c_first), 20, ' ') AS 'consultant_full_name', 
       LPAD(cs.skill_id, 8, ' ') AS 'skill_id', 
       CASE cs.certification
           WHEN 'Y' THEN 'Certified'
           WHEN 'N' THEN 'Not Certified'
	   END AS 'certification'
FROM consultant_skill cs
     JOIN consultant c
          ON c.c_id = cs.c_id
     JOIN skill s
          ON s.skill_id = cs.skill_id;





