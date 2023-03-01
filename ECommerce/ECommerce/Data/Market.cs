
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Data
{
	public class Market
	{
		public int Id { get; set; }

		[Required, StringLength(255)]
		public String Name { get; set; }

		[StringLength(500)]
		public String Description { get; set; }

		[StringLength(255)]
		public String Address { get; set; }

		[StringLength(1024)]
		public String Logo { get; set; }

		[StringLength(1024)]
		public String Location { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime CreatedAt { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime UpdatedAt { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime DeletedAt { get; set; }

		public MarketType MarketType { get; set; }

		public Models.ApplicationUser Owner { get; set; }
	}
}