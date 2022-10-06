using Respository;
using System.Security.Claims;
using System.Security.Policy;
using System.Security.Principal;
using static System.Net.Mime.MediaTypeNames;

namespace QuinielaUI
{
    public class CustomClaimsPrincipal : ClaimsPrincipal
    {
        private readonly string[] _roles;
        public CustomClaimsPrincipal(IIdentity identity, string[] roles) : base(identity)
        {
            _roles = roles;
        }

        public override bool IsInRole(string role)
        {
            return role == null || _roles.Contains(role); ;
        }
    }
    public class IdentityCustom : IIdentity
    {
        private int _userId;
        private string _userName;

        public IdentityCustom(int userId, string userName)
        {
            this._userId = userId;
            this._userName = userName;
        }
        public string? AuthenticationType => "CustomDataBase";

        public bool IsAuthenticated => _userId > 0;

        public string? Name => _userName;
    }
}
