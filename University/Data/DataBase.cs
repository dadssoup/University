using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<CurriculumRow> CurriculumRows { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=university.db");
        }

    }
    [PrimaryKey(nameof(Id))]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
    [PrimaryKey(nameof(Id))]
    public class Student
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person? Person { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
        public string State { get; set; }
    }
    [PrimaryKey(nameof(Id))]
    public class Teacher
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person? Person { get; set; }
        public string Position { get; set; }
        public string Degree { get; set; }
    }
    [PrimaryKey(nameof(Id))]
    public class Curriculum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullSession { get; set; }
        public Faculty? Faculty { get; set; }
        public int FacultyId { get; set; }
        public string StudyForm { get; set; }
        public string Direction { get; set; }
        public string Level { get; set; }
        public int DurationSemesters { get; set; }
    }
    [PrimaryKey(nameof(Id))]
    public class CurriculumRow
    {
        public int Id { get; set; }
        public int CurrriculumId { get; set; }
        public Curriculum? Curriculum { get; set; }
        public string Session { get; set; }
        public string Subject { get; set; }
        public string Control { get; set; }
    }
    [PrimaryKey(nameof(Id))]
    public class Load
    {
        public int Id { get; set; }
        public int CurriculumRowId { get; set; }
        public CurriculumRow? CurriculumRow { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
    [PrimaryKey(nameof(Id))]
    public class Exam
    {
        public int Id { get; set; }
        public int CurriculumRowId { get; set; }
        public CurriculumRow? CurriculumRow { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public string Mark { get; set; }
    }
    [PrimaryKey(nameof(Id))]
    public class Group
    {
        public int Id { get; set; }
        public int CurriculumRowId { get; set; }
        public CurriculumRow? CurriculumRow { get; set; }
        public string Name { get; set; }
    }
    [PrimaryKey(nameof(Id))]
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
