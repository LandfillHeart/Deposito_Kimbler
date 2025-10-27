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
    (1, "2025-01-12", 199.80);

-- controlla che sia tutto inserito correttamente --
SELECT * FROM MyShippingCompany.Clients;
SELECT * FROM MyShippingCompany.Orders;

-- pulisci la tabella dai doppioni --
DROP TABLE MyShippingCompany.Orders;

-- INNER JOIN mostra tutti clienti che hanno effettuato un ordine --
SELECT Clients.username, Orders.order_date, Orders.cost
FROM Orders
INNER JOIN Clients ON Clients.id = Orders.fk_client_id
