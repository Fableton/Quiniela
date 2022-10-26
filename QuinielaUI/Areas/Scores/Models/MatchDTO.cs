namespace QuinielaUI.Areas.Scores.Models
{
    public class MatchDTO
    {
        public int MatchId { get; set; }
        public string LocalID { get; set; }
        public string VisitorID { get; set; }
        public string LocalName { get; set; }
        public string VisitorName { get; set; }
        public int LocalGoals { get; set; }
        public int VisitorGoals { get; set; }
        public int? PlayerResult { get; set; }
        public DateTime StartDate { get; set; }
        public bool Ended { get; set; }
        public bool? IsWining { get; set; }
    }
}
