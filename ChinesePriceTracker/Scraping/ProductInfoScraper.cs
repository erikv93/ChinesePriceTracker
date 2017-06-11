using ChinesePriceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChinesePriceTracker.Scraping
{
	public class ProductInfoScraper
	{
		public enum Site
		{
			GearBest,
			AliExpress,
			BangGood,
			Unsupported,
		};

		private string _url;
		private string _site;

		IScraper scraper;

		public ProductInfoScraper(string url)
		{

			_url = url;
			var productSite = GetSiteFromUrl(url);
			switch (productSite)
			{
				case Site.GearBest:
					scraper = new GearBestScraper(url);
					_site = "GearBest.com";
					break;
				case Site.BangGood:
					scraper = new BangGoodScraper(url);
					_site = "BangGood.com";
					break;
				case Site.Unsupported:
					// Make sure this returns an error or something
				default:
					break;
			}
		}

		private Site GetSiteFromUrl(string url)
		{
			if (url.ToLowerInvariant().Contains("gearbest.com"))
			{
				return Site.GearBest;
			} else if (url.ToLowerInvariant().Contains("banggood.com"))
			{
				return Site.BangGood;
			}
			else
			{
				return Site.Unsupported;
			}
		}

		public async Task<Product> GetProductInfo()
		{
			Product product = new Product
			{
				Name = await scraper.GetName(),
				Store = _site,
				Url = _url,
				PricePoints = new List<PricePoint>() { new PricePoint { Time = DateTime.Now, Price = await scraper.GetPrice() } }
			};

			return product;
		}
	}
}