using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree_WS02.Models
{
    public class DegreeRequirement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DegreeRequirementId { get; set; }

        [ForeignKey("DegreeId")]
        public int DegreeId { get; set; }

        [ForeignKey("RequirementId")]
        public int RequirementId { get; set; }

        public Degree Degree { get; set; }
        public Requirement Requirement { get; set; }
    }
}
