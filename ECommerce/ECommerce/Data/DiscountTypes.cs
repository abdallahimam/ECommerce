using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data
{
	public class DiscountTypes
	{
		public int Id { get; set; }

		[Required, StringLength(255)]
		public String Name { get; set; }

		[StringLength(500)]
		public String Description { get; set; }
	}
}