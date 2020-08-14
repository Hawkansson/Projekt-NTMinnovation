using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyhetssajt.Models
{
  public class Feed
  {
    public string Link { get; set; }
    public string Title { get; set; }
    public string FeedType { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
    public DateTime PubDate { get; set; }
    public string PublishDate { get; set; }
  }
}
