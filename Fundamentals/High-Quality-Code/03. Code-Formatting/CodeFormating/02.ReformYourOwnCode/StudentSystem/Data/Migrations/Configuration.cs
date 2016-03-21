using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mime;
using StudentSystem.Models;
using ContentType = StudentSystem.Models.ContentType;

namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemEntity>
    {
        public Configuration()
        {
            //AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "StudentSystem.Data.StudentSystemEntity";
        }

        protected override void Seed(StudentSystem.Data.StudentSystemEntity context){

            context.Students.AddOrUpdate(
                s => s.FullName,
                new Students()
                {
                    FullName = "Ivan Ivanov",
                    PhoneNumber = "0884 567 823",
                    RegisteredOn = new DateTime(2010, 10, 15),
                    Birthday = new DateTime(1980, 9, 28)
                },
                new Students()
                {
                    FullName = "Todor Velinov",
                    PhoneNumber = "0888 323 591",
                    RegisteredOn = new DateTime(2010, 10, 25),
                    Birthday = new DateTime(1981, 2, 2)
                },
                new Students()
                {
                    FullName = "Milena Curumbarova",
                    PhoneNumber = "0888 421 714",
                    RegisteredOn = new DateTime(2010, 10, 26),
                    Birthday = new DateTime(1984, 5, 3)
                },
                new Students()
                {
                    FullName = "Eleonora Kapitanova",
                    PhoneNumber = "0885 666 722",
                    RegisteredOn = new DateTime(2010, 10, 26)
                },
                new Students()
                {
                    FullName = "Velichko Manatarov",
                    RegisteredOn = new DateTime(2010, 11, 2),
                    Birthday = new DateTime(1977, 10, 12)
                },
                new Students()
                {
                    FullName = "Ekterina Pramatarova",
                    RegisteredOn = new DateTime(2010, 11, 2)
                },
                new Students()
                {
                    FullName = "Gris Bobanov",
                    PhoneNumber = "77 77 74",
                    RegisteredOn = new DateTime(2010, 12, 21),
                    Birthday = new DateTime(1933, 10, 12)
                });

            context.Courses.AddOrUpdate(
                c => c.CourseName,
                new Courses()
                {
                    CourseName = "Math",
                    Description = "Advanced course",
                    StartDate = new DateTime(2011, 1, 14),
                    EndDate = new DateTime(2011, 6, 30),
                    Price = 100
                },
                new Courses()
                {
                    CourseName = "PHP",
                    Description = "Basic course",
                    StartDate = new DateTime(2011, 1, 15),
                    EndDate = new DateTime(2011, 6, 29),
                    Price = 110
                },
                new Courses()
                {
                    CourseName = "C#",
                    Description = "Basic course",
                    StartDate = new DateTime(2011, 1, 17),
                    EndDate = new DateTime(2011, 6, 30),
                    Price = 130
                },
                new Courses()
                {
                    CourseName = "Java",
                    Description = "Basic course",
                    StartDate = new DateTime(2011, 1, 20),
                    EndDate = new DateTime(2011, 7, 2),
                    Price = 130
                },
                new Courses()
                {
                    CourseName = "HTML+CSS",
                    Description = "Web basics",
                    StartDate = new DateTime(2011, 1, 15),
                    EndDate = new DateTime(2011, 7, 1),
                    Price = 100
                });

            context.Resources.AddOrUpdate(
                r => r.ResourcesName,
                new Resources()
                {
                    ResourcesName = "Algorithms",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/math",
                    CourseId = 1
                },
                new Resources()
                {
                    ResourcesName = "Math Reference Tables",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/math",
                    CourseId = 1
                },
                new Resources()
                {
                    ResourcesName = "XAMPP, LAMP",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/php",
                    CourseId = 2
                },
                new Resources()
                {
                    ResourcesName = "PHP Syntax",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/php",
                    CourseId = 2
                },
                new Resources()
                {
                    ResourcesName = "Working with Forms",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/php",
                    CourseId = 2
                },
                new Resources()
                {
                    ResourcesName = "Regular Expressions",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/php",
                    CourseId = 2
                },
                new Resources()
                {
                    ResourcesName = "PHP Flow Control",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/php",
                    CourseId = 2
                },
                new Resources()
                {
                    ResourcesName = "PHP Arrays Strings Objects",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/php",
                    CourseId = 2
                },
                new Resources()
                {
                    ResourcesName = "Primitive Data Types and Variables",
                    TypeOfResources = TypeOfResources.Document,
                    Url = "http://softuni.bg/csharp",
                    CourseId = 3
                },
                new Resources()
                {
                    ResourcesName = "Loops in C#",
                    TypeOfResources = TypeOfResources.Document,
                    Url = "http://softuni.bg/csharp",
                    CourseId = 3
                },
                new Resources()
                {
                    ResourcesName = "Operators Expressions and Statements",
                    TypeOfResources = TypeOfResources.Document,
                    Url = "http://softuni.bg/csharp",
                    CourseId = 3
                },
                new Resources()
                {
                    ResourcesName = "Console Input Output",
                    TypeOfResources = TypeOfResources.Document,
                    Url = "http://softuni.bg/csharp",
                    CourseId = 3
                },
                new Resources()
                {
                    ResourcesName = "Conditional Statements",
                    TypeOfResources = TypeOfResources.Document,
                    Url = "http://softuni.bg/csharp",
                    CourseId = 3
                },
                new Resources()
                {
                    ResourcesName = "CSharp Advanced Topics",
                    TypeOfResources = TypeOfResources.Document,
                    Url = "http://softuni.bg/csharp",
                    CourseId = 3
                },
                new Resources()
                {
                    ResourcesName = "Introduction to Java",
                    TypeOfResources = TypeOfResources.Video,
                    Url = "http://softuni.bg/java",
                    CourseId = 4
                },
                new Resources()
                {
                    ResourcesName = "Loops in Java",
                    TypeOfResources = TypeOfResources.Video,
                    Url = "http://softuni.bg/java",
                    CourseId = 4
                },
                new Resources()
                {
                    ResourcesName = "Web Basic Concepts",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/html+css",
                    CourseId = 5
                },
                new Resources()
                {
                    ResourcesName = "Web Development Tools",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/html+css",
                    CourseId = 5
                },
                new Resources()
                {
                    ResourcesName = "HTML5",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/html+css",
                    CourseId = 5
                },
                new Resources()
                {
                    ResourcesName = "HTML Tables",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/html+css",
                    CourseId = 5
                },
                new Resources()
                {
                    ResourcesName = "CSS",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/html+css",
                    CourseId = 5
                },
                new Resources()
                {
                    ResourcesName = "Semantic HTML and Other Tags",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/html+css",
                    CourseId = 5
                },
                new Resources()
                {
                    ResourcesName = "HTML Forms",
                    TypeOfResources = TypeOfResources.Presentation,
                    Url = "http://softuni.bg/html+css",
                    CourseId = 5
                });

            context.Homework.AddOrUpdate(
                h => h.SubmissionDate,
                new Homework()
                {
                    Content = "Calculate Algorithms",
                    ContentType = ContentType.Pdf,
                    SubmissionDate = new DateTime(2011, 1, 25, 14, 30, 10),
                    CourseId = 1,
                    StudentId = 1

                },
                new Homework()
                {
                    Content = "Calculate Algorithms",
                    ContentType = ContentType.Pdf,
                    SubmissionDate = new DateTime(2011, 1, 25, 16, 30, 10),
                    CourseId = 1,
                    StudentId = 2

                },
                new Homework()
                {
                    Content = "Calculate Algorithms",
                    ContentType = ContentType.Pdf,
                    SubmissionDate = new DateTime(2011, 1, 26),
                    CourseId = 1,
                    StudentId = 3

                },
                new Homework()
                {
                    Content = "Delve into Reference Tables",
                    ContentType = ContentType.Pdf,
                    SubmissionDate = new DateTime(2011, 1, 29),
                    CourseId = 2,
                    StudentId = 4
                },
                new Homework()
                {
                    Content = "Delve into Reference Tables",
                    ContentType = ContentType.Pdf,
                    SubmissionDate = new DateTime(2011, 1, 30, 11, 30, 12),
                    CourseId = 2,
                    StudentId = 2
                },
                new Homework()
                {
                    Content = "Delve into Reference Tables",
                    ContentType = ContentType.Pdf,
                    SubmissionDate = new DateTime(2011, 1, 30, 16, 30, 10),
                    CourseId = 2,
                    StudentId = 3
                },
                new Homework()
                {
                    Content = "Install and work with XAMPP, LAMP",
                    ContentType = ContentType.Zip,
                    SubmissionDate = new DateTime(2011, 1, 30, 16, 45, 10),
                    CourseId = 2,
                    StudentId = 1
                },
                new Homework()
                {
                    Content = "Practice PHP Syntax",
                    ContentType = ContentType.Zip,
                    SubmissionDate = new DateTime(2011, 2, 1),
                    CourseId = 2,
                    StudentId = 5,
                },
                new Homework()
                {
                    Content = "Primitive Data Types and Variables",
                    ContentType = ContentType.Pdf,
                    SubmissionDate = new DateTime(2011, 2, 2),
                    CourseId = 3,
                    StudentId = 2
                },
                new Homework()
                {
                    Content = "Loops",
                    ContentType = ContentType.Pdf,
                    SubmissionDate = new DateTime(2011, 2, 3, 10, 10, 10),
                    CourseId = 3,
                    StudentId = 4
                });
        }
    }
}
