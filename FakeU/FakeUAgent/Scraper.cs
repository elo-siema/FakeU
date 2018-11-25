using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using HtmlAgilityPack;

namespace FakeUAgent
{
    public class Scraper : IScraper
    {

        public Scraper()
        {
            
        }

        public async Task<Listing> Scrape(Uri uri)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(uri);

            Stream stream = await response.Content.ReadAsStreamAsync();

            HtmlDocument doc = new HtmlDocument();

            doc.Load(stream);

            return Parse(doc, uri);
        }

        private Listing Parse(HtmlDocument doc, Uri uri)
        {
            var title = doc
                .DocumentNode
                .SelectNodes("//*[@id='offerdescription']/*[contains(@class,'offer-titlebox')]/h1")[0]
                .InnerText;

            var priceString = doc
                .DocumentNode
                .SelectNodes("//*[@id='offeractions']/*[contains(@class,'price-label')]/strong")[0]
                .InnerText;

            var idString = doc
                .DocumentNode
                .SelectNodes("//*[@id='offerdescription']/*[contains(@class,'offer-titlebox')]/*[contains(@class,'offer-titlebox__details')]/em/small")[0]
                .InnerText;

            var desc = doc
                .DocumentNode
                .SelectNodes("//*[@id='textContent']")[0]
                .InnerText;

            var id = Int32.Parse(Regex.Match(idString, "([0-9])+").Captures[0].Value);
            var price = decimal.Parse(priceString);

            return new Listing(title, price, id, uri, desc);


        }
        
    }


}
