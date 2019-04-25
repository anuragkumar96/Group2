using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PlanYourDegree.Models
{
    public class DegreeReq
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [MaxLength(20)]
        public int DegreeReqId { get; set; }
        [Required]
        [ForeignKey("Degree")]
        public int DegreeId { get; set; }
        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [MaxLength(5)]
        public int RequirementNumber { get; set; }
        [MaxLength(60)]
        public String CourseName { get; set; }

        public Degree Degree { get; set; }
        public Course Course { get; set; }
       // public ICollection<Degree> Degrees { get; set;}
       // public ICollection<Course> Courses { get; set; }


    }
}
