﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChinesePriceTracker.Models
{
	public class Product
	{
		[Key]
		public int ProductID { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Store { get; set; }
		[Required]
		public string Url { get; set; }
		[Required]
		public virtual List<PricePoint> PricePoints { get; set; }

	}
}