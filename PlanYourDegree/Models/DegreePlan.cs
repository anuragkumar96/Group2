using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree.Models
{
    public class DegreePlan
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int DegreePlanId { get; set; }
        [Required]
        public int DegreeId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(20)]
        public String DegreePlanAbbreve { get; set; }
        [MaxLength(50)]
        public String DegreePlanName { get; set; }

        public ICollection<Degree> Degrees { get; set; }
        public ICollection<Student> Students { get; set; }


    }
}
