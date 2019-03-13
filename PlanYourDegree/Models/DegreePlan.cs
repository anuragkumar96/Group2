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
        [ForeignKey("Degree")]
        public int DegreeId { get; set; }
        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(20)]
        public String DegreePlanAbbreve { get; set; }
        [MaxLength(50)]
        public String DegreePlanName { get; set; }

        public Degree Degree { get; set; }
        public Student Student { get; set; }

        public ICollection<DegreeTermReq> DegreeTermReqs { get; set; }

      //  public ICollection<Degree> Degrees { get; set; }
      //  public ICollection<Student> Students { get; set; }


    }
}

