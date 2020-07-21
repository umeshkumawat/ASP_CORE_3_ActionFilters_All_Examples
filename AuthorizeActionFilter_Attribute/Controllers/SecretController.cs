using AuthorizeActionFilter_Attribute.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizeActionFilter_Attribute.Controllers
{
    [CustomAuthorizeFilter(Permissions = "can.read")]
    public class SecretController : ControllerBase
    {
        public IActionResult CheckAuthorization()
        {
            return Ok("Hello");
        }
    }
}
