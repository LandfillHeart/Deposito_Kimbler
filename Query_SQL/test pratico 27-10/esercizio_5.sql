USE MyBookstore;

SELECT Books.title, Books.author, Books.price, Sales.date_of_sale
FROM Sales
INNER JOIN Books WHERE Books.id = Sales.fk_book_id
-- rimpiazzato IN con LIKE per come è formattato il db --
AND Books.genre LIKE '%Drama%' OR '%Romance%' OR '%Crime%'
AND Books.publishing_year > 1980
AND Sales.store LIKE '%Inc%'
ORDER BY Books.publishing_year ASC;
