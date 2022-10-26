using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PlayerGameResult
    {
        [Key]
        public int Id { get; set; }
        public int PlayerId { get; set; }

        public int? MatchId { get; set; }

        public int? QuestionId { get; set; }

        /// <summary>
        /// 1 - LocalWin
        /// 2 - VisitorWin
        /// 3 - Draw
        /// </summary>
        public int Result { get; set; }

        public virtual Player Player { get; set; }

        public virtual Match? Match { get; set; }

        public virtual Question? Question { get; set; }

        [NotMapped]
        public bool IsWin
        {
            get
            {
                bool isWin = false;
                if (this.MatchId != null)
                {
                    if (this.Match.LocalGoals == this.Match.VisitorGoals && this.Match.CanDraw)
                    {
                        isWin = this.Result == 3;
                    }
                    else if (this.Match.LocalGoals > this.Match.VisitorGoals)
                    {
                        isWin = this.Result == 1;
                    }
                    else if (this.Match.VisitorGoals > this.Match.LocalGoals)
                    {
                        isWin = this.Result == 2;
                    }
                }
                else if (this.QuestionId != null)
                {

                }

                return isWin;
            }
        }

    }
}
