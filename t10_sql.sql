1.
SELECT c.Name, COALESCE (SUM(oi.Quantity * p.Price), 0) as TotalSpent
FROM Customers c 
LEFT JOIN Orders o ON c.Id = o.CustomerId
LEFT JOIN OrderItems i ON o.Id = oi.OrderId
LEFT JOIN Products p ON oi.ProductId = p.Id
GROUP BY c.Name;

2.
SELECT o.Id AS OrderId, o.OrderDate, p.Name AS Product, oi.Quantity
FROM Orders o
JOIN Customers c ON o.CustomerId = c.Id
JOIN OrderItems oi ON o.Id = oi.OrderId
JOIN Products p ON oi.ProductId = p.Id
WHERE c.Name = 'Alice Green';

3.
SELECT p.Name, SUM(oi.Quantity) as TotalQuantitySold
FROM Products p 
JOIN OrderItems oi ON p.Id = oi.ProductId
GROUP BY p.Name
ORDER BY TotalQuantitySold
LIMIT 1;

4.
INSERT INTO Orders (Id, CustomerId, OrderDate)
VALUES (4, 3, '2025-07-25')

INSERT INTO OrderItems (Id, OrderId, ProductId, Quantity)
VALUES (5, 4, 3, 1);

5.
UPDATE Customers
SET Email = 'bob.stone@email.com'
WHERE Name = 'Bob Stone'