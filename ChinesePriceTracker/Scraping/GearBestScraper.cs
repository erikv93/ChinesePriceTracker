using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace ChinesePriceTracker.Scraping
{
	public class GearBestScraper : IScraper
	{
		private ScrapingBrowser _browser;
		private Uri _url = new Uri("http://www.gearbest.com/pocket-knives-and-folding-knives/pp_458180.html");
		private WebPage _page;

		public GearBestScraper()
		{
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

		public async Task<decimal> GetPrice()
		{
			var page = await GetPage(_url);
			return decimal.Parse(page.Html.SelectSingleNode("//*[@id=\"unit_price\"]").InnerText.Replace("$", ""), CultureInfo.InvariantCulture);
		}

		public async Task<string> GetName()
		{
			var page = await GetPage(_url);
			return page.Html.SelectSingleNode("//*[@id=\"mainWrap\"]/section/div[1]/div/h1").InnerHtml;
		}
	}
}