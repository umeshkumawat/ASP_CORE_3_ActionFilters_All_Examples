using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizeActionFilter_Attribute.Controllers
{
    public class AuthController : ControllerBase
    {
        public IActionResult Login()
        {
            // फर्जी login करेंगे user को।

            //Claims
            //Claims Identity
            //Claims Principle

            IEnumerable<Claim> claims = new List<Claim> 
            { 
                new Claim("Permissions", "can.read"),
                new Claim("Permissions", "can.write")
            };

            var claimIdentity = new ClaimsIdentity(claims, "auth test");

            var claimPrinciple = new ClaimsPrincipal(new[] { claimIdentity });

            HttpContext.SignInAsync(claimPrinciple);

            return RedirectToRoute(new { controller = "secret", action = "CheckAuthorization" });
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return Ok();
        }
    }
}
