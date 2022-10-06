using System.ComponentModel.DataAnnotations.Schema;

namespace QuinielaUI.Areas.Player.Models
{
    public class MatchGame
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public int? Result { get; set; }
        public int VisitorGoals { get; set; }
        public int LocalGoals { get; set; }
    }
}
