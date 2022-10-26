using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Quiniela
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TournamentId { get; set; }
        public virtual IEnumerable<Match> Matchs { get; set; }

        public virtual IEnumerable<Question> Questions { get; set; }

        public virtual Tournament Tournament { get; set; }

    }
}
