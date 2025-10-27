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