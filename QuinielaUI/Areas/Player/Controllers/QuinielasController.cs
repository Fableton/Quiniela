using Entities;
using Microsoft.AspNetCore.Mvc;
using QuinielaUI.Areas.Admin.Controllers;
using QuinielaUI.Areas.Player.Models;
using QuinielaUI.Models;
using Respository;
using System.Text.RegularExpressions;

namespace QuinielaUI.Areas.Player.Controllers
{
    [Area("Player")]
    public class QuinielasController : Controller
    {
        private readonly ILogger<QuinielasController> _logger;
        private readonly QuinielaContext _quinielaContext;

        public QuinielasController(ILogger<QuinielasController> logger, QuinielaContext quinielaContext)
        {
            _logger = logger;
            _quinielaContext = quinielaContext;
        }

        public bool Ended { get; private set; }

        [AuthenticationFilter()]
        public IActionResult Index()
        {
            int playerId = int.Parse(HttpContext.Response.Headers["playerId"].ToString());

            var quinielas2 = _quinielaContext.Quinielas.Where(q => q.StartDate <= DateTime.Now.AddDays(5)).ToList();

            List<QuinielaDTO> quinielas = _quinielaContext.Quinielas.Where(q => q.StartDate <= DateTime.Now.AddDays(5)).Select(q => new QuinielaDTO()
            {
                Id = q.Id,
                StartDate = q.StartDate,
                TournamentName = q.Tournament.Name,
                EndDate = q.EndDate,
                Ended = DateTime.Now > q.EndDate,
                NumberOfMatches = q.Matchs.Count(),
                Name = q.Name,
                MatchesResume = q.Matchs.Select(m =>
                    new MatchesResumeDTO()
                    {
                        Id = m.Id,
                        LocalId = m.LocalId,
                        LocalName = m.Local.Name,
                        VisitorId = m.VisitorId,
                        VisitorName = m.Visitor.Name,
                        LocalGoals = m.LocalGoals,
                        VisitorGoals = m.VisitorGoals,
                        Date = m.Date,
                        Ended = m.Ended
                    }).ToList()
            }).ToList();

            quinielas.ForEach(q =>
            {
                q.Hits = 0;
                q.MatchesResume.ForEach(mr =>
                {
                    PlayerGameResult playerMatchResult = _quinielaContext.PlayerGameResult.FirstOrDefault(pgr => pgr.PlayerId == playerId && pgr.MatchId == mr.Id);
                    if (playerMatchResult != null)
                    {
                        mr.PlayerResult = playerMatchResult.Result;
                    }
                    if (mr.IsHit())
                    {
                        q.Hits += 1;
                    }
                });
            });

            quinielas = quinielas.OrderBy(q => q.Ended).ThenBy(q => q.EndDate).ToList();
            return View(quinielas);
        }

        [AuthenticationFilter()]
        public IActionResult Edit(int quinielaId)
        {
            int playerId = int.Parse(HttpContext.Response.Headers["playerId"].ToString());

            Quiniela quiniela = _quinielaContext.Quinielas.Find(quinielaId);
            QuinielaDTO model = null;
            if (quiniela != null)
            {

                model = new QuinielaDTO()
                {
                    Id = quiniela.Id,
                    Name = quiniela.Name,
                    TournamentName = quiniela.Tournament.Name,
                    EndDate = quiniela.EndDate,
                    Ended = DateTime.Now > quiniela.EndDate,
                    StartDate = quiniela.StartDate,
                    MatchesResume = new List<MatchesResumeDTO>()
                };

                foreach (Entities.Match match in quiniela.Matchs)
                {
                    PlayerGameResult playerMatchResult = _quinielaContext.PlayerGameResult.FirstOrDefault(pmr => pmr.PlayerId == playerId && pmr.MatchId == match.Id);

                    model.MatchesResume.Add(new MatchesResumeDTO()
                    {
                        Id = match.Id,
                        Group = match.Group,
                        LocalId = match.LocalId,
                        LocalGoals = match.LocalGoals,
                        LocalName = match.Local.Name,
                        Date = match.Date,
                        Ended = match.Ended,
                        VisitorId = match.VisitorId,
                        VisitorGoals = match.VisitorGoals,
                        VisitorName = match.Visitor.Name,
                        CanDraw = match.CanDraw,
                        PlayerResult = playerMatchResult != null ? playerMatchResult.Result : null
                    });
                }
            }

            return View(model);
        }

        [AuthenticationFilter()]
        [HttpPost]
        public IActionResult SaveResult(int matchId, int result)
        {
            int playerId = int.Parse(HttpContext.Response.Headers["playerId"].ToString());

            Entities.Match matchGame = _quinielaContext.Matchs.Find(matchId);

            if (matchGame != null)
            {
                if (matchGame.Quiniela.EndDate > DateTime.Now)
                {
                    PlayerGameResult playerMatchResult = _quinielaContext.PlayerGameResult.FirstOrDefault(pgr => pgr.MatchId == matchId && playerId == playerId);

                    if (playerMatchResult == null)
                    {
                        _quinielaContext.PlayerGameResult.Add(new PlayerGameResult()
                        {
                            PlayerId = playerId,
                            MatchId = matchId,
                            QuestionId = null,
                            Result = result
                        });
                    }
                    else
                    {
                        playerMatchResult.Result = result;
                    }
                    _quinielaContext.SaveChanges();
                }
            }
            return Ok();
        }
    }
}
