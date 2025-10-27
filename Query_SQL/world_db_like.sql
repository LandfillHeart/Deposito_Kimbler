USE world;

SELECT * FROM world.countrylanguage
WHERE CountryCode like 'A%'
AND Language LIKE '_t%';

