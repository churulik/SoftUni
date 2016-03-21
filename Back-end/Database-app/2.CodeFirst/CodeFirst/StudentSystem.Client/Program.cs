using System;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using StudentSystem.Data;
using StudentSystem.Models;


namespace StudentSystem.Client
{
    class Program
    {
        static void Main()
        {
            var context = new StudentSystemEntity();


           

            var student = context.Students.ToList();
            var course = context.Courses.ToList();
            
            //Uncoment to insert into [StudentsCourses]

            //student[0].Courses.Add(course[0]);
            //student[1].Courses.Add(course[0]);
            //student[2].Courses.Add(course[0]);
            //student[3].Courses.Add(course[0]);
            //student[4].Courses.Add(course[0]);
            //student[0].Courses.Add(course[1]);
            //student[1].Courses.Add(course[1]);
            //student[2].Courses.Add(course[1]);
            //student[3].Courses.Add(course[1]);
            //student[0].Courses.Add(course[2]);
            //student[1].Courses.Add(course[2]);
            //student[2].Courses.Add(course[2]);
            //student[3].Courses.Add(course[2]);
            //student[4].Courses.Add(course[2]);
            //student[1].Courses.Add(course[3]);
            //student[2].Courses.Add(course[3]);
            //student[3].Courses.Add(course[3]);
            //student[4].Courses.Add(course[3]);
            //student[0].Courses.Add(course[2]);
            //student[0].Courses.Add(course[4]);
            //student[1].Courses.Add(course[4]);
            //student[2].Courses.Add(course[4]);
            //student[3].Courses.Add(course[4]);
            //student[4].Courses.Add(course[4]);
            //student[6].Courses.Add(course[1]);
            //context.SaveChanges();


            /* 1. Lists all students and their homework submissions. 
             * Select only their names and for each homework - content and content-type. */
            
            var homeworkSubmissions = context.Homework
                .Include(s => s.Student)
                .Select(h => new
                {
                    h.Student.FullName,
                    h.Content,
                    h.ContentType
                });

            //foreach (var hw in homeworkSubmissions)
            //{
            //    Console.WriteLine("--Name: {0}\n Homework content: {1}\n Homework type: {2}",
            //        hw.FullName,
            //        hw.Content,
            //        hw.ContentType);
            //}

            /* 2. List all courses with their corresponding resources. 
             * Select the course name and description and everything for each resource. 
             * Order the courses by start date (ascending), then by end date (descending). */

            var resourses = context.Resources
                .Include(r => r.Course)
                .OrderBy(r => r.Course.StartDate)
                .ThenByDescending(r => r.Course.EndDate)
                .Select(s => new
                {
                    s.Course.CourseName,
                    s.Course.Description,
                    s.ResourcesName,
                    s.TypeOfResources,
                    s.Url
                });



            //foreach (var resourse in resourses)
            //{
            //    Console.WriteLine("Course name: {0} - {1}\n " +
            //                      "Resource name: {2}\n " +
            //                      "Resourse type: {3}\n " +
            //                      "Url: {4}\n",
            //                      resourse.Course.CourseName,
            //                      resourse.Course.Description,
            //                      resourse.ResourcesName,
            //                      resourse.TypeOfResources,
            //                      resourse.Url);
            //}

            /* 3. List all courses with more than 5 resources. 
             * Order them by resources count (descending), then by start date (descending). 
             * Select only the course name and the resource count. */

            var moreThanFiveResourses = context.Resources
                .Include(r => r.Course)
                .AsEnumerable()
                .OrderByDescending(r => r.Course.StartDate)
                .GroupBy(r => r.Course.CourseName)
                .Where(grp => grp.Count() > 5)
                .OrderByDescending(grp => grp.Count())
                .Select(grp => new
                {
                    grp.Key,
                    Count = grp.Count()
                });


            //foreach (var courseName in moreThanFiveResourses)
            //{
            //    Console.WriteLine("{0} - {1}", courseName.Key, courseName.Count);
            //}

            /* 4. List all courses which were active on a given date 
             * (choose the date depending on the data seeded to ensure there are results), 
             * and for each course count the number of students enrolled. 
             * Select the course name, start and end date, course duration 
             * (difference between end and start date) and number of students enrolled. 
             * Order the results by the number of students enrolled (in descending order), 
             * then by duration (descending). */

            var activeCorses = context.Courses
                .Include(c => c.Students)
                .AsEnumerable()
                .Where(c => c.StartDate.Day >= 15)
                .OrderByDescending(c => c.Students.Count)
                .ThenByDescending(c => (c.EndDate - c.StartDate))
                .Select(c => new
                {
                    c.CourseName,
                    c.StartDate,
                    c.EndDate,
                    c.Students.Count
                });

            //foreach (var active in activeCorses)
            //{
            //    Console.WriteLine("Course: {0}\n " +
            //                      "Start date: {1}\n " +
            //                      "End date: {2}\n " +
            //                      "Course duration: {3} days\n " +
            //                      "Number of enrolled students: {4}\n",
            //                      active.CourseName,
            //                      active.StartDate.ToString("d"), active.EndDate.ToString("d"),
            //                      (active.EndDate - active.StartDate).TotalDays,
            //                      active.Count);
            //}

            /* 5. For each student, calculate the number of courses she’s enrolled in, 
             * the total price of these courses and the average price per course for the student. 
             * Select the student name, number of courses, total price and average price. 
             * Order the results by total price (descending), then by number of courses (descending) 
             * and then by the student’s name (ascending). */

            var enrolled = from s in context.Students
                           orderby s.Courses.Sum(p => (decimal?) p.Price) descending,
                           s.Courses.Count descending, s.FullName ascending 
                           select new
                           {
                               s.FullName,
                               s.Courses.Count,
                               Sum = s.Courses.Sum(p => (decimal?) p.Price) ?? 0.0M,
                               Average = s.Courses.Average(a => (decimal?) a.Price) ?? 0.0M                    
                           };

            //string[] tableTop = { "Name", "Courses", "Sum", "Avarege" };
            //Console.WriteLine("|----------------------------------------------------------|");
            //Console.WriteLine("| {0, -20} | {1, -7} | {2, -10} | {3, -10} |",
            //    tableTop[0], tableTop[1], tableTop[2], tableTop[3]);
            //Console.WriteLine("|----------------------------------------------------------|");
            //foreach (var enroll in enrolled)
            //{
            //    Console.WriteLine("| {0, -20} | {1, -7} | {2,-7}lv. | {3,-7:F2}lv. |",
            //        enroll.FullName,
            //        enroll.Count,
            //        enroll.Sum,
            //        enroll.Average);
            //}
            //Console.WriteLine("|----------------------------------------------------------|");


            /* Problem 4 */

            //Uncoment to insert into [ResourceLicenses]

            //var mathLicense = new ResourceLicenses()
            //{
            //    LicenseName = "Math.NET",
            //    ResourceId = 1
            //};
            //var phpLicense = new ResourceLicenses()
            //{
            //    LicenseName = "BSD-style",
            //    ResourceId = 3
            //};

            //var cSharpLicense = new ResourceLicenses()
            //{
            //    LicenseName = ".NET",
            //    ResourceId = 9
            //};
            //var javaLicense = new ResourceLicenses()
            //{
            //    LicenseName = "Oracle Binary Code",
            //    ResourceId = 15
            //};
            //var webLicense = new ResourceLicenses()
            //{
            //    LicenseName = "W3C",
            //    ResourceId = 17
            //};

            //context.ResourceLicenseses.Add(mathLicense);
            //context.ResourceLicenseses.Add(phpLicense);
            //context.ResourceLicenseses.Add(cSharpLicense);
            //context.ResourceLicenseses.Add(javaLicense);
            //context.ResourceLicenseses.Add(webLicense);

            //context.SaveChanges();
        }
    }
}
