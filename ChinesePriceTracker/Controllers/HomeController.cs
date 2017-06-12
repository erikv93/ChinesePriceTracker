using ChinesePriceTracker.Models;
using ChinesePriceTracker.Scraping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChinesePriceTracker.Controllers
{
	public class HomeController : Controller
	{

		private ProductContext db = new ProductContext();

		public ActionResult Index()
		{
			var products = db.Products.ToList();
			return View(products);
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Add(string url)
		{
			ProductInfoScraper scraper = new ProductInfoScraper(url);
			Product product = await scraper.GetProductInfo();
			TempData["product"] = product;

			return View(nameof(ConfirmDetails), product);
		}

		public ActionResult ConfirmDetails()
		{
			return View();
		}

		public ActionResult Confirmed()
		{
			Product product = TempData["product"] as Product;
			TempData["product"] = null;

			db.Products.Add(product);
			db.SaveChanges();

			return View(nameof(Index), db.Products.ToList());
		}

	}
}