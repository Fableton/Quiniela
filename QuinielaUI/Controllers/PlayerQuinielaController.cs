using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuinielaUI.Models;
using Respository;
using System.Diagnostics;

namespace QuinielaUI.Controllers
{

    public class PlayerQuinielaController : Controller
    {
        private readonly ILogger<PlayerQuinielaController> _logger;
        private readonly QuinielaContext _quinielaContext;

        public PlayerQuinielaController(ILogger<PlayerQuinielaController> logger, QuinielaContext quinielaContext)
        {
            _logger = logger;
            _quinielaContext = quinielaContext;
        }

        [AuthenticationFilter("Index")]
        public IActionResult Index()
        {

            //DescencriptarToken
            //ViewBag.PlayerToken = playerToken;
            int playerId = int.Parse(HttpContext.Response.Headers["playerId"].ToString());

            Quiniela quiniela = _quinielaContext.Quinielas.Find(playerId);
            QuinielaPlayerResults model = new QuinielaPlayerResults();
            if (quiniela != null)
            {
                Player player = _quinielaContext.Players.Find(playerId);

                model.PlayerName = player.Name;
                model.StartDate = quiniela.StartDate;
                model.Matches = new List<QuinielaUI.Models.MatchGame>();
                foreach (Entities.MatchGame match in quiniela.Matches)
                {
                    Entities.PlayerMatchResult playerMatchResult = _quinielaContext.PlayerMatchResult.Find(player.Id, match.Id);
                    model.Matches.Add(new Models.MatchGame()
                    {
                        Id = match.Id,
                        Group = match.Group,
                        Local = new Models.Team() { Id = match.LocalId, Name = match.Local.Name },
                        Visitor = new Models.Team() { Id = match.VisitorId, Name = match.Visitor.Name },
                        LocalGoals = match.LocalGoals,
                        VisitorGoals = match.VisitorGoals,
                        Result = playerMatchResult?.Result
                    });
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveResult(int matchId, int result, string playerToken)
        {
            //DescencriptarToken
            ViewBag.PlayerToken = playerToken;
            int playerId = 1;

            PlayerMatchResult playerMatchResult = _quinielaContext.PlayerMatchResult.Find(playerId, matchId);

            if (playerMatchResult == null)
            {
                _quinielaContext.PlayerMatchResult.Add(new PlayerMatchResult()
                {
                    PlayerId = playerId,
                    MatchGameId = matchId,
                    Result = result
                });
            }
            else
            {
                playerMatchResult.Result = result;
            }

            _quinielaContext.SaveChanges();

            return Ok();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}