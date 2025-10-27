USE MyBookstore;

-- Piuttosto che la traccia dove dice che il negozio deve contenere book, ho usato Inc visto che è ripetuto già nel mio db --
-- E visto che non avevo letto l'intera traccia prima di generare il db, la query delle date la faccio tra 01 gennaio 2024 e 31 gugno 2024 --
-- Scusa Mirko...  --
SELECT Books.title, Sales.date_of_sale, Books.price, Sales.quantity
FROM Books
RIGHT JOIN Sales ON Sales.fk_book_id = Books.id
WHERE Sales.date_of_sale BETWEEN '2024-01-01' AND '2024-06-31'
AND Sales.store LIKE '%Inc%'; 