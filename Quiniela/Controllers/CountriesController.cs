using DTOs;
using Microsoft.AspNetCore.Mvc;
using Respository;

namespace Quiniela.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Countries : ControllerBase
    {
        QuinielaContext _QuinielaContext;

        private readonly ILogger<Countries> _logger;

        public Countries(ILogger<Countries> logger, QuinielaContext quinielaContext)
        {
            _logger = logger;
            _QuinielaContext = quinielaContext;
        }

        [HttpGet]
        public IEnumerable<CountryDTO> Get()
        {
            List<CountryDTO> countries = _QuinielaContext.Countries.Select(c => new CountryDTO() { Id = c.Id, Name = c.Name }).ToList();

            return countries;
        }
    }
}