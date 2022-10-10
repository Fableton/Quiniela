using Entities;
using Microsoft.AspNetCore.Mvc;
using QuinielaUI.Areas.Scores.Models;
using Respository;
using MatchGame = Entities.MatchGame;

namespace QuinielaUI.Areas.Scores.Controllers
{
    [Area("Scores")]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly QuinielaContext _quinielaContext;

        public DashboardController(ILogger<DashboardController> logger, QuinielaContext quinielaContext)
        {
            _logger = logger;
            _quinielaContext = quinielaContext;
        }

        public bool Ended { get; private set; }

        [AuthenticationFilter()]
        public IActionResult ActualMatches()
        {
            int playerId = int.Parse(HttpContext.Response.Headers["playerId"].ToString());

            List<Match> matches = new List<Match>();
            List<MatchGame> matchGames = _quinielaContext.Games.Where(g =>
            g.Date.Date >= DateTime.Now.Date.AddDays(-1)
            && g.Date.Date <= DateTime.Now.Date.AddDays(1)).ToList();
            foreach (MatchGame matchGame in matchGames)
            {
                bool? isWining = null;
                PlayerMatchResult playerMatchResult = _quinielaContext.PlayerMatchResult.Find(playerId, matchGame.Id);
                int? playerResult = playerMatchResult == null ? null : playerMatchResult.Result;

                if (playerResult != null)
                {
                    if (matchGame.LocalGoals == matchGame.VisitorGoals && matchGame.CanDraw)
                    {
                        isWining = playerResult == 3;
                    }
                    else if (matchGame.LocalGoals > matchGame.VisitorGoals)
                    {
                        isWining = playerResult == 1;
                    }
                    else if (matchGame.VisitorGoals > matchGame.LocalGoals)
                    {
                        isWining = playerResult == 2;
                    }
                }

                matches.Add(new Match()
                {
                    MatchId = matchGame.Id,
                    LocalID = matchGame.LocalId,
                    LocalGoals = matchGame.LocalGoals,
                    Ended = matchGame.Ended,
                    LocalName = matchGame.Local.Name,
                    StartDate = matchGame.Date,
                    VisitorGoals = matchGame.VisitorGoals,
                    VisitorID = matchGame.VisitorId,
                    VisitorName = matchGame.Visitor.Name,
                    PlayerResult = playerResult,
                    IsWining = isWining,
                });
            }

            return PartialView("_ActualMatches", matches.OrderBy(m => m.Ended).ThenBy(m => m.StartDate).ToList());
        }
    }
}
