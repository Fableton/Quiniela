using Entities;
using Microsoft.AspNetCore.Mvc;
using QuinielaUI.Areas.Scores.Models;
using Respository;
using System.Linq;

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


        [AuthenticationFilter()]
        public IActionResult ActualMatches()
        {
            int playerId = int.Parse(HttpContext.Response.Headers["playerId"].ToString());

            List<MatchDTO> matches = new List<MatchDTO>();
            List<Match> matchGames = _quinielaContext.Matchs.Where(g =>
            g.Date.Date >= DateTime.Now.Date.AddDays(-1)
            && g.Date.Date <= DateTime.Now.Date.AddDays(1)).ToList();
            foreach (Match matchGame in matchGames)
            {
                bool? isWining = null;
                PlayerGameResult playerMatchResult = _quinielaContext.PlayerGameResult.Find(playerId, matchGame.Id);
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

                matches.Add(new MatchDTO()
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

        [AuthenticationFilter()]
        public IActionResult BestStats()
        {
            List<PlayerStats> playerStats = new List<PlayerStats>();

            List<Quiniela> quinielas = _quinielaContext.Quinielas.Where(q => q.Matchs.Any(m => m.Ended)).ToList();

            foreach (Quiniela quiniela in quinielas)
            {
                List<PlayerGameResult> query = _quinielaContext.PlayerGameResult.Where(pmr => pmr.Match.Ended && pmr.Match.QuinielaId == quiniela.Id).ToList().Where(pmr => pmr.IsWin).ToList();
                var group = query.GroupBy(i => new { i.Match.QuinielaId, i.PlayerId }).OrderByDescending(g => g.Sum(i => i.IsWin ? 1 : 0)).Take(10).ToList();

                foreach (var item in group)
                {
                    int playerId = item.Key.PlayerId;
                    PlayerStats player = playerStats.FirstOrDefault(p => p.Id == playerId);
                    if (player == null)
                    {
                        int wins = _quinielaContext.PlayerGameResult.Where(pm => pm.PlayerId == playerId && pm.Match.Ended).ToList().Where(pm => pm.IsWin).Count();
                        player = new PlayerStats()
                        {
                            Id = playerId,
                            PlayerName = item.First().Player.Name,
                            QuinielasWin = 1,
                            MatchsWins = wins
                        };
                        playerStats.Add(player);
                    }
                    else
                    {
                        player.QuinielasWin = player.QuinielasWin + 1;
                    }
                }

            }

            List<PlayerStats> top10 = playerStats.OrderByDescending(p => p.QuinielasWin).ThenByDescending(p => p.MatchsWins).Take(100).ToList();

            return PartialView("_BestStats", top10);
        }
    }
}
