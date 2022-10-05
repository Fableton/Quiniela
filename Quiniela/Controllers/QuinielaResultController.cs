using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Respository;

namespace Quiniela.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuinielaResultController : ControllerBase
    {
        QuinielaContext _QuinielaContext;

        private readonly ILogger<Countries> _logger;

        public QuinielaResultController(ILogger<Countries> logger, QuinielaContext quinielaContext)
        {
            _logger = logger;
            _QuinielaContext = quinielaContext;
        }

        [HttpPost]
        public IActionResult NewQuinielaResult(int playerId, int matchId, int result)
        {

            PlayerMatchResult playerMatchResult = _QuinielaContext.PlayerMatchResult.Find(playerId, matchId);

            if (playerMatchResult == null)
            {
                _QuinielaContext.PlayerMatchResult.Add(new PlayerMatchResult()
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

            _QuinielaContext.SaveChanges();

            return Ok();
        }
    }
}
