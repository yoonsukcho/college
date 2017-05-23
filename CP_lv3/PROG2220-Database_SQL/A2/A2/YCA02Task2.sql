
SELECT '' AS 'Yoonsuk Cho' ;
SELECT '' AS 'PROG2220: Section 4' ;
SELECT '' AS 'Assignment 2: Task 2' ;

SELECT SYSDATE() AS 'Current System Date';

USE swexpert;

SELECT '';
SELECT '' AS '*** Task 2, Q1. SWE Exercise 1 [2 points] ***';

SELECT DISTINCT(c_city)
FROM consultant
ORDER BY c_city;


SELECT '';
SELECT '' AS '*** Task 2, SWE Exercise 2 [2 points] ***';

SELECT p_id, project_name
FROM project
WHERE parent_p_id IS NOT NULL;


SELECT '';
SELECT '' AS '*** Task 2, SWE Exercise 3 [4 points] ***';

SELECT p1.p_id, p1.project_name, p1.parent_p_id, 
	   p2.project_name AS 'project_name'
FROM project p1
	LEFT JOIN project p2
		ON p1.parent_p_id = p2.p_id;


SELECT '';
SELECT '' AS '*** Task 2, Q4. SWE Exercise 4 [3 points] ***';

SELECT c_id, skill_id, certification
FROM consultant_skill
WHERE certification = 'Y'
ORDER BY skill_id, c_id;


SELECT '';
SELECT '' AS '*** Task 2, Q5. SWE Exercise 5 [4 points] ***';

SELECT c.c_id, c.c_last, c.c_first, cs.skill_id, s.skill_description
FROM consultant c 
	JOIN consultant_skill cs
		ON c.c_id = cs.c_id
    JOIN skill s	
		ON cs.skill_id = s.skill_id
WHERE cs.certification = 'Y'
ORDER BY cs.skill_id, cs.c_id;

