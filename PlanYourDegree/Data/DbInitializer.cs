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

            //Student

            var students = new Student[]
              {
                  new Student {StudentID=528116,FirstName="Nilantha",LastName="Dambadeniya",NineOneNine=91955040},
                  new Student {StudentID=530473,FirstName="Ujjawal",LastName="Kumar",NineOneNine=919562997},
                  new Student {StudentID=533909,FirstName="Meghana",LastName="Putta",NineOneNine=919570037},
                  new Student {StudentID=533570,FirstName="Keerthi sree",LastName="Kukunoor",NineOneNine=919569706},
                  new Student {StudentID=531372,FirstName="Anurag",LastName="Kumar",NineOneNine=919562995}

              };
            Console.WriteLine($"Inserted {students.Length} new Students");
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            //DegreePlan


            var degreePlans = new DegreePlan[]
              {
new DegreePlan {DegreePlanID=101,DegreeID =2,StudentID =528116,DegreePlanAbbreve ="Express",DegreePlanName="Complete the Degree ASAP"},
new DegreePlan {DegreePlanID=102,DegreeID =2,StudentID =528116,DegreePlanAbbreve ="Express",DegreePlanName="Complete the degree Economically"},
new DegreePlan {DegreePlanID=103,DegreeID =2,StudentID =530473,DegreePlanAbbreve ="Express",DegreePlanName="Complete the Degree ASAP"},
new DegreePlan {DegreePlanID=104,DegreeID =2,StudentID =530473,DegreePlanAbbreve ="Express",DegreePlanName="Complete the degree Economically"},
new DegreePlan {DegreePlanID=105,DegreeID =2,StudentID =533909,DegreePlanAbbreve ="Express",DegreePlanName="Complete the Degree ASAP"},
new DegreePlan {DegreePlanID=106,DegreeID =2,StudentID =533909,DegreePlanAbbreve ="Express",DegreePlanName="Complete the degree Economically"},
new DegreePlan {DegreePlanID=107,DegreeID =2,StudentID =533570,DegreePlanAbbreve ="Express",DegreePlanName="Complete the Degree ASAP"},
new DegreePlan {DegreePlanID=108,DegreeID =2,StudentID =533570,DegreePlanAbbreve ="Express",DegreePlanName="Complete the degree Economically"},
new DegreePlan {DegreePlanID=109,DegreeID =2,StudentID =531372,DegreePlanAbbreve ="Express",DegreePlanName="Complete the Degree ASAP"},
new DegreePlan {DegreePlanID=110,DegreeID =2,StudentID =531372,DegreePlanAbbreve ="Express",DegreePlanName="Complete the degree Economically"}

              };
            Console.WriteLine($"Inserted {degreePlans.Length} new DegreePlan");
            foreach (DegreePlan dp in degreePlans)
            {
                context.DegreePlans.Add(dp);
            }
            context.SaveChanges();


            //DegreeTermReq


            var degreeTermsReq= new DegreeTermReq[]
              {
new DegreeTermReq{DegreeTermReqID=1,DegreePlanID =101,TermID =1,CourseId=460},
new DegreeTermReq{DegreeTermReqID=3,DegreePlanID =101,TermID =1,CourseId=542},
new DegreeTermReq{DegreeTermReqID=4,DegreePlanID =101,TermID =1,CourseId=563},
new DegreeTermReq{DegreeTermReqID=5,DegreePlanID =101,TermID =2,CourseId=560},
new DegreeTermReq{DegreeTermReqID=6,DegreePlanID =101,TermID =2,CourseId=555},
new DegreeTermReq{DegreeTermReqID=7,DegreePlanID =101,TermID =2,CourseId=618},
new DegreeTermReq{DegreeTermReqID=8,DegreePlanID =101,TermID =3,CourseId=1},
new DegreeTermReq{DegreeTermReqID=9,DegreePlanID =101,TermID =3,CourseId=664},
new DegreeTermReq{DegreeTermReqID=10,DegreePlanID =101,TermID =3,CourseId=691},
new DegreeTermReq{DegreeTermReqID=11,DegreePlanID =101,TermID =4,CourseId=692},
new DegreeTermReq{DegreeTermReqID=12,DegreePlanID =101,TermID =4,CourseId=10},
new DegreeTermReq{DegreeTermReqID=13,DegreePlanID =101,TermID =4,CourseId=20},
new DegreeTermReq{DegreeTermReqID=14,DegreePlanID =102,TermID =1,CourseId=460},
new DegreeTermReq{DegreeTermReqID=16,DegreePlanID =102,TermID =1,CourseId=542},
new DegreeTermReq{DegreeTermReqID=17,DegreePlanID =102,TermID =1,CourseId=563},
new DegreeTermReq{DegreeTermReqID=18,DegreePlanID =102,TermID =2,CourseId=560},
new DegreeTermReq{DegreeTermReqID=19,DegreePlanID =102,TermID =2,CourseId=555},
new DegreeTermReq{DegreeTermReqID=20,DegreePlanID =102,TermID =2,CourseId=618},
new DegreeTermReq{DegreeTermReqID=21,DegreePlanID =102,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=22,DegreePlanID =102,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=23,DegreePlanID =102,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=24,DegreePlanID =102,TermID =4,CourseId=1},
new DegreeTermReq{DegreeTermReqID=25,DegreePlanID =102,TermID =4,CourseId=664},
new DegreeTermReq{DegreeTermReqID=26,DegreePlanID =102,TermID =4,CourseId=691},
new DegreeTermReq{DegreeTermReqID=27,DegreePlanID =102,TermID =5,CourseId=692},
new DegreeTermReq{DegreeTermReqID=28,DegreePlanID =102,TermID =5,CourseId=10},
new DegreeTermReq{DegreeTermReqID=29,DegreePlanID =102,TermID =5,CourseId=20},
new DegreeTermReq{DegreeTermReqID=30,DegreePlanID =103,TermID =1,CourseId=460},
new DegreeTermReq{DegreeTermReqID=31,DegreePlanID =103,TermID =1,CourseId=542},
new DegreeTermReq{DegreeTermReqID=32,DegreePlanID =103,TermID =1,CourseId=563},
new DegreeTermReq{DegreeTermReqID=33,DegreePlanID =103,TermID =2,CourseId=560},
new DegreeTermReq{DegreeTermReqID=34,DegreePlanID =103,TermID =2,CourseId=555},
new DegreeTermReq{DegreeTermReqID=35,DegreePlanID =103,TermID =2,CourseId=618},
new DegreeTermReq{DegreeTermReqID=36,DegreePlanID =103,TermID =3,CourseId=1},
new DegreeTermReq{DegreeTermReqID=37,DegreePlanID =103,TermID =3,CourseId=664},
new DegreeTermReq{DegreeTermReqID=38,DegreePlanID =103,TermID =3,CourseId=691},
new DegreeTermReq{DegreeTermReqID=39,DegreePlanID =103,TermID =4,CourseId=692},
new DegreeTermReq{DegreeTermReqID=40,DegreePlanID =103,TermID =4,CourseId=10},
new DegreeTermReq{DegreeTermReqID=41,DegreePlanID =103,TermID =4,CourseId=20},
new DegreeTermReq{DegreeTermReqID=42,DegreePlanID =104,TermID =1,CourseId=460},
new DegreeTermReq{DegreeTermReqID=43,DegreePlanID =104,TermID =1,CourseId=542},
new DegreeTermReq{DegreeTermReqID=44,DegreePlanID =104,TermID =1,CourseId=563},
new DegreeTermReq{DegreeTermReqID=45,DegreePlanID =104,TermID =2,CourseId=560},
new DegreeTermReq{DegreeTermReqID=46,DegreePlanID =104,TermID =2,CourseId=555},
new DegreeTermReq{DegreeTermReqID=47,DegreePlanID =104,TermID =2,CourseId=618},
new DegreeTermReq{DegreeTermReqID=48,DegreePlanID =104,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=49,DegreePlanID =104,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=50,DegreePlanID =104,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=51,DegreePlanID =104,TermID =4,CourseId=1},
new DegreeTermReq{DegreeTermReqID=52,DegreePlanID =104,TermID =4,CourseId=664},
new DegreeTermReq{DegreeTermReqID=53,DegreePlanID =104,TermID =4,CourseId=691},
new DegreeTermReq{DegreeTermReqID=54,DegreePlanID =104,TermID =5,CourseId=692},
new DegreeTermReq{DegreeTermReqID=55,DegreePlanID =104,TermID =5,CourseId=10},
new DegreeTermReq{DegreeTermReqID=56,DegreePlanID =104,TermID =5,CourseId=20},
new DegreeTermReq{DegreeTermReqID=57,DegreePlanID =105,TermID =1,CourseId=460},
new DegreeTermReq{DegreeTermReqID=58,DegreePlanID =105,TermID =1,CourseId=542},
new DegreeTermReq{DegreeTermReqID=59,DegreePlanID =105,TermID =1,CourseId=563},
new DegreeTermReq{DegreeTermReqID=60,DegreePlanID =105,TermID =2,CourseId=560},
new DegreeTermReq{DegreeTermReqID=61,DegreePlanID =105,TermID =2,CourseId=555},
new DegreeTermReq{DegreeTermReqID=62,DegreePlanID =105,TermID =2,CourseId=618},
new DegreeTermReq{DegreeTermReqID=63,DegreePlanID =105,TermID =3,CourseId=1},
new DegreeTermReq{DegreeTermReqID=64,DegreePlanID =105,TermID =3,CourseId=664},
new DegreeTermReq{DegreeTermReqID=65,DegreePlanID =105,TermID =3,CourseId=691},
new DegreeTermReq{DegreeTermReqID=66,DegreePlanID =105,TermID =4,CourseId=692},
new DegreeTermReq{DegreeTermReqID=67,DegreePlanID =105,TermID =4,CourseId=10},
new DegreeTermReq{DegreeTermReqID=68,DegreePlanID =105,TermID =4,CourseId=20},
new DegreeTermReq{DegreeTermReqID=69,DegreePlanID =106,TermID =1,CourseId=460},
new DegreeTermReq{DegreeTermReqID=70,DegreePlanID =106,TermID =1,CourseId=542},
new DegreeTermReq{DegreeTermReqID=71,DegreePlanID =106,TermID =1,CourseId=563},
new DegreeTermReq{DegreeTermReqID=72,DegreePlanID =106,TermID =2,CourseId=560},
new DegreeTermReq{DegreeTermReqID=73,DegreePlanID =106,TermID =2,CourseId=555},
new DegreeTermReq{DegreeTermReqID=74,DegreePlanID =106,TermID =2,CourseId=618},
new DegreeTermReq{DegreeTermReqID=75,DegreePlanID =106,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=76,DegreePlanID =106,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=77,DegreePlanID =106,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=78,DegreePlanID =106,TermID =4,CourseId=1},
new DegreeTermReq{DegreeTermReqID=79,DegreePlanID =106,TermID =4,CourseId=664},
new DegreeTermReq{DegreeTermReqID=80,DegreePlanID =106,TermID =4,CourseId=691},
new DegreeTermReq{DegreeTermReqID=81,DegreePlanID =106,TermID =5,CourseId=692},
new DegreeTermReq{DegreeTermReqID=82,DegreePlanID =106,TermID =5,CourseId=10},
new DegreeTermReq{DegreeTermReqID=83,DegreePlanID =106,TermID =5,CourseId=20},
new DegreeTermReq{DegreeTermReqID=84,DegreePlanID =107,TermID =1,CourseId=460},
new DegreeTermReq{DegreeTermReqID=85,DegreePlanID =107,TermID =1,CourseId=542},
new DegreeTermReq{DegreeTermReqID=86,DegreePlanID =107,TermID =1,CourseId=563},
new DegreeTermReq{DegreeTermReqID=87,DegreePlanID =107,TermID =2,CourseId=560},
new DegreeTermReq{DegreeTermReqID=88,DegreePlanID =107,TermID =2,CourseId=555},
new DegreeTermReq{DegreeTermReqID=89,DegreePlanID =107,TermID =2,CourseId=618},
new DegreeTermReq{DegreeTermReqID=90,DegreePlanID =107,TermID =3,CourseId=1},
new DegreeTermReq{DegreeTermReqID=91,DegreePlanID =107,TermID =3,CourseId=664},
new DegreeTermReq{DegreeTermReqID=92,DegreePlanID =107,TermID =3,CourseId=691},
new DegreeTermReq{DegreeTermReqID=93,DegreePlanID =107,TermID =4,CourseId=692},
new DegreeTermReq{DegreeTermReqID=94,DegreePlanID =107,TermID =4,CourseId=10},
new DegreeTermReq{DegreeTermReqID=95,DegreePlanID =107,TermID =4,CourseId=20},
new DegreeTermReq{DegreeTermReqID=96,DegreePlanID =108,TermID =1,CourseId=460},
new DegreeTermReq{DegreeTermReqID=97,DegreePlanID =108,TermID =1,CourseId=542},
new DegreeTermReq{DegreeTermReqID=98,DegreePlanID =108,TermID =1,CourseId=563},
new DegreeTermReq{DegreeTermReqID=99,DegreePlanID =108,TermID =2,CourseId=560},
new DegreeTermReq{DegreeTermReqID=100,DegreePlanID =108,TermID =2,CourseId=555},
new DegreeTermReq{DegreeTermReqID=101,DegreePlanID =108,TermID =2,CourseId=618},
new DegreeTermReq{DegreeTermReqID=102,DegreePlanID =108,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=103,DegreePlanID =108,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=104,DegreePlanID =108,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=105,DegreePlanID =108,TermID =4,CourseId=1},
new DegreeTermReq{DegreeTermReqID=106,DegreePlanID =108,TermID =4,CourseId=664},
new DegreeTermReq{DegreeTermReqID=107,DegreePlanID =108,TermID =4,CourseId=691},
new DegreeTermReq{DegreeTermReqID=108,DegreePlanID =108,TermID =5,CourseId=692},
new DegreeTermReq{DegreeTermReqID=109,DegreePlanID =108,TermID =5,CourseId=10},
new DegreeTermReq{DegreeTermReqID=110,DegreePlanID =108,TermID =5,CourseId=20},
new DegreeTermReq{DegreeTermReqID=111,DegreePlanID =109,TermID =1,CourseId=460},
new DegreeTermReq{DegreeTermReqID=112,DegreePlanID =109,TermID =1,CourseId=542},
new DegreeTermReq{DegreeTermReqID=113,DegreePlanID =109,TermID =1,CourseId=563},
new DegreeTermReq{DegreeTermReqID=114,DegreePlanID =109,TermID =2,CourseId=560},
new DegreeTermReq{DegreeTermReqID=115,DegreePlanID =109,TermID =2,CourseId=555},
new DegreeTermReq{DegreeTermReqID=116,DegreePlanID =109,TermID =2,CourseId=618},
new DegreeTermReq{DegreeTermReqID=117,DegreePlanID =109,TermID =3,CourseId=1},
new DegreeTermReq{DegreeTermReqID=118,DegreePlanID =109,TermID =3,CourseId=664},
new DegreeTermReq{DegreeTermReqID=119,DegreePlanID =109,TermID =3,CourseId=691},
new DegreeTermReq{DegreeTermReqID=120,DegreePlanID =109,TermID =4,CourseId=692},
new DegreeTermReq{DegreeTermReqID=121,DegreePlanID =109,TermID =4,CourseId=10},
new DegreeTermReq{DegreeTermReqID=122,DegreePlanID =109,TermID =4,CourseId=20},
new DegreeTermReq{DegreeTermReqID=123,DegreePlanID =110,TermID =1,CourseId=460},
new DegreeTermReq{DegreeTermReqID=124,DegreePlanID =110,TermID =1,CourseId=542},
new DegreeTermReq{DegreeTermReqID=125,DegreePlanID =110,TermID =1,CourseId=563},
new DegreeTermReq{DegreeTermReqID=126,DegreePlanID =110,TermID =2,CourseId=560},
new DegreeTermReq{DegreeTermReqID=127,DegreePlanID =110,TermID =2,CourseId=555},
new DegreeTermReq{DegreeTermReqID=128,DegreePlanID =110,TermID =2,CourseId=618},
new DegreeTermReq{DegreeTermReqID=129,DegreePlanID =110,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=130,DegreePlanID =110,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=131,DegreePlanID =110,TermID =3,CourseId=0},
new DegreeTermReq{DegreeTermReqID=132,DegreePlanID =110,TermID =4,CourseId=1},
new DegreeTermReq{DegreeTermReqID=133,DegreePlanID =110,TermID =4,CourseId=664},
new DegreeTermReq{DegreeTermReqID=134,DegreePlanID =110,TermID =4,CourseId=691},
new DegreeTermReq{DegreeTermReqID=135,DegreePlanID =110,TermID =5,CourseId=692},
new DegreeTermReq{DegreeTermReqID=136,DegreePlanID =110,TermID =5,CourseId=10},
new DegreeTermReq{DegreeTermReqID=137,DegreePlanID =110,TermID =5,CourseId=20}



              };
            Console.WriteLine($"Inserted {degreeTermsReq.Length} new DegreeTermReq");
            foreach (DegreeTermReq dtr in degreeTermsReq)
            {
                context.DegreeTermReqs.Add(dtr);
            }
            context.SaveChanges();




        }
    }
}
