Table: Students

| StudentID | Name    | Age | ClassID |
| --------- | ------- | --- | ------- |
| 1         | Alice   | 15  | 101     |
| 2         | Bob     | 16  | 101     |
| 3         | Charlie | 15  | 102     |
| 4         | David   | 17  | 103     |

Table: Classes

| ClassID | ClassName | Teacher     |
| ------- | --------- | ----------- |
| 101     | Math      | Mr. Smith   |
| 102     | Science   | Ms. Lee     |
| 103     | History   | Mr. Johnson |

✍️ Question:

Write an SQL query to:
Get the list of students who are 15 years old, along with their class name and teacher’s name.

📝 Expected Output:

| Name    | Age | ClassName | Teacher   |
| ------- | --- | --------- | --------- |
| Alice   | 15  | Math      | Mr. Smith |
| Charlie | 15  | Science   | Ms. Lee   |

ANSWER:

SELECT s.Name, s.Age, c.ClassName, c.Teacher
FROM Students s
JOIN Classes c ON s.ClassID = c.ClassID 
WHERE s.Age = 15;