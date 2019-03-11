using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree.Models
{
    public class StudentTerm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int StudentTermId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int Term { get; set; }
        [Required]
        [MaxLength(20)]
        public String TermName { get; set; }
        [Required]
        [MaxLength(10)]
        public String TermAbbrev { get; set; }

        public ICollection<Student> Students { get; set; }



    }
}
