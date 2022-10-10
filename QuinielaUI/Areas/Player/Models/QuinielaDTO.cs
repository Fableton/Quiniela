namespace QuinielaUI.Areas.Player.Models
{
    public class QuinielaDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string TournamentName { get; set; }
        public DateTime EndDate { get; set; }
        public bool Ended { get; set; }
        public int NumberOfMatches { get; set; }
        public int Hits { get; set; }
        public List<MatchesResumeDTO> MatchesResume { get; set; }
        public string Name { get; set; }
    }

    public class MatchesResumeDTO
    {
        public int Id { get; set; }
        public string LocalId { get; set; }
        public string LocalName { get; set; }
        public string VisitorId { get; set; }
        public string VisitorName { get; set; }
        public int LocalGoals { get; set; }
        public int VisitorGoals { get; set; }
        public int? PlayerResult { get; set; }

        public bool CanDraw { get; set; }

        public bool IsHit()
        {
            bool hit = false;
            if (this.Ended)
            {
                hit = (LocalGoals > VisitorGoals && PlayerResult == 1)
                    || (LocalGoals < VisitorGoals && PlayerResult == 2)
                    || (LocalGoals == VisitorGoals && PlayerResult == 3);
            }

            return hit;
        }
        public DateTime Date { get; set; }
        public bool Ended { get; set; }
        public string Group { get; set; }
    }
}
