using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace University.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<CurriculumRow> CurriculumRows { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Diploma> Diplomas { get; set; }
        public DbSet<Dissertation> Dissertations { get; set; }
        private static ApplicationContext instance;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=university.db");
        }
        private ApplicationContext()
        {
            Database.EnsureCreated();
        }
        public static dynamic GetTable(string key)
        {
            switch (key)
            {
                case "Students":
                    return instance.Students;
                case "Студенты":
                    return instance.Students;

                case "People":
                    return instance.People;
                case "Физические лица":
                    return instance.People;

                case "Teachers":
                    return instance.Teachers;
                case "Преподаватели":
                    return instance.Teachers;

                case "CurriculumRows":
                    return instance.CurriculumRows;
                case "Записи учебного плана":
                    return instance.CurriculumRows;

                case "Curriculums":
                    return instance.Curriculums;
                case "Учебные планы":
                    return instance.Curriculums;

                case "Loads":
                    return instance.Loads;
                case "Нагрузка":
                    return instance.Loads;

                case "Groups":
                    return instance.Groups;
                case "Группы":
                    return instance.Groups;

                case "Exams":
                    return instance.Exams;
                case "Ведомости":
                    return instance.Exams;

                case "Faculties":
                    return instance.Faculties;
                case "Факультеты":
                    return instance.Faculties;

                case "Diplomas":
                    return instance.Diplomas;
                case "Дипломы":
                    return instance.Diplomas;

                case "Dissertations":
                    return instance.Dissertations;
                case "Диссертации":
                    return instance.Dissertations;

                default: throw new Exception("Неверное имя таблицы");
            }
        }
        public static ApplicationContext GetInstance()
        {
            instance ??= new();
            return instance;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }

    }
    [PrimaryKey(nameof(Id))]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool DeletionMark { get; set; }
        public bool Sex { get; set; }
        public int KidsCount {  get; set; }
        public override string ToString()
        {
            return Name ?? "<Имя физлица не задано>";
        }
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
        public bool DeletionMark { get; set; }
        public DateOnly EnrollmentDate { get; set; }
        public override string ToString()
        {
            return $"{Person} ({Group})";
        }
    }
    [PrimaryKey(nameof(Id))]
    public class Teacher
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person? Person { get; set; }
        public string Position { get; set; }
        public string Degree { get; set; }
        public bool DeletionMark { get; set; }
        public int Salary { get; set; }
        public DateOnly RecruitmentDate { get; set; }
        public override string ToString()
        {
            return $"{Person} ({Position ?? "безработый"})";
        }
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
        public bool DeletionMark { get; set; }
        public override string ToString()
        {
            return Name ?? "<Имя учебного плана не задано>";
        }
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
        public bool DeletionMark { get; set; }
        public override string ToString()
        {
            return $"{Curriculum} -> {Subject} -> {Control} ({Session})";
        }
    }
    [PrimaryKey(nameof(Id))]
    public class Load
    {
        public int Id { get; set; }
        public int CurriculumRowId { get; set; }
        public CurriculumRow? CurriculumRow { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public bool DeletionMark { get; set; }
        public int Hours { get; set; }
        public int HoursParts { get; set; }
        public override string ToString()
        {
            return $"{Teacher}: {CurriculumRow}";
        }
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
        public bool DeletionMark { get; set; }
        public override string ToString()
        {
            return $"{Student} ## {CurriculumRow}";
        }
    }
    [PrimaryKey(nameof(Id))]
    public class Group
    {
        public int Id { get; set; }
        public int CurriculumRowId { get; set; }
        public CurriculumRow? CurriculumRow { get; set; }
        public string Name { get; set; }
        public bool DeletionMark { get; set; }
        public override string ToString()
        {
            return Name ?? "<Имя группы не задано>";
        }
    }
    [PrimaryKey(nameof(Id))]
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool DeletionMark { get; set; }
        public override string ToString()
        {
            return Name ?? "<Имя факультета не задано>";
        }
    }
    [PrimaryKey(nameof(Id))]
    public class Diploma
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int LoadId { get; set; }
        public Load? Load { get; set; }
        public string Theme { get; set; }
        public override string ToString()
        {
            return $"{Student}, тема - {Theme ?? "<->"}";
        }
    }
    [PrimaryKey(nameof(Id))]
    public class Dissertation
    {
        public int Id { get; set; } 
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public string Level { get; set; }
        public DateOnly Date { get; set; }
        public override string ToString()
        {
            return $"Диссертация {Teacher} на уровень {Level ?? "<->"}";
        }
    }
}
