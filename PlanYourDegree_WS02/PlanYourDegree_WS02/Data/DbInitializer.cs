using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanYourDegree_WS02.Models;

namespace PlanYourDegree_WS02.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any Degrees.
            if (context.Degrees.Any())
            {
                Console.WriteLine("Degrees already exist.");
            }
            else
            {


                var degrees = new Degree[]
                {
                new Degree{DegreeId = 1 , DegreeAbrrev =  "ACS+2", DegreeName = "MS ACS +2" },
                new Degree{DegreeId = 2 , DegreeAbrrev =  "ACS+DB", DegreeName = "MS ACS + DB"},
                new Degree{DegreeId = 3 , DegreeAbrrev =  "ACS+NF", DegreeName = "MS ACS+  NF"},
                new Degree{DegreeId = 4 , DegreeAbrrev =  "ACS", DegreeName = "MS ACS"}

                };

                Console.WriteLine($"Inserted {degrees.Length} new degrees.");


                foreach (Degree d in degrees)
                {
                    context.Degrees.Add(d);
                }
                context.SaveChanges();
            }



            if (context.Requirements.Any())
            {
                Console.WriteLine("Requirements already exist.");
            }
            else
            {
                var requirements = new Requirement[]
                {


                new Requirement{ RequirementID = 460 , DegreeId = 2 ,RequirementAbbrev = "DB" , CourseName = "44-460 Database"},
                new Requirement{ RequirementID = 356 , DegreeId = 2 ,RequirementAbbrev = "NF", CourseName = "44-356 Network Fundamentals"},
                new Requirement{ RequirementID = 542 , DegreeId = 2 ,RequirementAbbrev = "OOP" , CourseName = "44-542 Object Oriented Programming"},
                new Requirement{ RequirementID = 563 , DegreeId = 2 ,RequirementAbbrev = "Web apps" , CourseName = "44-563 Web apps"},
                new Requirement{ RequirementID = 560 , DegreeId = 2 ,RequirementAbbrev = "ADB" , CourseName = "44-560 Advance Database topics"},
                new Requirement{ RequirementID = 555 , DegreeId = 2 ,RequirementAbbrev = "NS" , CourseName = "44-555 Network Security"},
                new Requirement{ RequirementID = 618 , DegreeId = 2 ,RequirementAbbrev = "PM" , CourseName = "44-618 Project Management"},
                new Requirement{ RequirementID = 1 , DegreeId = 2 ,RequirementAbbrev = "MC" , CourseName = "Mobile Computing ios"},
                new Requirement{ RequirementID = 664 , DegreeId = 2 ,RequirementAbbrev = "UXD" , CourseName = "44-664  User Experience Design"},
                new Requirement{ RequirementID = 10 , DegreeId = 2 ,RequirementAbbrev = "E1" , CourseName = "Elective 1"},
                new Requirement{ RequirementID = 20 , DegreeId = 2 ,RequirementAbbrev = "E2" , CourseName = "Elective 2"},
                new Requirement{ RequirementID = 691 , DegreeId = 2 ,RequirementAbbrev = "GDP1" , CourseName = "GDP1"},
                new Requirement{ RequirementID = 692 , DegreeId = 2 ,RequirementAbbrev = "GDP2" , CourseName = "GDP2"}

};
                Console.WriteLine($"Inserted {requirements.Length} new reuirements.");
                foreach (Requirement d in requirements)
                {
                    context.Requirements.Add(d);
                }
                context.SaveChanges();
            }

            if (context.Students.Any())
            {
                Console.WriteLine("Students already exist.");
            }
            else
            {
                var student = new Student[]
                {
new Student{ StudentId = 528116 , First = "Nilantha" , Last = "Dambadeniya" , Snumber = "S528116" , catpawsnum = 919550040},
new Student{ StudentId = 530473 , First = "Ujjawal" , Last = "Kumar" , Snumber = "S530473" , catpawsnum = 919568987},
new Student{ StudentId = 533909 , First = "Meghana" , Last = "Pittu" , Snumber = "S533909" , catpawsnum = 919570037},
new Student{ StudentId = 533570 , First = "Keerthi sree" , Last = "Kukunoor" , Snumber = "S533570" , catpawsnum = 919569706},
new Student{ StudentId = 531372 , First = "Anurag" , Last = "Kumar" , Snumber = "S531372" , catpawsnum = 919533437}



                };


                Console.WriteLine($"Inserted {student.Length} new student.");
                foreach (Student d in student)
                {
                    context.Students.Add(d);
                }
                context.SaveChanges();
            }

            if (context.DegreePlans.Any())
            {
                Console.WriteLine("Degree Plans already exist.");
            }
            else
            {
                var degreeplan = new DegreePlan[]
                {
new DegreePlan{ DegreePlanId = 10 ,  DegreeID = 2 ,  StudentID = 528116 , DegreePlanAbbrev = "Express" , DegreePlanName = "Finish Degree ASAP"},
new DegreePlan{ DegreePlanId = 11 ,  DegreeID = 2 ,  StudentID = 528116 , DegreePlanAbbrev = "Economy" , DegreePlanName = "Finish Degree economically"},
new DegreePlan{ DegreePlanId = 12 ,  DegreeID = 2 ,  StudentID = 530473 , DegreePlanAbbrev = "Express" , DegreePlanName = "Finish Degree ASAP"},
new DegreePlan{ DegreePlanId = 13 ,  DegreeID = 2 ,  StudentID = 530473 , DegreePlanAbbrev = "Economy" , DegreePlanName = "Finish Degree economically"},
new DegreePlan{ DegreePlanId = 14 ,  DegreeID = 2 ,  StudentID = 533909 , DegreePlanAbbrev = "Economy" , DegreePlanName = "Finish Degree economically"},
new DegreePlan{ DegreePlanId = 15 ,  DegreeID = 2 ,  StudentID = 533909 , DegreePlanAbbrev = "Express" , DegreePlanName = "Finish Degree ASAP"},
new DegreePlan{ DegreePlanId = 16 ,  DegreeID = 2 ,  StudentID = 533570 , DegreePlanAbbrev = "Express" , DegreePlanName = "Finish Degree ASAP"},
new DegreePlan{ DegreePlanId = 17 ,  DegreeID = 2 ,  StudentID = 533570 , DegreePlanAbbrev = "Economy" , DegreePlanName = "Finish Degree economically"},
new DegreePlan{ DegreePlanId = 18 ,  DegreeID = 2 ,  StudentID = 531372 , DegreePlanAbbrev = "Economy" , DegreePlanName = "Finish Degree economically"},
new DegreePlan{ DegreePlanId = 19 ,  DegreeID = 2 ,  StudentID = 531372 , DegreePlanAbbrev = "Express" , DegreePlanName = "Finish Degree ASAP"}

                };
                Console.WriteLine($"Inserted {degreeplan.Length} new degree plans.");
                foreach (DegreePlan d in degreeplan)
                {
                    context.DegreePlans.Add(d);
                }
                context.SaveChanges();
            }

            if (context.DegreePlanTermRequirements.Any())
            {
                Console.WriteLine("DegreePlan Term Requirements already exist.");
            }
            else
            {
                var degreeplantermrequirement = new DegreePlanTermRequirement[]
                {
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 1 ,  DegreePlanID = 10 , TermID =  1 , RequirementID = 560},
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 2 ,  DegreePlanID = 10 , TermID =  1 , RequirementID = 356},
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 3 ,  DegreePlanID = 10 , TermID =  1 , RequirementID = 542},
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 4 ,  DegreePlanID = 10 , TermID =  1 , RequirementID = 563},
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 5 ,  DegreePlanID = 10 , TermID =  2 , RequirementID = 664},
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 6 ,  DegreePlanID = 10 , TermID =  2 , RequirementID = 1},
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 7 ,  DegreePlanID = 10 , TermID =  2 , RequirementID = 10},
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 8 ,  DegreePlanID = 10 , TermID =  3 , RequirementID = 618},
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 9 ,  DegreePlanID = 10 , TermID =  3 , RequirementID = 691},
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 10 ,  DegreePlanID = 10 , TermID =  4 , RequirementID = 555},
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 11 ,  DegreePlanID = 10 , TermID =  4 , RequirementID = 20},
new DegreePlanTermRequirement{ DegreePlanTermRequirementId = 12 ,  DegreePlanID = 10 , TermID =  4 , RequirementID = 692}
};
                Console.WriteLine($"Inserted {degreeplantermrequirement.Length} new student terms.");
                foreach (DegreePlanTermRequirement d in degreeplantermrequirement)
                {
                    context.DegreePlanTermRequirements.Add(d);
                }
                context.SaveChanges();
            }


            if (context.DegreeRequirements.Any())
            {
                Console.WriteLine("Degree Requirements already exist.");
            }
            else
            {
                var degreerequirement = new DegreeRequirement[]
                {
                     new DegreeRequirement{DegreeRequirementId = 1 ,  DegreeId = 2 , RequirementId = 356},
 new DegreeRequirement{DegreeRequirementId = 2 ,  DegreeId = 2 , RequirementId = 542},
 new DegreeRequirement{DegreeRequirementId = 3 ,  DegreeId = 2 , RequirementId = 563},
 new DegreeRequirement{DegreeRequirementId = 4 ,  DegreeId = 2 , RequirementId = 560},
 new DegreeRequirement{DegreeRequirementId = 5 ,  DegreeId = 2 , RequirementId = 555},
 new DegreeRequirement{DegreeRequirementId = 6 ,  DegreeId = 2 , RequirementId = 618},
 new DegreeRequirement{DegreeRequirementId = 7 ,  DegreeId = 2 , RequirementId = 1},
 new DegreeRequirement{DegreeRequirementId = 8 ,  DegreeId = 2 , RequirementId = 664},
 new DegreeRequirement{DegreeRequirementId = 9 ,  DegreeId = 2 , RequirementId = 10},
 new DegreeRequirement{DegreeRequirementId = 10 ,  DegreeId = 2 , RequirementId = 20},
 new DegreeRequirement{DegreeRequirementId = 11 ,  DegreeId = 2 , RequirementId = 691},
 new DegreeRequirement{DegreeRequirementId = 12 ,  DegreeId = 2 , RequirementId = 692}
 };
                Console.WriteLine($"Inserted { degreerequirement.Length} new student terms.");
                foreach (DegreeRequirement d in degreerequirement)
                {
                    context.DegreeRequirements.Add(d);
                }
                context.SaveChanges();
            }




            if (context.StudentTerms.Any())
            {
                Console.WriteLine("Student Terms already exist.");
            }
            else
            {
                var studentterm = new StudentTerm[]
                {
                     new StudentTerm { StudentTermId = 1 ,  Term = 1 , TermLabel = "Fall 2017" , DegreePlanId = 10},
 new StudentTerm { StudentTermId = 2 ,  Term = 2 , TermLabel = "Spring 2018" , DegreePlanId = 10},
 new StudentTerm { StudentTermId = 3 ,  Term = 3 , TermLabel = "Summer 2018" , DegreePlanId = 10},
 new StudentTerm { StudentTermId = 4 ,  Term = 4 , TermLabel = "Fall 2018" , DegreePlanId = 10},
 new StudentTerm { StudentTermId = 5 ,  Term = 1 , TermLabel = "Spring 2018" , DegreePlanId = 12},
 new StudentTerm { StudentTermId = 6 , Term = 2 , TermLabel = "Summer 2018" , DegreePlanId = 12},
 new StudentTerm { StudentTermId = 7 ,  Term = 3 , TermLabel = "Fall 2018" , DegreePlanId = 12},
 new StudentTerm { StudentTermId = 8 ,  Term = 4 , TermLabel = "Spring 2019" , DegreePlanId = 12},
 new StudentTerm { StudentTermId = 9 ,  Term = 1 , TermLabel = "Spring 2018" , DegreePlanId = 14},
 new StudentTerm { StudentTermId = 10 ,  Term = 2 , TermLabel = "Summer 2018" , DegreePlanId = 14},
 new StudentTerm { StudentTermId = 11 ,  Term = 3 , TermLabel = "Fall 2018" , DegreePlanId = 14},
 new StudentTerm { StudentTermId = 12 ,  Term = 4 , TermLabel = "Spring 2019" , DegreePlanId = 14},
 new StudentTerm { StudentTermId = 13 ,  Term = 5 , TermLabel = "Summer 2019" , DegreePlanId = 14},
 new StudentTerm { StudentTermId = 14 ,  Term = 6 , TermLabel = "Fall 2019" , DegreePlanId = 14},
 new StudentTerm { StudentTermId = 15 , Term = 1 , TermLabel = "Fall 2018" , DegreePlanId = 16},
 new StudentTerm { StudentTermId = 16 ,  Term = 2 , TermLabel = "Spring 2019" , DegreePlanId = 16},
 new StudentTerm { StudentTermId = 17 , Term = 3 , TermLabel = "Summer 2019" , DegreePlanId = 16},
 new StudentTerm { StudentTermId = 18 ,  Term = 4 , TermLabel = "Fall 2019" , DegreePlanId = 16},
 new StudentTerm { StudentTermId = 19 ,  Term = 1 , TermLabel = "Fall2018" , DegreePlanId = 18},
 new StudentTerm { StudentTermId = 20 ,  Term = 2 , TermLabel = "Spring2019" , DegreePlanId = 18},
 new StudentTerm { StudentTermId = 21 ,  Term = 3 , TermLabel = "Summer 2019" , DegreePlanId = 18},
 new StudentTerm { StudentTermId = 22 ,  Term = 4 , TermLabel = "Fall2019" , DegreePlanId = 18},
 new StudentTerm { StudentTermId = 23 ,  Term = 5 , TermLabel = "Spring 2020" , DegreePlanId = 18},
 new StudentTerm { StudentTermId = 24 , Term = 6 , TermLabel = "Summer 2020" , DegreePlanId = 18}


                };
                Console.WriteLine($"Inserted {studentterm.Length} new student terms.");
                foreach (StudentTerm d in studentterm)
                {
                    context.StudentTerms.Add(d);
                }
                context.SaveChanges();




            }
        }
    }
}

