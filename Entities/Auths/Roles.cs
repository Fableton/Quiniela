using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Auths
{
    public class Rol
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public bool IsRoot { get; set; }

        public virtual IEnumerable<Activity> Activities { get; set; }

        public virtual IEnumerable<Player> Players { get; set; }
    }
}
