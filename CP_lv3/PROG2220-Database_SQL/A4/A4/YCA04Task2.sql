-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\create_databases.sql
-- mysql -u root -p < G:\mysql\YCA01Task1.sql > G:\mysql\YCA01Task1.out

SELECT '' AS 'Yoonsuk Cho' ;
SELECT '' AS 'PROG2220: Section 4' ;
SELECT '' AS 'Assignment 4: Task 2' ;

SELECT SYSDATE() AS 'Current System Date';

USE swexpert;

SELECT '';
SELECT '' AS '*** Task 2, Q1. SWE Exercise 1 [2 points] ***';

SELECT ROUND(AVG(score), 1) AS 'Average Score'
FROM evaluation
WHERE evaluatee_id = 105;

SELECT '';
SELECT '' AS '*** Task 2, Q2. SWE Exercise 2 [2 points] ***';

SELECT COUNT(*) AS 'Number of Certified'
FROM consultant_skill
WHERE skill_id = 1
AND certification = 'Y';   

SELECT '';
SELECT '' AS '*** Task 2, Q3. SWE Exercise 3 [4 points] ***';

SELECT c_first, c_last
FROM consultant c
	JOIN project_consultant p
		ON c.c_id = p.c_id
WHERE p.p_id IN 
		(SELECT p_id
		 FROM project_consultant p1
			JOIN consultant c1
				ON c1.c_id = p1.c_id
		 WHERE CONCAT(c_first, ' ', c_last) = 'Mark Myers')
GROUP BY c_first, c_last
ORDER BY p.c_id;

SELECT '';
SELECT '' AS '*** Task 2, Q4. SWE Exercise 4 [5 points] ***';

SELECT p_id, project_name
FROM project
WHERE p_id IN 
	(SELECT DISTINCT p_id
     FROM evaluation)

UNION 

SELECT p_id, project_name
FROM project 
WHERE mgr_id IN 
	(SELECT c_id 
     FROM consultant 
     WHERE c_last LIKE 'Z%');




