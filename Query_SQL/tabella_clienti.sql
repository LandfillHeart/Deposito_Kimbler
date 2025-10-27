CREATE DATABASE IF NOT EXISTS AziendaClienti;
USE AziendaClienti;

CREATE TABLE IF NOT EXISTS Clienti (
	id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100),
    cognome VARCHAR(100),
    email VARCHAR(100),
    eta INT,
    citta VARCHAR(100)
);

INSERT INTO AziendaClienti.Clienti (nome, cognome, email, eta, citta) VALUES
	('Alessandro', 'Rossi', 'alessandro.rossi@gmail.com', 28, 'Milano'),
	('Giulia', 'Bianchi', 'giulia.bianchi@yahoo.com', 34, 'Roma'),
	('Andrea', 'Verdi', 'andrea.verdi@gmail.com', 41, 'Torino'),
	('Francesca', 'Costa', 'francesca.costa@outlook.com', 39, 'Napoli'),
	('Luca', 'Moretti', 'luca.moretti@gmail.com', 31, 'Bergamo'),
	('Anna', 'Ferrari', 'anna.ferrari@gmail.com', 26, 'Firenze'),
	('Davide', 'Neri', 'davide.neri@hotmail.com', 44, 'Roma'),
	('Martina', 'Gallo', 'martina.gallo@gmail.com', 29, 'Catania'),
	('Simone', 'Greco', 'simone.greco@libero.it', 32, 'Padova'),
	('Chiara', 'Leone', 'chiara.leone@gmail.com', 36, 'Palermo'),
	('Alberto', 'Rizzi', 'alberto.rizzi@gmail.com', 40, 'Verona'),
	('Valentina', 'Pace', 'valentina.pace@icloud.com', 33, 'Bologna'),
	('Emanuele', 'Villa', 'emanuele.villa@gmail.com', 37, 'Roma Nord'),
	('Arianna', 'Fiore', 'arianna.fiore@gmail.com', 24, 'Genova'),
	('Carlo', 'Marin', 'carlo.marin@outlook.com', 45, 'Roma Sud'),
	('Silvia', 'Conti', 'silvia.conti@gmail.com', 38, 'Perugia'),
	('Federico', 'Sarti', 'federico.sarti@yahoo.com', 30, 'Roma Centro'),
	('Alice', 'Nardi', 'alice.nardi@gmail.com', 35, 'Pescara'),
	('Matteo', 'Lenti', 'matteo.lenti@gmail.com', 42, 'Reggio Emilia'),
	('Elena', 'Valli', 'elena.valli@gmail.com', 27, 'Roma Est');
    
SELECT * FROM AziendaClienti.Clienti 
WHERE email LIKE '%@gmail%';

SELECT * FROM AziendaClienti.Clienti
WHERE email LIKE '%gmail.com';

SELECT * FROM AziendaClienti.Clienti
WHERE nome LIKE 'A%';

SELECT * FROM AziendaClienti.Clienti
WHERE LOWER(nome) LIKE '%a%';

-- 5 caratteri qualsiasi --
SELECT * FROM AziendaClienti.Clienti
WHERE LENGTH(cognome) = 5;

-- 5 lettere --
SELECT * FROM AziendaClienti.Clienti
WHERE CHAR_LENGTH(cognome) = 5;