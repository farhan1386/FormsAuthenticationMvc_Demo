using FormsAuthenticationMvc_Demo.Models;
using FormsAuthenticationMvc_Demo.ViewModel;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace FormsAuthenticationMvc_Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly EmployeeContext db = new EmployeeContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = db.Users.Any(user => user.UserName.ToLower() ==
                userModel.UserName.ToLower() && user.UserPassword == userModel.UserPassword);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(userModel.UserName, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("","Invalid username and password");
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}