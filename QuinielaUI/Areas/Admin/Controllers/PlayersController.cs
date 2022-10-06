using Castle.Core.Internal;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using QuinielaUI.Areas.Admin.Models;
using QuinielaUI.Models;
using Respository;

namespace QuinielaUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlayersController : Controller
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly QuinielaContext _quinielaContext;

        public PlayersController(ILogger<PlayersController> logger, QuinielaContext quinielaContext)
        {
            _logger = logger;
            _quinielaContext = quinielaContext;
        }

        [AuthenticationFilter("ViewAdminUsers")]
        public IActionResult Index()
        {
            List<PlayerDTO> players = _quinielaContext.Players.OrderBy(p => p.Name).Select(p => new PlayerDTO()
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
            return View(players);
        }

        [AuthenticationFilter("ViewAdminUsers")]
        [HttpGet]
        public IActionResult PlayersTable(int? newPlayerId)
        {
            List<PlayerDTO> players = _quinielaContext.Players.OrderBy(p => p.Name).Select(p => new PlayerDTO()
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            if (newPlayerId.HasValue)
            {
                PlayerDTO newPlayer = players.First(p => p.Id == newPlayerId);
                players.Remove(newPlayer);
                players = players.Prepend(newPlayer).ToList();
            }

            ViewBag.NewPLayerId = newPlayerId;
            return PartialView("_PlayersTable", players);
        }

        [AuthenticationFilter("AddAdminUsers")]
        [HttpPost]
        public JsonResult Add(string name)
        {
            name = name.Trim();
            ServiceResponse response = new ServiceResponse()
            {
                errors = new List<string>() { "UnhandedError" }
            };

            if (!name.IsNullOrEmpty())
            {
                Entities.Player player = _quinielaContext.Players.FirstOrDefault(p => p.Name == name);
                if (player == null)
                {
                    try
                    {
                        player = new Entities.Player()
                        {
                            Name = name,
                            Rols = _quinielaContext.Rols.Where(r => r.Id == "Player").ToList()
                        };

                        _quinielaContext.Players.Add(player);
                        _quinielaContext.SaveChanges();

                        response = new ServiceResponse()
                        {
                            data = new PlayerDTO()
                            {
                                Id = player.Id,
                                Name = player.Name
                            }
                        };
                    }
                    catch (Exception e)
                    {
                        this._logger.LogError("PlayersController Add", e);
                    }
                }
                else
                {
                    response = new ServiceResponse()
                    {
                        errors = new List<string>() { "AlreadyExist" }
                    };
                }
            }
            else
            {
                response = new ServiceResponse()
                {
                    errors = new List<string>() { "NameEmpty" }
                };
            }

            return new JsonResult(response);
        }


        [AuthenticationFilter("GenerateLinkAdminUsers")]
        [HttpGet]
        public JsonResult GenerateLink(int playerId)
        {
            ServiceResponse response = new ServiceResponse()
            {
                errors = new List<string>() { "UnhandedError" }
            };

            Entities.Player player = _quinielaContext.Players.Find(playerId);
            if (player != null)
            {
                HelperJWT helper = new HelperJWT();
                string token = helper.GenerateToken(player.Id);
                var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
                response = new ServiceResponse()
                {
                    data = baseUri + $"/?playerToken=" + token
                };
            }
            return new JsonResult(response);
        }
    }
}
