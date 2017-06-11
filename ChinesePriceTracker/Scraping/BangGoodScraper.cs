using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChinesePriceTracker.Scraping
{
	public class BangGoodScraper : IScraper
	{
		private ScrapingBrowser _browser;
		private Uri _url;
		private WebPage _page;

		public BangGoodScraper(string productUrl)
		{
			_url = new Uri(productUrl);
			_browser = new ScrapingBrowser();
		}

		private async Task<WebPage> GetPage(Uri uri)
		{
			if (_page == null)
			{
				_page = await _browser.NavigateToPageAsync(uri);
			}

			return _page;
		}

		public async Task<bool> ValidUrl()
		{
			return true;
		}

		public async Task<decimal> GetPrice()
		{
			var page = await GetPage(_url);
			var nodes = page.Html.Descendants().Where(node => node.Attributes.Contains("oriprice"));
			var pricestring = nodes.ElementAt(3).InnerText;
			pricestring = pricestring.Substring(3);
			decimal price; 
			if (!decimal.TryParse(pricestring, out price))
			{
				price = 0.00m;
			}
			return price;

			//return decimal.Parse(page.Html.SelectSingleNode("/html/body/div[7]/div/div[2]/div[3]/div[2]/div[2]").InnerText);
		}

		public async Task<string> GetName()
		{
			var page = await GetPage(_url);
			var nodes = page.Html.Descendants().Where(node => node.Name == "h1");
			var jazoudeprijskunnenzijnhe = nodes.First();
			var denaambedoelik = jazoudeprijskunnenzijnhe.InnerHtml;
			return denaambedoelik;
		}
	}
}