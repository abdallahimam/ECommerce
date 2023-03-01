using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class RoleController : Controller
    {
      RoleManager<IdentityRole> roleManager;

      public RoleController(RoleManager<IdentityRole> roleManager)
      {
         this.roleManager = roleManager;
      }

      public ActionResult Index()
      {
         var roles = roleManager.Roles.ToList();
         return View(roles);
      }

      public ActionResult Create()
      {
         return View(new IdentityRole());
      }

      [HttpPost]
      public async Task<ActionResult> Create(IdentityRole role)
      {
         var roleExist = await roleManager.RoleExistsAsync(role.Name);
         if (!roleExist)
			{
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
         }

         return View(role);
      }
   }
}