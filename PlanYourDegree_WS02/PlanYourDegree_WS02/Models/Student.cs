using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree_WS02.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        [Display(Name = "Given")]
        public string First { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        [Display(Name = "Family")]
        public string Last { get; set; }

        public string Snumber { get; set; }
        public int catpawsnum { get; set; }
        public bool Done { get; set; }

        public ICollection<DegreePlan> DegreePlans { get; set; }
        public ICollection<StudentTerm> StudentTerms { get; set; }
    }
}
