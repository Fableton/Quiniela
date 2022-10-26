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

        public virtual ICollection<Match> LocalMatchs { get; set; }
        public virtual ICollection<Match> VisitorMatchs { get; set; }
    }
}