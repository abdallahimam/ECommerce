using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Data
{
	public class Category
	{
		public int Id { get; set; }

		public String Name { get; set; }

		public String Description { get; set; }

		public String Slug { get; set; }

		public Boolean Status { get; set; }

		public Market Market { get; set; }

		public Models.ApplicationUser User { get; set; }

		public Category Parent { get; set; }
	}
}