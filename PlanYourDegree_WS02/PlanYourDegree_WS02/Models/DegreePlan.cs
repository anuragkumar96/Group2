using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree_WS02.Models
{
    public class DegreePlan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DegreePlanId { get; set; }

        [ForeignKey("DegreeId")]
        public int DegreeID { get; set; }

        [ForeignKey("StudentId")]
        public int StudentID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Abbreviation")]
        public string DegreePlanAbbrev { get; set; }


        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string DegreePlanName { get; set; }

        public bool Done { get; set; }

        public Degree Degree { get; set; }
        public Student Student { get; set; }
        public ICollection<StudentTerm> StudentTerms { get; set; }
        public ICollection<DegreePlanTermRequirement> DegreePlanTermRequirements { get; set; }
    }
}
