using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Data
{
	public class MarketType
	{
		public int Id { get; set; }

		[Required, StringLength(255)]
		public String Name { get; set; }

		[StringLength(500)]
		public String Description { get; set; }

	}
}