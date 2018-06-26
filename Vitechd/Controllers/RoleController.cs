using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vitechd.Models;

namespace Vitechd.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Role
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);
        }
    }
}