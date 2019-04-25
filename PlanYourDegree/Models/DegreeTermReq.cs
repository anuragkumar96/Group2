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
        [MaxLength(20)]
        public int DegreeTermReqId { get; set; }
        [Required]
        [ForeignKey("DegreePlan")]
       public int DegreePlanId { get; set; }
        [Required]
        [ForeignKey("Term")]
        public int TermId { get; set; }
        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public DegreePlan DegreePlan { get; set; }
        public Course Course { get; set; }
        public Term Term { get; set; }
       // public StudentTerm StudentTerm { get; set; }

        //public ICollection<DegreePlan> DegreePlans { get; set; }
       // public ICollection<StudentTerm> StudentTerms { get; set; }
        //public ICollection<Course> Courses { get; set; }



    }
}
