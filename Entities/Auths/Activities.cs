using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Auths
{
    public class Activity
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Rol> Rols { get; set; }

    }
}
