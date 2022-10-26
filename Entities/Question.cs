using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int QuinielaId { get; set; }

        public DateTime Date { get; set; }

        public string Group { get; set; }

        public string QuestionText { get; set; }

        public bool Ended { get; set; }

        [ForeignKey("QuinielaId")]
        public virtual Quiniela Quiniela { get; set; }

        public int Answer { get; set; }

        public virtual IEnumerable<PlayerGameResult> QuestionResults { get; set; }
    }
}
