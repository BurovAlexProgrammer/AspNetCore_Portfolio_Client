using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WebClient.Constants
{
    public class PolicyNames
    {
        public const string User = "User";
        public const string Admin = "Admin";
    }

    public class Policies
    {
        public static readonly AuthorizationPolicy User = new AuthorizationPolicyBuilder(AuthSchemes.Cookie)
            .RequireClaim(ClaimTypes.Role, Roles.User)
            .Build();

        //Admin has combine roles
        public static readonly AuthorizationPolicy Admin = new AuthorizationPolicyBuilder(AuthSchemes.Cookie)
            .RequireAssertion(x => 
                x.User.HasClaim(ClaimTypes.Role, Roles.Admin) ||
                x.User.HasClaim(ClaimTypes.Role, Roles.User))
            .Build();
    }
}