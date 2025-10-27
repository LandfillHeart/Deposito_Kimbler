CREATE DATABASE IF NOT EXISTS MyBookstore;
USE MyBookstore;

CREATE TABLE IF NOT EXISTS Books (
   id INT AUTO_INCREMENT PRIMARY KEY,
   title VARCHAR(100),
   author VARCHAR(100),
   genre VARCHAR(50),
   publishing_year INT,
   price DECIMAL(6,2)
);

insert into Books (title, author, genre, publishing_year, price) values ('Centennial', 'Carmita Landall', 'Action|Adventure|Drama|Romance|Western', 1995, 63.66);
insert into Books (title, author, genre, publishing_year, price) values ('Rise of the Footsoldier', 'Stephen King', 'Action|Crime|Drama', 2010, 81.74);
insert into Books (title, author, genre, publishing_year, price) values ('Nausicaä of the Valley of the Wind (Kaze no tani no Naushika)', 'Meriel Claesens', 'Adventure|Animation|Drama|Fantasy|Sci-Fi', 1982, 85.54);
insert into Books (title, author, genre, publishing_year, price) values ('Orphanage, The (Orfanato, El)', 'Bartel Pietranek', 'Drama|Horror|Mystery|Thriller', 1994, 57.45);
insert into Books (title, author, genre, publishing_year, price) values ('Carabineers, The (Carabiniers, Les)', 'Margy Alderwick', 'Comedy|Drama|War', 1999, 66.88);
insert into Books (title, author, genre, publishing_year, price) values ('Ten Shrews, The (Kymmenen riivinrautaa)', 'Rebbecca Cheine', 'Comedy', 2009, 46.56);
insert into Books (title, author, genre, publishing_year, price) values ('Black Rain', 'Stephen King', 'Action|Crime|Drama', 2014, 91.97);
insert into Books (title, author, genre, publishing_year, price) values ('Spring Subway', 'Mady Gofforth', 'Drama|Romance', 2000, 56.17);
insert into Books (title, author, genre, publishing_year, price) values ('Ace of Hearts, The', 'Richard King', 'Crime|Drama|Romance', 1993, 34.0);
insert into Books (title, author, genre, publishing_year, price) values ('Elvis and Me', 'Annette Bushell', 'Drama|Romance', 1991, 30.48);
insert into Books (title, author, genre, publishing_year, price) values ('Intruder, The (L''intrus)', 'Rowan O''Drought', 'Drama', 2016, 46.4);
insert into Books (title, author, genre, publishing_year, price) values ('Out On A Limb', 'Selene Butter', 'Comedy', 1999, 83.59);
insert into Books (title, author, genre, publishing_year, price) values ('Day for Night (La Nuit Américaine)', 'Ermina Tollmache', 'Comedy|Drama|Romance', 2020, 9.25);
insert into Books (title, author, genre, publishing_year, price) values ('Moth, The (Cma)', 'Stephen King', 'Drama', 1985, 73.43);
insert into Books (title, author, genre, publishing_year, price) values ('Class Reunion', 'Amelia King', 'Comedy', 2004, 27.48);
insert into Books (title, author, genre, publishing_year, price) values ('Sirocco', 'Raye Dugood', 'Action|Drama', 2012, 24.75);
insert into Books (title, author, genre, publishing_year, price) values ('Space Pirate Captain Harlock', 'Ernst Shambrook', 'Animation|Sci-Fi', 1980, 30.37);
insert into Books (title, author, genre, publishing_year, price) values ('Fugitive Kind, The', 'Stephen King', 'Crime|Drama|Romance', 2015, 83.47);
insert into Books (title, author, genre, publishing_year, price) values ('Hopscotch', 'Jonathan King', 'Comedy', 1982, 42.44);
insert into Books (title, author, genre, publishing_year, price) values ('Mildred Pierce', 'Grayce Beamond', 'Drama|Film-Noir', 2004, 87.96);

CREATE TABLE IF NOT EXISTS Sales (
   id INT AUTO_INCREMENT PRIMARY KEY,
   fk_book_id INT,
   date_of_sale DATE,
   quantity INT,
   store VARCHAR(100)
);

insert into Sales (fk_book_id, date_of_sale, quantity, store) values (6, '2025-09-07', 5737, 'Ryan, West and Mayert');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (9, '2025-10-13', 554, 'Volkman-Pfeffer');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (10, '2024-01-03', 5413, 'Gleason Group');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (13, '2024-01-29', 906, 'Heathcote-Renner');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (18, '2025-09-20', 3892, 'Moore LLC');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (9, '2024-06-19', 7886, 'Stiedemann Inc');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (4, '2025-04-29', 2838, 'Spinka Group');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (6, '2024-11-27', 2612, 'Kessler-Boyle');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (11, '2025-04-11', 1920, 'Greenholt, Beatty and Brekke');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (12, '2025-10-12', 8436, 'Fritsch Group');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (12, '2024-05-02', 5585, 'Turcotte, Torp and Nolan');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (17, '2024-01-01', 8920, 'Deckow Inc');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (14, '2025-09-25', 2520, 'Zemlak Inc');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (7, '2024-07-10', 6340, 'Hermann Inc');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (12, '2025-07-15', 6489, 'Trantow, Stehr and Volkman');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (12, '2024-01-11', 6791, 'Abshire-Kling');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (18, '2025-06-06', 5225, 'Stamm, Farrell and Glover');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (13, '2025-01-14', 3946, 'Sporer Inc');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (12, '2024-06-11', 997, 'Kuhn LLC');
insert into Sales (fk_book_id, date_of_sale, quantity, store) values (14, '2024-03-17', 8874, 'Lehner, Hilpert and Lesch');
-- TEST CONTENUTI DB --
SELECT * FROM Books;
SELECT * FROM Sales;
-- DROP --
DROP TABLE Books;