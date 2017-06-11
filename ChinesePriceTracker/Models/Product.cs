using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChinesePriceTracker.Models
{
	public class Product
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Store { get; set; }
		[Required]
		public string Url { get; set; }
		[Required]
		public decimal CurrentPrice { get; set; }
		[Required]
		public Dictionary<DateTime, decimal> PriceHistory { get; set; }

	}
}