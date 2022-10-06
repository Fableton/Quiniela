using Castle.Core.Internal;
using Entities;
using Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository;
using Respository;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;

namespace QuinielaUI
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        private readonly QuinielaContext _quinielaContext;
        private readonly string _activity;

        public AuthenticationFilter()
        {
        }

        public AuthenticationFilter(string activity)
        {
            _activity = activity;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userTokenParam = context.HttpContext.Request.Query["playerToken"].ToString();
            if (!userTokenParam.IsNullOrEmpty())
            {
                context.HttpContext.Response.Cookies.Append("userToken", userTokenParam);
            }
            else
            {
                userTokenParam = context.HttpContext.Request.Cookies["userToken"];
            }

            HelperJWT helper = new HelperJWT();
            int? playerId = helper.ValidateToken(userTokenParam);
            bool isValid = false;
            if (playerId.HasValue)
            {
                var _quinielaContext = context.HttpContext.RequestServices.GetRequiredService<QuinielaContext>();

                Player player = _quinielaContext.Players.Find(playerId);
                if (player != null)
                {
                    string[] activities = player.Rols.SelectMany(r => r.Activities.Select(a => a.Id)).Distinct().ToArray();
                    context.HttpContext.User = new CustomClaimsPrincipal(new IdentityCustom(player.Id, player.Name), activities);
                    isValid = context.HttpContext.User.IsInRole(_activity);
                }

                if (isValid)
                {
                    context.HttpContext.Response.Headers.Add("playerId", playerId.ToString());
                }
            }

            if (!isValid)
            {
                if (context.HttpContext.Request != null)
                {
                    context.Result = new RedirectToRouteResult(
                                        new RouteValueDictionary
                                            {
                                                {"area","" },
                                                { "action", "Unauthorized" },
                                                { "controller", "Error" }
                                            }
                                        );
                }
            }

            return;
        }
    }
}
