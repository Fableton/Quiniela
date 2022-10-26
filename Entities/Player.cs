using Entities.Auths;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<PlayerGameResult> MatchResults { get; set; }

        [Required]
        public virtual IEnumerable<Rol> Rols { get; set; }
    }
}
