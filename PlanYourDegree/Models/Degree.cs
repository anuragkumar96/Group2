using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree.Models
{
    public class Degree
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DegreeID { get; set; }
        [Required]
        [MaxLength(20)]
        public string DegreeAbbrive { get; set; }
        [Required]
        [MaxLength(40)]
        public string DegreeName { get; set; }
    }
}
