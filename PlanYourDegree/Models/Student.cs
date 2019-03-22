using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Range(100000,999999)]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(20)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public String LastName { get; set; }
        [Required]        
        [Range(919000000, 919999999)]
        public int NineOneNine { get; set; }

        public ICollection<DegreePlan> DegreePlans { get; set; }
    }
}
