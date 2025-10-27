USE world;
USE AziendaClienti;

SELECT world.city.CountryCode, AziendaClienti.Clienti.nome
FROM AziendaClienti.Clienti
LEFT JOIN world.city
ON city.Name = AziendaClienti.Clienti.citta