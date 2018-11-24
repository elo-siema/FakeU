using System;
using System.Collections.Generic;
using System.Text;

namespace FakeUAgent
{
    public interface IScraper
    {
        Listing Scrape(Uri uri);
    }
}
