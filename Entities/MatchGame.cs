using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MatchGame
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int LocalGoals { get; set; }

        public int VisitorGoals { get; set; }

        public bool CanDraw { get; set; }

        public string VisitorId { get; set; }

        public string LocalId { get; set; }

        public string Group { get; set; }

        public int QuinielaId { get; set; }

        public bool Ended { get; set; }

        [ForeignKey("VisitorId")]
        public virtual Team Visitor { get; set; }
        [ForeignKey("LocalId")]
        public virtual Team Local { get; set; }

        [ForeignKey("QuinielaId")]
        public virtual Quiniela Quiniela { get; set; }

        public virtual IEnumerable<PlayerMatchResult> MatchResults { get; set; }
    }
}
