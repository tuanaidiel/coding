1. 
SELECT * FROM Employees WHERE Salary > 5000;

2. 
SELECT e.Name, d.DeptName
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.Id;

3.
SELECT d.DeptName, COUNT(e.Id) EmployeeCount
FROM Departments d
LEFT JOIN Employees e ON d.Id = e.DepartmentID
GROUP BY d.DeptName;

4.
UPDATE Employees
SET Salary = 4800
WHERE Name = 'Sam Brown'

5.
DELETE FROM Employees
WHERE Name = 'Lisa Ray'

6. 
INSERT INTO Employees (Id, Name, DepartmentID, Salary)
VALUES (5, 'Mike Tyson', 1, 5500);