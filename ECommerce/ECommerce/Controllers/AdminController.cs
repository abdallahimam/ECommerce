using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ECommerce.Service;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ECommerce.Controllers
{
   [Authorize(Roles = "Admin")]
   public class AdminController : Controller
   {

      private ApplicationSignInManager _signInManager;
      private ApplicationUserManager _userManager;
      private RoleManager<IdentityRole> _roleManager;
      private UserService _userService;

      public AdminController() { }

      public AdminController(ApplicationSignInManager signInManager, ApplicationUserManager userManager, UserService userService)
      {
         UserManager = userManager;
         SignInManager = signInManager;
         _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
         _userService = userService;
      }


      [AllowAnonymous]
      // GET: Login
      public ActionResult Login()
      {

         if (!User.Identity.IsAuthenticated)
         {
            return View("Login");
         }

         return RedirectToAction("Index");
      }


      // POST: Login
      [AllowAnonymous]
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Login(AdminLoginViewModel model, string returnUrl)
      {
         try
         {
            if (!ModelState.IsValid)
            {
               return View("Login", model);
            }

            if (!User.Identity.IsAuthenticated)
            {
               
               var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
               switch (result)
               {
                  case SignInStatus.Success:
                     //return RedirectToLocal(returnUrl);
                     return RedirectToAction("Index");
                  case SignInStatus.LockedOut:
                     return View("Lockout");
                  case SignInStatus.RequiresVerification:
                     return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                  case SignInStatus.Failure:
                  default:
                     ModelState.AddModelError("", "Invalid login attempt.");
                     break;
                     //return View(model);
               }

            }

            if (IsAdminUser())
				{
               return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Home");
         }
         catch
         {
            return View("Login");
         }
      }

      // GET: Admin
      public ActionResult Index()
      {
         return View("Dashboard");
      }

      public ActionResult NewRole()
		{
         return View("NewRole");
		}

      [HttpPost]
      public async Task<ActionResult> NewRole(ProjectRole role)
      {
         if (!ModelState.IsValid)
			{
            return View(role);
			}
         var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
         var roleExist = await roleManager.RoleExistsAsync(role.Name);
         if (!roleExist)
         {
            await roleManager.CreateAsync(new IdentityRole(role.Name));
            return RedirectToAction("RolesList");
         }

         ModelState.AddModelError("", "Role is exists");
         return View("NewRole", role);
      }

      public ActionResult RolesList()
		{
         var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
         var roles = roleManager.Roles.ToList();
         return View("RolesList", roles);
		}


      public ApplicationSignInManager SignInManager
      {
         get
         {
            return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
         }
         private set
         {
            _signInManager = value;
         }
      }

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

      private ActionResult RedirectToLocal(string returnUrl)
      {
         if (Url.IsLocalUrl(returnUrl))
         {
            return Redirect(returnUrl);
         }
         return RedirectToAction("Index", "Home");
      }

      private Boolean IsAdminUser()
      {
         if (User.Identity.IsAuthenticated)
         {
            var user = User.Identity;
            var s = _userManager.GetRoles(user.GetUserId());
            if (s[0].ToString() == "Admin")
            {
               return true;
            }
            else
            {
               return false;
            }
         }
         return false;
      }
   }
}