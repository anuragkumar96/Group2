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
            if (context.Degrees.Any())
            {
                Console.WriteLine("Degrees already exist.");
            }
            else
            {
                var degrees = new Degree[]
                {
                    new Degree{DegreeID = 1, DegreeAbbrive = "ACS+2", DegreeName = "MS ACS+2"},
                    new Degree{DegreeID = 2, DegreeAbbrive = "ACS+DB", DegreeName = "MS ACS+DB"},
                    new Degree{DegreeID = 3, DegreeAbbrive = "ACS+NF", DegreeName = "MS ACS+NF"},
                    new Degree{DegreeID = 4, DegreeAbbrive = "ACS", DegreeName = "MS ACS"},
                };
                Console.WriteLine($"Inserted {degrees.Length} new degrees");
                foreach(Degree d in degrees)
                {
                    context.Degrees.Add(d);
                }
                context.SaveChanges();
            }
        }
    }
}
