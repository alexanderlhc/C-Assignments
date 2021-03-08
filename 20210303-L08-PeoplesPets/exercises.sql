-- Ex 4
SELECT Owner.ID, Owner.Name, Pet.ID AS 'PetId', Pet.Name AS 'PetName'
    FROM Pets AS Pet 
 INNER JOIN 
    Persons AS Owner ON Pet.owner_id = Owner.ID;

-- Ex 5
SELECT Persons.ID, Persons.Name, Persons.Score FROM Persons 
    INNER JOIN Pets ON Persons.ID = Pets.ID
    ORDER BY Persons.Score DESC;    

-- Ex 6
UPDATE Pets SET Weight = 24 WHERE Name = 'Garfield';


-- Ex 7 
SELECT ID FROM Persons WHERE Name = 'Edison';
INSERT INTO Pets (ID, owner_id, Name, Age, Weight, Species) VALUES (7, 17, 'Alfred', 1, 1, 'Cat');
DELETE Pets WHERE ID = 7;

-- Ex 8
DELETE FROM Persons WHERE ID = 8;
INSERT INTO Persons VALUES (8,'Wyatt',      15,  72,  6);