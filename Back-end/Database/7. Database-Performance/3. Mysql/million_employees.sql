CREATE TABLE million_employees (
	id INT auto_increment,
    firstName nvarchar(50),
    lastName nvarchar(50),
    hireDate date,
    INDEX idx(id)
);

PARTITION BY RANGE (YEAR(hireDate)) (
	partition p1990 values less than (1990),
    partition p2000 values less than (2000),
    partition p2010 values less than (2010),
    partition p2020 values less than (2020)
);

DELIMITER //
CREATE PROCEDURE insertIntoTable()
BEGIN
	DECLARE i int DEFAULT 1;
	WHILE (i < 37040) DO
		INSERT INTO million_employees (firstName, lastName, hireDate) VALUES
			('Guy', 'Gilbert', '19890731'),
			('Kevin', 'Brown', '19900226'),
			('Roberto', 'Tamburello', '19901212'),
			('Rob', 'Walters', '19910105'),
			('Thierry', 'D''Hers', '19910111'),
			('David', 'Bradley', '19920120'),
			('JoLynn', 'Dobney', '19930126'),
			('Ruth', 'Ellerbrock', '19940206'),
			('Gail', 'Erickson', '19950206'),
			('Barry', 'Johnson', '19960207'),
			('Jossef', 'Goldberg', '19970224'),
			('Terri', 'Duffy', '19980303'),
			('Sidney', 'Higa', '19990305'),
			('Taylor', 'Maxwell','20000311'),
			('Jeffrey', 'Ford', '20010323'),
			('Jo', 'Brown', '20020330'),
			('Doris', 'Hartwig','20030411'),
			('John', 'Campbell', '20040418'),
			('Diane', 'Glimp', '20050429'),
			('Steven', 'Selikoff', '20070102'),
			('Peter', 'Krebs', '20080102'),
			('Stuart', 'Munson', '20090103'),
			('Greg', 'Alderson', '20100103'),
			('David', 'Johnson', '20110103'),
			('Zheng', 'Mu', '20120104'),
			('Ivo', 'Salmre', '20140105'),
			('Paul', 'Komosinski', '20150105');
		SET i =  i + 1;
END WHILE;
END //
DELIMITER ;

CALL insertIntoTable(); -- Time to insert data: 90.060 sec.

SELECT * FROM million_employees
WHERE hireDate < '1990-01-01'; -- Time 0.10 sec.

SELECT * FROM million_employees
WHERE hireDate BETWEEN '1990-01-01' AND '2000-01-01'; -- Time 1.54 sec.

SELECT * FROM million_employees
WHERE hireDate BETWEEN '2000-01-01' AND '2010-01-01'; -- Time 1.45 sec.

SELECT * FROM million_employees
WHERE hireDate BETWEEN '2010-01-01' AND '2020-01-01'; -- Time 0.39 sec.

DROP TABLE million_employees;

DROP PROCEDURE insertIntoTable;
