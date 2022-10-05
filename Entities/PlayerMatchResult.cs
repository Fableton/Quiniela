using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PlayerMatchResult
    {
        public int PlayerId { get; set; }
        public int MatchGameId { get; set; }
        public int Result { get; set; }

        public virtual Player Player { get; set; }

        public virtual MatchGame MatchGame { get; set; }


    }
}
