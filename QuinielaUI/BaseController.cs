using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuinielaUI.Controllers;
using Respository;

namespace QuinielaUI
{
    public class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;
        private readonly QuinielaContext _quinielaContext;

        public BaseController(ILogger<BaseController> logger, QuinielaContext quinielaContex)
        {
            _logger = logger;
            _quinielaContext = quinielaContex;
        }
    }
}
