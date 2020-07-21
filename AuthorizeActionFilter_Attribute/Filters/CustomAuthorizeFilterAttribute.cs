using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizeActionFilter_Attribute.Filters
{
    public class CustomAuthorizeFilterAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public string Permissions { get; set; }
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {

            //  Authenticated user के सारे claims में से "Permission" वाला Claim निकालो।
            var claims = context.HttpContext.User.Claims.Where(claim => claim.Type == nameof(Permissions) && claim.Value == Permissions);

            if (claims == null)
                context.Result = new UnauthorizedResult();

            return Task.CompletedTask;
        }
    }
}
