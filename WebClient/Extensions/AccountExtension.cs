using System.Collections.Generic;
using System.Security.Claims;
using WebDAL.Entities;

namespace WebClient.Extensions
{
    public static class AccountExtension
    {
        public static ClaimsPrincipal ToClaimsPrincipal(this Account account, string authScheme)
        {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, account.name),
                new(ClaimTypes.Role, account.role)
            };
            var claimsIdentity = new ClaimsIdentity(claims, authScheme);
            
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}