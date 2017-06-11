using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChinesePriceTracker.Models
{
	public class PricePoint
	{
		[Key]
		public int PriceID { get; set; }
		[Required]
		public DateTime Time {get; set;}
		[Required]
		public decimal Price { get; set; }
		[ForeignKey("ProductID")]
		public virtual Product Product { get; set; }
		public int ProductID { get; set; }
	}
}