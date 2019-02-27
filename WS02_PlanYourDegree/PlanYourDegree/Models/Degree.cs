using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PlanYourDegree.Models
{
    public class Degree
    {
        public int DegreeID { get; set; }
        [Required]
        [MaxLength(20)]
        public string DegreeAbrev { get; set; }
        [Required]
        [MaxLength(40)]
        public string DegreeName { get; set; }
    }
}
