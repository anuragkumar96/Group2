using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanYourDegree.Models
{
    public class Term
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TermId { get; set; }

        public string TermAbbrev { get; set; }
        public string TermName { get; set; }

        public ICollection<DegreeTermReq> DegreeTermReqs { get; set; }
    }
}
