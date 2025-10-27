CREATE DATABASE IF NOT EXISTS MyShippingCompany;
USE MyShippingCompany;

CREATE TABLE IF NOT EXISTS Clients (
	id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(100),
    city VARCHAR(100)
);
INSERT INTO MyShippingCompany.Clients (username, city) VALUES
	('Ray', 'Napoli'),
    ('Sergio', 'Bari'),
    ('Matteo', 'Lucca'),
    ('Mirko', 'Milano'),
    ('Amedeo', 'Caserta'),
    ('Francesco', 'Napoli'),
    ('Salvatore', 'Napoli'),
    ('Armando', 'Bari'),
    ('Arvin', 'Napoli'),
    ('Lucrezia', 'Venezia'),
    ('Rosaria', 'Salerno'),
    ('Federica', 'Roma'),
    ('Lucia', 'Roma'),
    ('Camilla', 'Milano'),
    ('Sara', 'Firenze'),
    ('Daniela', 'Francia'),
    ('Andrea', 'Spagna'),
    ('Tecla', 'Germania'),
    ('Aspen', 'Spagna'),
    ('Luca', 'Bologna');


CREATE TABLE IF NOT EXISTS Orders (
	id INT AUTO_INCREMENT PRIMARY KEY,
    fk_client_id INT,
    order_date DATE,
    cost DECIMAL(7, 2)
);
INSERT INTO MyShippingCompany.Orders (fk_client_id, order_date, cost) VALUES
	(1, "2017-06-15", 19.99),
    (2, "2018-11-22", 300.80),
    (1, "2005-07-19", 142.50),
    (1, "2009-10-30", 188.42),
    (2, "2024-05-02", 201.20),
    (19, "2001-09-23", 999.99),
    (8, "2007-11-23", 89.99),
    (11, "2015-03-12", 23089.12),
    (14, "2025-10-27", 11.99),
    (3, "2002-01-08", 10990.22),
    (7, "2019-11-23", 100),
    (11, "2003-11-21", 1407.75),
    (13, "2016-10-20", 13.99),
    (6, "2004-11-23", 12.05),
    (14, "1999-08-12", 15.65),
    (17, "2006-06-06", 10.99),
    (7, "2001-09-23", 999.99),
    (6, "2022-11-19", 67.67),
    (19, "2014-10-01", 13450.90),
    (1, "2025-01-12", 199.80);

-- controlla che sia tutto inserito correttamente --
SELECT * FROM MyShippingCompany.Clients;
SELECT * FROM MyShippingCompany.Orders;

-- elimina la tabella per inserire di nuovo tutti i dati senza doppioni --
DROP TABLE MyShippingCompany.Orders;
DROP TABLE MyShippingCompany.Clients;

-- INNER JOIN mostra tutti clienti che hanno effettuato un ordine --
SELECT Clients.username, Orders.order_date, Orders.cost
FROM Orders
INNER JOIN Clients ON Clients.id = Orders.fk_client_id;

-- LEFT JOIN visualizza tutti i clienti ed eventuali ordini
SELECT Clients.username, Orders.order_date, Orders.cost
FROM Clients
LEFT JOIN Orders ON Clients.id = Orders.fk_client_id;

-- RIGHT JOIN visualizza tutti gli ordini ed eventuale cliente
SELECT Clients.username, Orders.order_date, Orders.cost
FROM Clients
RIGHT JOIN Orders ON Clients.id = Orders.fk_client_id;