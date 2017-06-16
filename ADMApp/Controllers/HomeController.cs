using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text;

namespace ADMApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            StringBuilder sb = new StringBuilder("Claims Values are: ");
            int i = 0;
            foreach (var claim in this.User.Claims) {
                sb.Append("<br />");
                sb.Append(claim);
                i++;
            }

            ViewData["ClaimData"] = sb.ToString();
            ViewData["ClaimCounter"] = i;
            ClaimsPrincipal claimsUser = (ClaimsPrincipal)this.User;
            ViewData["Sid"] = claimsUser.FindFirst(ClaimTypes.Sid);
            ViewData["Name"] = claimsUser.FindFirst(ClaimTypes.Name);
            ViewData["UserData"] = claimsUser.FindFirst(ClaimTypes.UserData);
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
