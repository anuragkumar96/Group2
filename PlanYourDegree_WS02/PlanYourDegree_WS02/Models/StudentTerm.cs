using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree_WS02.Models
{
    public class StudentTerm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentTermId { get; set; }

        //[ForeignKey("StudentId")]
        //public int StudentID { get; set; }
        public int Term { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Abbreviation")]
        public string TermLabel { get; set; }
        public int DegreePlanId { get; set; }

        public bool Done { get; set; }

        public DegreePlan DegreePlan { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
        public ICollection<DegreePlanTermRequirement> DegreePlanTermRequirement { get; set; }
    }
}
