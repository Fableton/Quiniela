using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MatchGame> LocalGames { get; set; }
        public virtual ICollection<MatchGame> VisitorsGames { get; set; }
    }
}