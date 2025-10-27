USE MyBookstore;

SELECT Books.title, Books.author, Sales.date_of_sale, Sales.store
FROM Sales
INNER JOIN Books WHERE Books.id = Sales.fk_book_id AND LOWER(Books.author) LIKE '%king';