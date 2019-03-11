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
            /*if (context.Degrees.Any())
            {
                Console.WriteLine("Degrees already exist.");
            }
            else
            { */
                var degrees = new Degree[]
                {
                    new Degree{DegreeId=1, DegreeAbbrive="ACS+2", DegreeName="MS ACS+2"},
                    new Degree{DegreeId=2, DegreeAbbrive="ACS+DB", DegreeName="MS ACS+DB"},
                    new Degree{DegreeId=3, DegreeAbbrive="ACS+NF", DegreeName="MS ACS+NF"},
                    new Degree{DegreeId=4, DegreeAbbrive="ACS", DegreeName="MS ACS"}
                };
                Console.WriteLine($"Inserted {degrees.Length} new Degrees");
                foreach (Degree d in degrees)
                {
                    context.Degrees.Add(d);
                }
                context.SaveChanges();
            
            //}

            //Course
            var courses = new Course[]
                {
                    new Course{CourseId=460, CourseAbbrev="DB", CourseName="44-460 Database Systems"},
                    new Course{CourseId=356, CourseAbbrev="NF", CourseName="44-356 Network Fundamentals"},
                    new Course{CourseId=542, CourseAbbrev="OOP", CourseName="44-542 Object-Oriented Programming"},
                    new Course{CourseId=563, CourseAbbrev="WebApps", CourseName="44-563Developing Web Applications and Services"},
                    new Course{CourseId=560, CourseAbbrev="ADB", CourseName="44-560Advanced Topics in Database Systems"},
                    new Course{CourseId=555, CourseAbbrev="NS", CourseName="44-555Network Security"},
                    new Course{CourseId=618, CourseAbbrev="PM", CourseName="44-618Project Management in Business and Technology"},
                    new Course{CourseId=1, CourseAbbrev="Moblie", CourseName="1 	Mobile Computing"},
                    new Course{CourseId=664, CourseAbbrev="UX", CourseName="44-664User Experience Design"},
                    new Course{CourseId=691, CourseAbbrev="GDP1", CourseName="44-694CS Graduate Directed Project I"},
                    new Course{CourseId=692, CourseAbbrev="GDP2", CourseName="44-692CS Graduate Directed Project II"},
                    new Course{CourseId=10, CourseAbbrev="Elective 1", CourseName="10 Advisor Approved Elective-I"},
                    new Course{CourseId=20, CourseAbbrev="Elective 2", CourseName="20 Advisor Approved Elective-II"}
                };
                Console.WriteLine($"Inserted {courses.Length} new Courses");
                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();

            //DegreeReq

            var degreeReq = new DegreeReq[]
              {
                new DegreeReq{DegreeReqId=101,DegreeId =2,CourseId =460},
                new DegreeReq{DegreeReqId=102,DegreeId =2,CourseId =542},
                new DegreeReq{DegreeReqId=103,DegreeId =2,CourseId =563},
                new DegreeReq{DegreeReqId=104,DegreeId =2,CourseId =560},
                new DegreeReq{DegreeReqId=105,DegreeId =2,CourseId =555},
                new DegreeReq{DegreeReqId=106,DegreeId =2,CourseId =618},
                new DegreeReq{DegreeReqId=107,DegreeId =2,CourseId =1},
                new DegreeReq{DegreeReqId=108,DegreeId =2,CourseId =664},
                new DegreeReq{DegreeReqId=109,DegreeId =2,CourseId =691},
                new DegreeReq{DegreeReqId=110,DegreeId =2,CourseId =692},
                new DegreeReq{DegreeReqId=111,DegreeId =2,CourseId =10},
                new DegreeReq{DegreeReqId=112,DegreeId =2,CourseId =20}

              };
            Console.WriteLine($"Inserted {degreeReq.Length} new DegreeReq");
            foreach (DegreeReq dr in degreeReq)
            {
                context.DegreeReqs.Add(dr);
            }
            context.SaveChanges();



            //DegreeTermReq


            var degreeTermsReq = new DegreeTermReq[]
              {
                new DegreeTermReq{DegreeTermReqId=1,DegreePlanId =101,StudentTermId =1,CourseId=460},
                new DegreeTermReq{DegreeTermReqId=3,DegreePlanId =101,StudentTermId =1,CourseId=542},
                new DegreeTermReq{DegreeTermReqId=4,DegreePlanId =101,StudentTermId =1,CourseId=563},
                new DegreeTermReq{DegreeTermReqId=5,DegreePlanId =101,StudentTermId =2,CourseId=560},
                new DegreeTermReq{DegreeTermReqId=6,DegreePlanId =101,StudentTermId =2,CourseId=555},
                new DegreeTermReq{DegreeTermReqId=7,DegreePlanId =101,StudentTermId =2,CourseId=618},
                new DegreeTermReq{DegreeTermReqId=8,DegreePlanId =101,StudentTermId =3,CourseId=1},
                new DegreeTermReq{DegreeTermReqId=9,DegreePlanId =101,StudentTermId =3,CourseId=664},
                new DegreeTermReq{DegreeTermReqId=10,DegreePlanId =101,StudentTermId =3,CourseId=691},
                new DegreeTermReq{DegreeTermReqId=11,DegreePlanId =101,StudentTermId =4,CourseId=692},
                new DegreeTermReq{DegreeTermReqId=12,DegreePlanId =101,StudentTermId =4,CourseId=10},
                new DegreeTermReq{DegreeTermReqId=13,DegreePlanId =101,StudentTermId =4,CourseId=20},
                new DegreeTermReq{DegreeTermReqId=14,DegreePlanId =102,StudentTermId =1,CourseId=460},
                new DegreeTermReq{DegreeTermReqId=16,DegreePlanId =102,StudentTermId =1,CourseId=542},
                new DegreeTermReq{DegreeTermReqId=17,DegreePlanId =102,StudentTermId =1,CourseId=563},
                new DegreeTermReq{DegreeTermReqId=18,DegreePlanId =102,StudentTermId =2,CourseId=560},
                new DegreeTermReq{DegreeTermReqId=19,DegreePlanId =102,StudentTermId =2,CourseId=555},
                new DegreeTermReq{DegreeTermReqId=20,DegreePlanId =102,StudentTermId =2,CourseId=618},
                new DegreeTermReq{DegreeTermReqId=21,DegreePlanId =102,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=22,DegreePlanId =102,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=23,DegreePlanId =102,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=24,DegreePlanId =102,StudentTermId =4,CourseId=1},
                new DegreeTermReq{DegreeTermReqId=25,DegreePlanId =102,StudentTermId =4,CourseId=664},
                new DegreeTermReq{DegreeTermReqId=26,DegreePlanId =102,StudentTermId =4,CourseId=691},
                new DegreeTermReq{DegreeTermReqId=27,DegreePlanId =102,StudentTermId =5,CourseId=692},
                new DegreeTermReq{DegreeTermReqId=28,DegreePlanId =102,StudentTermId =5,CourseId=10},
                new DegreeTermReq{DegreeTermReqId=29,DegreePlanId =102,StudentTermId =5,CourseId=20},
                new DegreeTermReq{DegreeTermReqId=30,DegreePlanId =103,StudentTermId =1,CourseId=460},
                new DegreeTermReq{DegreeTermReqId=31,DegreePlanId =103,StudentTermId =1,CourseId=542},
                new DegreeTermReq{DegreeTermReqId=32,DegreePlanId =103,StudentTermId =1,CourseId=563},
                new DegreeTermReq{DegreeTermReqId=33,DegreePlanId =103,StudentTermId =2,CourseId=560},
                new DegreeTermReq{DegreeTermReqId=34,DegreePlanId =103,StudentTermId =2,CourseId=555},
                new DegreeTermReq{DegreeTermReqId=35,DegreePlanId =103,StudentTermId =2,CourseId=618},
                new DegreeTermReq{DegreeTermReqId=36,DegreePlanId =103,StudentTermId =3,CourseId=1},
                new DegreeTermReq{DegreeTermReqId=37,DegreePlanId =103,StudentTermId =3,CourseId=664},
                new DegreeTermReq{DegreeTermReqId=38,DegreePlanId =103,StudentTermId =3,CourseId=691},
                new DegreeTermReq{DegreeTermReqId=39,DegreePlanId =103,StudentTermId =4,CourseId=692},
                new DegreeTermReq{DegreeTermReqId=40,DegreePlanId =103,StudentTermId =4,CourseId=10},
                new DegreeTermReq{DegreeTermReqId=41,DegreePlanId =103,StudentTermId =4,CourseId=20},
                new DegreeTermReq{DegreeTermReqId=42,DegreePlanId =104,StudentTermId =1,CourseId=460},
                new DegreeTermReq{DegreeTermReqId=43,DegreePlanId =104,StudentTermId =1,CourseId=542},
                new DegreeTermReq{DegreeTermReqId=44,DegreePlanId =104,StudentTermId =1,CourseId=563},
                new DegreeTermReq{DegreeTermReqId=45,DegreePlanId =104,StudentTermId =2,CourseId=560},
                new DegreeTermReq{DegreeTermReqId=46,DegreePlanId =104,StudentTermId =2,CourseId=555},
                new DegreeTermReq{DegreeTermReqId=47,DegreePlanId =104,StudentTermId =2,CourseId=618},
                new DegreeTermReq{DegreeTermReqId=48,DegreePlanId =104,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=49,DegreePlanId =104,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=50,DegreePlanId =104,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=51,DegreePlanId =104,StudentTermId =4,CourseId=1},
                new DegreeTermReq{DegreeTermReqId=52,DegreePlanId =104,StudentTermId =4,CourseId=664},
                new DegreeTermReq{DegreeTermReqId=53,DegreePlanId =104,StudentTermId =4,CourseId=691},
                new DegreeTermReq{DegreeTermReqId=54,DegreePlanId =104,StudentTermId =5,CourseId=692},
                new DegreeTermReq{DegreeTermReqId=55,DegreePlanId =104,StudentTermId =5,CourseId=10},
                new DegreeTermReq{DegreeTermReqId=56,DegreePlanId =104,StudentTermId =5,CourseId=20},
                new DegreeTermReq{DegreeTermReqId=57,DegreePlanId =105,StudentTermId =1,CourseId=460},
                new DegreeTermReq{DegreeTermReqId=58,DegreePlanId =105,StudentTermId =1,CourseId=542},
                new DegreeTermReq{DegreeTermReqId=59,DegreePlanId =105,StudentTermId =1,CourseId=563},
                new DegreeTermReq{DegreeTermReqId=60,DegreePlanId =105,StudentTermId =2,CourseId=560},
                new DegreeTermReq{DegreeTermReqId=61,DegreePlanId =105,StudentTermId =2,CourseId=555},
                new DegreeTermReq{DegreeTermReqId=62,DegreePlanId =105,StudentTermId =2,CourseId=618},
                new DegreeTermReq{DegreeTermReqId=63,DegreePlanId =105,StudentTermId =3,CourseId=1},
                new DegreeTermReq{DegreeTermReqId=64,DegreePlanId =105,StudentTermId =3,CourseId=664},
                new DegreeTermReq{DegreeTermReqId=65,DegreePlanId =105,StudentTermId =3,CourseId=691},
                new DegreeTermReq{DegreeTermReqId=66,DegreePlanId =105,StudentTermId =4,CourseId=692},
                new DegreeTermReq{DegreeTermReqId=67,DegreePlanId =105,StudentTermId =4,CourseId=10},
                new DegreeTermReq{DegreeTermReqId=68,DegreePlanId =105,StudentTermId =4,CourseId=20},
                new DegreeTermReq{DegreeTermReqId=69,DegreePlanId =106,StudentTermId =1,CourseId=460},
                new DegreeTermReq{DegreeTermReqId=70,DegreePlanId =106,StudentTermId =1,CourseId=542},
                new DegreeTermReq{DegreeTermReqId=71,DegreePlanId =106,StudentTermId =1,CourseId=563},
                new DegreeTermReq{DegreeTermReqId=72,DegreePlanId =106,StudentTermId =2,CourseId=560},
                new DegreeTermReq{DegreeTermReqId=73,DegreePlanId =106,StudentTermId =2,CourseId=555},
                new DegreeTermReq{DegreeTermReqId=74,DegreePlanId =106,StudentTermId =2,CourseId=618},
                new DegreeTermReq{DegreeTermReqId=75,DegreePlanId =106,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=76,DegreePlanId =106,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=77,DegreePlanId =106,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=78,DegreePlanId =106,StudentTermId =4,CourseId=1},
                new DegreeTermReq{DegreeTermReqId=79,DegreePlanId =106,StudentTermId =4,CourseId=664},
                new DegreeTermReq{DegreeTermReqId=80,DegreePlanId =106,StudentTermId =4,CourseId=691},
                new DegreeTermReq{DegreeTermReqId=81,DegreePlanId =106,StudentTermId =5,CourseId=692},
                new DegreeTermReq{DegreeTermReqId=82,DegreePlanId =106,StudentTermId =5,CourseId=10},
                new DegreeTermReq{DegreeTermReqId=83,DegreePlanId =106,StudentTermId =5,CourseId=20},
                new DegreeTermReq{DegreeTermReqId=84,DegreePlanId =107,StudentTermId =1,CourseId=460},
                new DegreeTermReq{DegreeTermReqId=85,DegreePlanId =107,StudentTermId =1,CourseId=542},
                new DegreeTermReq{DegreeTermReqId=86,DegreePlanId =107,StudentTermId =1,CourseId=563},
                new DegreeTermReq{DegreeTermReqId=87,DegreePlanId =107,StudentTermId =2,CourseId=560},
                new DegreeTermReq{DegreeTermReqId=88,DegreePlanId =107,StudentTermId =2,CourseId=555},
                new DegreeTermReq{DegreeTermReqId=89,DegreePlanId =107,StudentTermId =2,CourseId=618},
                new DegreeTermReq{DegreeTermReqId=90,DegreePlanId =107,StudentTermId =3,CourseId=1},
                new DegreeTermReq{DegreeTermReqId=91,DegreePlanId =107,StudentTermId =3,CourseId=664},
                new DegreeTermReq{DegreeTermReqId=92,DegreePlanId =107,StudentTermId =3,CourseId=691},
                new DegreeTermReq{DegreeTermReqId=93,DegreePlanId =107,StudentTermId =4,CourseId=692},
                new DegreeTermReq{DegreeTermReqId=94,DegreePlanId =107,StudentTermId =4,CourseId=10},
                new DegreeTermReq{DegreeTermReqId=95,DegreePlanId =107,StudentTermId =4,CourseId=20},
                new DegreeTermReq{DegreeTermReqId=96,DegreePlanId =108,StudentTermId =1,CourseId=460},
                new DegreeTermReq{DegreeTermReqId=97,DegreePlanId =108,StudentTermId =1,CourseId=542},
                new DegreeTermReq{DegreeTermReqId=98,DegreePlanId =108,StudentTermId =1,CourseId=563},
                new DegreeTermReq{DegreeTermReqId=99,DegreePlanId =108,StudentTermId =2,CourseId=560},
                new DegreeTermReq{DegreeTermReqId=100,DegreePlanId =108,StudentTermId =2,CourseId=555},
                new DegreeTermReq{DegreeTermReqId=101,DegreePlanId =108,StudentTermId =2,CourseId=618},
                new DegreeTermReq{DegreeTermReqId=102,DegreePlanId =108,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=103,DegreePlanId =108,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=104,DegreePlanId =108,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=105,DegreePlanId =108,StudentTermId =4,CourseId=1},
                new DegreeTermReq{DegreeTermReqId=106,DegreePlanId =108,StudentTermId =4,CourseId=664},
                new DegreeTermReq{DegreeTermReqId=107,DegreePlanId =108,StudentTermId =4,CourseId=691},
                new DegreeTermReq{DegreeTermReqId=108,DegreePlanId =108,StudentTermId =5,CourseId=692},
                new DegreeTermReq{DegreeTermReqId=109,DegreePlanId =108,StudentTermId =5,CourseId=10},
                new DegreeTermReq{DegreeTermReqId=110,DegreePlanId =108,StudentTermId =5,CourseId=20},
                new DegreeTermReq{DegreeTermReqId=111,DegreePlanId =109,StudentTermId =1,CourseId=460},
                new DegreeTermReq{DegreeTermReqId=112,DegreePlanId =109,StudentTermId =1,CourseId=542},
                new DegreeTermReq{DegreeTermReqId=113,DegreePlanId =109,StudentTermId =1,CourseId=563},
                new DegreeTermReq{DegreeTermReqId=114,DegreePlanId =109,StudentTermId =2,CourseId=560},
                new DegreeTermReq{DegreeTermReqId=115,DegreePlanId =109,StudentTermId =2,CourseId=555},
                new DegreeTermReq{DegreeTermReqId=116,DegreePlanId =109,StudentTermId =2,CourseId=618},
                new DegreeTermReq{DegreeTermReqId=117,DegreePlanId =109,StudentTermId =3,CourseId=1},
                new DegreeTermReq{DegreeTermReqId=118,DegreePlanId =109,StudentTermId =3,CourseId=664},
                new DegreeTermReq{DegreeTermReqId=119,DegreePlanId =109,StudentTermId =3,CourseId=691},
                new DegreeTermReq{DegreeTermReqId=120,DegreePlanId =109,StudentTermId =4,CourseId=692},
                new DegreeTermReq{DegreeTermReqId=121,DegreePlanId =109,StudentTermId =4,CourseId=10},
                new DegreeTermReq{DegreeTermReqId=122,DegreePlanId =109,StudentTermId =4,CourseId=20},
                new DegreeTermReq{DegreeTermReqId=123,DegreePlanId =110,StudentTermId =1,CourseId=460},
                new DegreeTermReq{DegreeTermReqId=124,DegreePlanId =110,StudentTermId =1,CourseId=542},
                new DegreeTermReq{DegreeTermReqId=125,DegreePlanId =110,StudentTermId =1,CourseId=563},
                new DegreeTermReq{DegreeTermReqId=126,DegreePlanId =110,StudentTermId =2,CourseId=560},
                new DegreeTermReq{DegreeTermReqId=127,DegreePlanId =110,StudentTermId =2,CourseId=555},
                new DegreeTermReq{DegreeTermReqId=128,DegreePlanId =110,StudentTermId =2,CourseId=618},
                new DegreeTermReq{DegreeTermReqId=129,DegreePlanId =110,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=130,DegreePlanId =110,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=131,DegreePlanId =110,StudentTermId =3,CourseId=0},
                new DegreeTermReq{DegreeTermReqId=132,DegreePlanId =110,StudentTermId =4,CourseId=1},
                new DegreeTermReq{DegreeTermReqId=133,DegreePlanId =110,StudentTermId =4,CourseId=664},
                new DegreeTermReq{DegreeTermReqId=134,DegreePlanId =110,StudentTermId =4,CourseId=691},
                new DegreeTermReq{DegreeTermReqId=135,DegreePlanId =110,StudentTermId =5,CourseId=692},
                new DegreeTermReq{DegreeTermReqId=136,DegreePlanId =110,StudentTermId =5,CourseId=10},
                new DegreeTermReq{DegreeTermReqId=137,DegreePlanId =110,StudentTermId =5,CourseId=20}



              };
            Console.WriteLine($"Inserted {degreeTermsReq.Length} new DegreeTermReq");
            foreach (DegreeTermReq dtr in degreeTermsReq)
            {
                context.DegreeTermReqs.Add(dtr);
            }
            context.SaveChanges();

            


            //DegreePlan


            var degreePlans = new DegreePlan[]
              {
                new DegreePlan {DegreePlanId=101,DegreeId =2,StudentId =528116,DegreePlanAbbreve ="Express",DegreePlanName="Complete the Degree ASAP"},
                new DegreePlan {DegreePlanId=102,DegreeId =2,StudentId =528116,DegreePlanAbbreve ="Express",DegreePlanName="Complete the degree Economically"},
                new DegreePlan {DegreePlanId=103,DegreeId =2,StudentId =530473,DegreePlanAbbreve ="Express",DegreePlanName="Complete the Degree ASAP"},
                new DegreePlan {DegreePlanId=104,DegreeId =2,StudentId =530473,DegreePlanAbbreve ="Express",DegreePlanName="Complete the degree Economically"},
                new DegreePlan {DegreePlanId=105,DegreeId =2,StudentId =533909,DegreePlanAbbreve ="Express",DegreePlanName="Complete the Degree ASAP"},
                new DegreePlan {DegreePlanId=106,DegreeId =2,StudentId =533909,DegreePlanAbbreve ="Express",DegreePlanName="Complete the degree Economically"},
                new DegreePlan {DegreePlanId=107,DegreeId =2,StudentId =533570,DegreePlanAbbreve ="Express",DegreePlanName="Complete the Degree ASAP"},
                new DegreePlan {DegreePlanId=108,DegreeId =2,StudentId =533570,DegreePlanAbbreve ="Express",DegreePlanName="Complete the degree Economically"},
                new DegreePlan {DegreePlanId=109,DegreeId =2,StudentId =531372,DegreePlanAbbreve ="Express",DegreePlanName="Complete the Degree ASAP"},
                new DegreePlan {DegreePlanId=110,DegreeId =2,StudentId =531372,DegreePlanAbbreve ="Express",DegreePlanName="Complete the degree Economically"}

              };
            Console.WriteLine($"Inserted {degreePlans.Length} new DegreePlan");
            foreach (DegreePlan dp in degreePlans)
            {
                context.DegreePlans.Add(dp);
            }
            context.SaveChanges();       



            //Student

            var students = new Student[]
              {
                  new Student {StudentId=528116,FirstName="Nilantha",LastName="Dambadeniya",NineOneNine=91955040},
                  new Student {StudentId=530473,FirstName="Ujjawal",LastName="Kumar",NineOneNine=919562997},
                  new Student {StudentId=533909,FirstName="Meghana",LastName="Putta",NineOneNine=919570037},
                  new Student {StudentId=533570,FirstName="Keerthi sree",LastName="Kukunoor",NineOneNine=919569706},
                  new Student {StudentId=531372,FirstName="Anurag",LastName="Kumar",NineOneNine=919562995}

              };
            Console.WriteLine($"Inserted {students.Length} new Students");
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            //StudentTerm

            var studentTerm = new StudentTerm[]
              {
                new StudentTerm {StudentTermId=1,StudentId =528116,Term=1,TermName =" Fall 2017 ",TermAbbrev =" F17 " },
                new StudentTerm {StudentTermId=2,StudentId =528116,Term=2,TermName =" Spring 2018 ",TermAbbrev =" SP18 " },
                new StudentTerm {StudentTermId=3,StudentId =528116,Term=3,TermName =" Summer 2018 ",TermAbbrev =" SU18 " },
                new StudentTerm {StudentTermId=4,StudentId =528116,Term=4,TermName =" Fall 2018 ",TermAbbrev =" F18 " },
                new StudentTerm {StudentTermId=5,StudentId =528116,Term=5,TermName =" Spring 2019 ",TermAbbrev =" SP19 " },
                new StudentTerm {StudentTermId=1,StudentId =530473,Term=1,TermName =" Spring 2018 ",TermAbbrev =" SP18 " },
                new StudentTerm {StudentTermId=2,StudentId =530473,Term=2,TermName =" Summer 2018 ",TermAbbrev =" SU18 " },
                new StudentTerm {StudentTermId=3,StudentId =530473,Term=3,TermName =" Fall 2018 ",TermAbbrev =" F18 " },
                new StudentTerm {StudentTermId=4,StudentId =530473,Term=4,TermName =" Spring 2019 ",TermAbbrev =" SP19 " },
                new StudentTerm {StudentTermId=5,StudentId =530473,Term=5,TermName =" Summer 2019 ",TermAbbrev =" SU19 " },
                new StudentTerm {StudentTermId=1,StudentId =533909,Term=1,TermName =" Fall 2019 ",TermAbbrev =" F19 " },
                new StudentTerm {StudentTermId=2,StudentId =533909,Term=2,TermName =" Spring 2020 ",TermAbbrev =" SP20 " },
                new StudentTerm {StudentTermId=3,StudentId =533909,Term=3,TermName =" Summer 2020 ",TermAbbrev =" SU20 " },
                new StudentTerm {StudentTermId=4,StudentId =533909,Term=4,TermName =" Fall 2020 ",TermAbbrev =" F20 " },
                new StudentTerm {StudentTermId=5,StudentId =533909,Term=5,TermName =" Spring 2021 ",TermAbbrev =" SP21 " },
                new StudentTerm {StudentTermId=1,StudentId =533570,Term=1,TermName =" Fall 2017 ",TermAbbrev =" F17 " },
                new StudentTerm {StudentTermId=2,StudentId =533570,Term=2,TermName =" Spring 2018 ",TermAbbrev =" SP18 " },
                new StudentTerm {StudentTermId=3,StudentId =533570,Term=3,TermName =" Summer 2018 ",TermAbbrev =" SU18 " },
                new StudentTerm {StudentTermId=4,StudentId =533570,Term=4,TermName =" Fall 2018 ",TermAbbrev =" F18 " },
                new StudentTerm {StudentTermId=5,StudentId =533570,Term=5,TermName =" Spring 2019 ",TermAbbrev =" SP19 " },
                new StudentTerm {StudentTermId=1,StudentId =531372,Term=1,TermName =" Fall 2018 ",TermAbbrev =" F18 " },
                new StudentTerm {StudentTermId=2,StudentId =531372,Term=2,TermName =" Spring 2019 ",TermAbbrev =" SP19 " },
                new StudentTerm {StudentTermId=3,StudentId =531372,Term=3,TermName =" Summer 2019 ",TermAbbrev =" SU19 " },
                new StudentTerm {StudentTermId=4,StudentId =531372,Term=4,TermName =" Fall 2019 ",TermAbbrev =" F19 " },
                new StudentTerm {StudentTermId=5,StudentId =531372,Term=5,TermName =" Spring 2020 ",TermAbbrev =" SP20 " },


              };
            Console.WriteLine($"Inserted {studentTerm.Length} new StudentTerm");
            foreach (StudentTerm st in studentTerm)
            {
                context.StudentTerms.Add(st);
            }
            context.SaveChanges();

        }
    }
}
