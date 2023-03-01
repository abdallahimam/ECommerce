using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
   public class AdminLoginViewModel
   {
      [Required]
      [Display(Name = "Email")]
      [EmailAddress]
      public string Email { get; set; }

      [Required]
      [DataType(DataType.Password)]
      [Display(Name = "Password")]
      public string Password { get; set; }

      [Display(Name = "Remember me?")]
      public bool RememberMe { get; set; }
   }

   public class ProjectRole
	{
      public string Id { get; set; }

      [Required]
      public string Name { get; set; }


	}
}