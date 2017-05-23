-- cd "C:\Program Files\MySQL\MySQL Server 5.7\bin"
-- mysql -u root -p < G:\mysql\db_setup\create_databases.sql
-- mysql -u root -p < G:\mysql\YCA01Task1.sql > G:\mysql\YCA01Task1.out

SELECT '' AS 'Yoonsuk Cho' ;
SELECT '' AS 'PROG2220: Section 4' ;
SELECT '' AS 'Assignment 4: Task 3' ;

SELECT SYSDATE() AS 'Current System Date';

USE swexpert;

SELECT '';
SELECT '' AS '*** Task 3, Q1. SWE Exercise 1 [4 points] ***';

ALTER TABLE project_consultant
ADD total_days INT DEFAULT 0;

UPDATE project_consultant
SET total_days = DATEDIFF(roll_off_date, roll_on_date);

SELECT ROW_COUNT() AS 'UPDATE: rows affected';  

SELECT * 
FROM project_consultant;

ALTER TABLE project_consultant 
DROP COLUMN total_days;

SELECT '';
SELECT '' AS '*** Task 3, Q2. SWE Exercise 2 [4 points] ***';

DROP TABLE IF EXISTS evaluation_audit;

CREATE TABLE evaluation_audit
( 
audit_id      INT    PRIMARY KEY    AUTO_INCREMENT,
audit_e_id    INT    NOT NULL,
audit_score   INT, 
audit_user    VARCHAR(20)
);

INSERT INTO evaluation_audit
VALUES (DEFAULT, 100, 90, '');

SELECT ROW_COUNT() AS 'INSERT: rows affected'; 

SELECT '';

SELECT * 
FROM evaluation_audit;

SELECT '';
SELECT '' AS '*** Task 3, Q3. SWE Exercise 3 [5 points] ***';

ALTER TABLE evaluation_audit MODIFY audit_user VARCHAR(20) NOT NULL;

ALTER TABLE evaluation_audit 
ADD COLUMN audit_date DATETIME;

INSERT INTO evaluation_audit
VALUES (DEFAULT, 100, 95, USER(), SYSDATE());

SELECT ROW_COUNT() AS 'INSERT: rows affected'; 

SELECT '';

SELECT * 
FROM evaluation_audit;

SELECT '';

INSERT INTO evaluation_audit 
VALUES (DEFAULT, 100, 99, NULL, NULL);

SELECT ROW_COUNT() AS 'INSERT: rows affected'; 

SELECT '';
SELECT '' AS '*** Task 3, Q4. SWE Exercise 4 [1 point] ***';

INSERT INTO project_skill
VALUES (1, NULL);

SELECT ROW_COUNT() AS 'INSERT: rows affected'; 

SELECT '';
SELECT '' AS '*** Task 3, Q5. SWE Exercise 5 [2 points] ***';

DELETE FROM consultant
WHERE c_id = 100;

SELECT ROW_COUNT() AS 'INSERT: rows affected'; 




