namespace QuinielaUI.Models
{
    public class QuinielaPlayerResults
    {
        public string PlayerName { get; set; }
        public DateTime StartDate { get; set; }
        public List<MatchGame> Matches { get; set; }
    }
}
