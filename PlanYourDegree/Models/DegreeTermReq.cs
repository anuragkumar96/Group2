using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree.Models
{
    public class DegreeTermReq
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int DegreeTermReqId { get; set; }
        [Required]
       public int DegreePlanId { get; set; }
        [Required]
        public int StudentTermId { get; set; }
        [Required]
        public int CourseId { get; set; }

        public ICollection<DegreePlan> DegreePlans { get; set; }
        public ICollection<Course> Courses { get; set; }
     public ICollection<StudentTerm> StudentTerms { get; set; }



    }
}
