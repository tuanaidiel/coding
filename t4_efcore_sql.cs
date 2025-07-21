// Task:
// Create EF Core models and relationships for a Student and Enrollment system:

// 1. One student can have many enrollments.
// 2. Each enrollment is linked to one course.
// 3. A course can have many enrollments.

// Instructions:
// Define the Student, Enrollment, and Course classes.
// Add EF Core relationship annotations or Fluent API.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    [Key]
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

public class Course
{
    [Key]
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public int Credits { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}

public class Enrollment
{
    [Key]
    public int EnrollmentId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public int StudentId { get; set; }
    [ForeignKey("StudentId")]
    public Student Student { get; set; }
    public int CourseId { get; set; }
    [ForeignKey("CourseId")]
    public Course Course { get; set; }
    public decimal? Grade { get; set; }
}