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
        public int DegreeReqId { get; set; }
        [Required]
        public int DegreeId { get; set; }
        [Required]
        public int CourseId { get; set; }

        public ICollection<Degree> Degrees { get; set; }
        public ICollection<Course> Courses { get; set; }


    }
}
