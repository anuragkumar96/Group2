using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(10)]
        public string CourseAbbrev { get; set; }
        [Required]
        public string CourseName { get; set; }

        public ICollection<DegreeReq> DegreeReqs { get; set; }
        public ICollection<DegreeTermReq> DegreeTermReqs { get; set; }
        
    }
}
