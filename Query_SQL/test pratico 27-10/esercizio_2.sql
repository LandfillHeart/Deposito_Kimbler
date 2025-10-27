USE MyBookstore;

SELECT Books.title, Books.publishing_year, Books.price, Sales.date_of_sale
FROM Books
LEFT JOIN Sales ON Books.id = Sales.fk_book_id
WHERE Books.publishing_year BETWEEN 2000 AND 2010;