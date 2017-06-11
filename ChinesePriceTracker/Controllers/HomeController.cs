using ChinesePriceTracker.Models;
using ChinesePriceTracker.Scraping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChinesePriceTracker.Controllers
{
	public class HomeController : Controller
	{
		public async Task<ActionResult> Index()
		{


			IScraper scraper = new GearBestScraper();
			decimal prijs = await scraper.GetPrice();
			string naam = await scraper.GetName();

			using (var context = new ProductContext())
			{
				context.Products.Add(new Product
				{
					Name = naam,
					CurrentPrice = prijs,
					PriceHistory = new Dictionary<DateTime, decimal>(),
					Store = "GearBest",
					Url = "je moeder",
				});
			}

			return View();
		}
	}
}