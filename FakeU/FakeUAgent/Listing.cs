using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace FakeUAgent
{
    public class Listing
    {
        public string title;
        public decimal price;
        public int id;
        public Uri uri;

        public string Desc { private get; set; }

        public Listing(string title, decimal price, int id, Uri uri, string desc)
        {
            this.title = title;
            this.price = price;
            this.id = id;
            this.uri = uri;
            Desc = desc;
        }
        

        public HashSet<string> DescKeywords
        {
            get
            {
                var charArr = Desc
                    .ToLower()
                    .Where((e) => Regex.IsMatch(e.ToString(), "[a-z|\\s]"))
                    .ToArray();

                var str = new string(charArr);

                var result = str
                    .Split(" ")
                    .ToHashSet();

                return result;
            }
        }
    }
}
