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
        [MaxLength(20)]
        public int TermId { get; set; }
        [MaxLength(20)]
        public string TermAbbrev { get; set; }
        [MaxLength(40)]
        public string TermName { get; set; }

        public ICollection<DegreeTermReq> DegreeTermReqs { get; set; }
    }
}
