using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vitechd.Models;

namespace Vitechd.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private ApplicationUserManager _userManager;
        public HomeController()
        {
        }

        public HomeController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Contacta con nosotros y podremos ayudarte en tus proyectos.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Contact(MailModels model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1}) Telefono: {3}</p><p>Message:</p><p>{2}</p>";
                var message = new IdentityMessage();
                message.Subject = "Contacto Web";
                message.Body = string.Format(body, model.Name, model.Email, model.Message, model.Telephone);
                message.Destination = "gmovida@gmail.com";
                db.MailModels.Add(model);
                db.SaveChanges();
                await UserManager.EmailService.SendAsync(message);
            } 
                return View(model);
         }

    }
}