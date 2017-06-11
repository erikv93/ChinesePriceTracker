using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinesePriceTracker.Scraping
{
	interface IScraper
	{
		Task<decimal> GetPrice();
		Task<string> GetName();
		Task<bool> ValidUrl();
	}
}
