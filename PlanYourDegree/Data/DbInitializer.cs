using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanYourDegree.Models;

namespace PlanYourDegree.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Degrees.Any())
            {
                Console.WriteLine("Degrees already exist.");
            }
            else
            {
                var degrees = new Degree[]
                {
                    new Degree{DegreeID=1, DegreeAbbrive="ACS+2", DegreeName="MS ACS+2"},
                    new Degree{DegreeID=2, DegreeAbbrive="ACS+DB", DegreeName="MS ACS+DB"},
                    new Degree{DegreeID=3, DegreeAbbrive="ACS+NF", DegreeName="MS ACS+NF"},
                    new Degree{DegreeID=4, DegreeAbbrive="ACS", DegreeName="MS ACS"}
                };
                Console.WriteLine($"Inserted {degrees.Length} new Degrees");
                foreach (Degree d in degrees)
                {
                    context.Degrees.Add(d);
                }
                context.SaveChanges();
            }

                var courses = new Course[]
                {
                    new Course{CourseID=460, CourseAbbrev="DB", CourseName="44-460 Database Systems"},
                    new Course{CourseID=356, CourseAbbrev="NF", CourseName="44-356 Network Fundamentals"},
                    new Course{CourseID=542, CourseAbbrev="OOP", CourseName="44-542 Object-Oriented Programming"},
                    new Course{CourseID=563, CourseAbbrev="WebApps", CourseName="44-563Developing Web Applications and Services"},
                    new Course{CourseID=560, CourseAbbrev="ADB", CourseName="44-560Advanced Topics in Database Systems"},
                    new Course{CourseID=555, CourseAbbrev="NS", CourseName="44-555Network Security"},
                    new Course{CourseID=618, CourseAbbrev="PM", CourseName="44-618Project Management in Business and Technology"},
                    new Course{CourseID=1, CourseAbbrev="Moblie", CourseName="1 	Mobile Computing"},
                    new Course{CourseID=664, CourseAbbrev="UX", CourseName="44-664User Experience Design"},
                    new Course{CourseID=691, CourseAbbrev="GDP1", CourseName="44-694CS Graduate Directed Project I"},
                    new Course{CourseID=692, CourseAbbrev="GDP2", CourseName="44-692CS Graduate Directed Project II"},
                    new Course{CourseID=10, CourseAbbrev="Elective 1", CourseName="10 Advisor Approved Elective-I"},
                    new Course{CourseID=20, CourseAbbrev="Elective 2", CourseName="20 Advisor Approved Elective-II"}
                };
                Console.WriteLine($"Inserted {courses.Length} new Courses");
                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();

            
        }
    }
}
