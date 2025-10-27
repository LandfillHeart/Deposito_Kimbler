USE MyBookstore;

-- Ho usato direttamente alcuni nomi generati piuttosto che quelli scritti nella traccia per non dover ricreare di nuovo la tabella --
SELECT Books.title, Sales.store, Sales.quantity, SUM(Sales.quantity * Books.price)
FROM Sales
INNER JOIN Books ON Books.id = Sales.fk_book_id 
WHERE Sales.store IN ('Ryan, West and Mayert', 'Deckow Inc', 'Gleason Group')
GROUP BY Books.title, Sales.store, Sales.quantity;
-- devo aggiungere per forza group by visto che MySQL blocca la query con aggregazione nel select (ovvero il SUM) --