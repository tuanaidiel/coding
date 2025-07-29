Students

| StudentID | Name    | Age | ClassID |
| --------- | ------- | --- | ------- |
| 1         | Alice   | 15  | 101     |
| 2         | Bob     | 16  | 101     |
| 3         | Charlie | 15  | 102     |
| 4         | David   | 17  | 103     |
| 5         | Emma    | 18  | 103     |

Classes

| ClassID | ClassName | Teacher     |
| ------- | --------- | ----------- |
| 101     | Math      | Mr. Smith   |
| 102     | Science   | Ms. Lee     |
| 103     | History   | Mr. Johnson |


✍️ Question:
Write an SQL query to find the class with the highest average student age, and return:

- ClassName
- Teacher
- AverageAge

📝 Expected Output:

| ClassName | Teacher     | AverageAge |
| --------- | ----------- | ---------- |
| History   | Mr. Johnson | 17.5       |

ANSWER:

SELECT c.ClassName, c.Teacher, AVG(s.Age) as AverageAge
FROM Students s
JOIN Classes c ON s.ClassID = c.ClassID
GROUP BY c.ClassID, c.ClassName, c.Teacher       //Groups by class to get averages correctly 
ORDER BY AverageAge DESC                         //Sorts from highest to lowest average
SELECT TOP 1;