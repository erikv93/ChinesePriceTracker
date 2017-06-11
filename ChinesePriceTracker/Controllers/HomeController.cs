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
			var heer = new GearBestScraper();
			var mongol = await heer.GetPrice();
			return View();
		}
	}
}