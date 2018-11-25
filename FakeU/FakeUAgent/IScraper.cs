using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FakeUAgent
{
    public interface IScraper
    {
        Task<Listing> Scrape(Uri uri);
    }
}
