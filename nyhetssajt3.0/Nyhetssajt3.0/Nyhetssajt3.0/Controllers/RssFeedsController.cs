using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Nyhetssajt3._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class RssFeedsController : ControllerBase
    {
        readonly CultureInfo culture = new CultureInfo("en-US");

        [HttpGet]
        public IEnumerable<Feed> Get()
        {
            //var url = "https://khalidabuhakmeh.com/feed.xml";
            //using var reader = XmlReader.Create(url);
            //var feedtest = SyndicationFeed.Load(reader);
            //var post = feedtest
            //    .Items
            //    .FirstOrDefault();
            //List<Feed> feeds = new List<Feed>();
            //Feed feed = new Feed();
            //new Feed
            //{
            //    Title = post.Title.ToString(),
            //    Link = post.Links.ToString(),
            //    Content = post.Content.ToString(),
            //    Date = post.PublishDate.ToString(),
            //    Category = post.Categories.ToString()
            //};
            //Console.Write(feed);
            //feeds.Add(feed);
            //return feeds;
            try
            {
                XDocument doc = XDocument.Load("https://www.c-sharpcorner.com/rss/latestcontentall.aspx");
                var entries = from item in doc.Root.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item")
                              select new Feed
                              {
                                Content = item.Elements().First(i => i.Name.LocalName == "description").Value,
                                Link = (item.Elements().First(i => i.Name.LocalName == "link").Value).StartsWith("/") ? "https://www.c-sharpcorner.com" + item.Elements().First(i => i.Name.LocalName == "link").Value : item.Elements().First(i => i.Name.LocalName == "link").Value,
                                PubDate = Convert.ToDateTime(item.Elements().First(i => i.Name.LocalName == "pubDate").Value, culture),
                                PublishDate = Convert.ToDateTime(item.Elements().First(i => i.Name.LocalName == "pubDate").Value, culture).ToString("dd-MMM-yyyy"),
                                Title = item.Elements().First(i => i.Name.LocalName == "title").Value,
                                FeedType = (item.Elements().First(i => i.Name.LocalName == "link").Value).ToLowerInvariant().Contains("blog") ? "Blog" : (item.Elements().First(i => i.Name.LocalName == "link").Value).ToLowerInvariant().Contains("news") ? "News" : "Article",
                                Author = item.Elements().First(i => i.Name.LocalName == "author").Value
                              };

                return entries.OrderByDescending(o => o.PubDate);
            }
            catch
            {
                List<Feed> feeds = new List<Feed>();
                Feed feed = new Feed();
                feeds.Add(feed);
                return feeds;
            }
        }
    }
}
//links: 
//      https://www.c-sharpcorner.com/rss/latestcontentall.aspx
//      https://www.svd.se/?service=rss
//      https://khalidabuhakmeh.com/feed.xml
