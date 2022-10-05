using System.ComponentModel.DataAnnotations.Schema;

namespace QuinielaUI.Models
{
    public class MatchGame
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public int? Result { get; set; }
        public int VisitorGoals { get; set; }
        public int LocalGoals { get; set; }
        public Team Visitor { get; set; }
        public Team Local { get; set; }
    }
}
