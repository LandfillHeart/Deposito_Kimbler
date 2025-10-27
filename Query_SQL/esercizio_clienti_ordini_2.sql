USE MyShippingCompany;

-- Clienti Attivi, ordini effettuati, totale costo ordini --
SELECT Clients.username, COUNT(Orders.id) AS Number_Of_Orders, SUM(Orders.cost) AS Total_Spent
FROM Orders
INNER JOIN Clients ON Clients.id = Orders.fk_client_id
GROUP BY Clients.id;

-- Clienti Inattivi
SELECT Clients.username, Clients.city
FROM Clients
WHERE Clients.id NOT IN (SELECT Orders.fk_client_id FROM Orders);

-- Ordini Orfani, senza cliente --
INSERT INTO MyShippingCompany.Orders (order_date, cost) VALUES
	("2025-10-27", 19.99),
	("1980-01-01", 0.01);
    
SELECT * FROM Orders
WHERE Orders.fk_client_id IS null;