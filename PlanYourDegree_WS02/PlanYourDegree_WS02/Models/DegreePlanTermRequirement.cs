using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree_WS02.Models
{
    public class DegreePlanTermRequirement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DegreePlanTermRequirementId { get; set; }

        [ForeignKey("DegreePlanId")]
        public int DegreePlanID { get; set; }


        public int TermID { get; set; }

        [ForeignKey("RequirementId")]
        public int RequirementID { get; set; }

        public DegreePlan DegreePlan { get; set; }
        public Requirement Requirement { get; set; }

        public StudentTerm StudentTerm { get; set; }
    }
}
