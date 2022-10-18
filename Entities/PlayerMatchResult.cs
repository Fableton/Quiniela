using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PlayerMatchResult
    {
        public int PlayerId { get; set; }
        public int MatchGameId { get; set; }
        /// <summary>
        /// 1 - LocalWin
        /// 2 - VisitorWin
        /// 3 - Draw
        /// </summary>
        public int Result { get; set; }

        public virtual Player Player { get; set; }

        public virtual MatchGame MatchGame { get; set; }

        [NotMapped]
        public bool IsWin
        {
            get
            {
                bool isWin = false;

                if (this.MatchGame.LocalGoals == this.MatchGame.VisitorGoals && this.MatchGame.CanDraw)
                {
                    isWin = this.Result == 3;
                }
                else if (this.MatchGame.LocalGoals > this.MatchGame.VisitorGoals)
                {
                    isWin = this.Result == 1;
                }
                else if (this.MatchGame.VisitorGoals > this.MatchGame.LocalGoals)
                {
                    isWin = this.Result == 2;
                }

                return isWin;
            }
        }

    }
}
