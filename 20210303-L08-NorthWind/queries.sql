-- Ex 12
-- read avg freight from Orders
SELECT AVG(Freight) AS 'Average Freight' FROM Orders;

-- Ex 13
-- unique country from Customers
SELECT DISTINCT Country FROM Customers;
SELECT FirstName, LastName, City FROM Customers WHERE Country = 'France';