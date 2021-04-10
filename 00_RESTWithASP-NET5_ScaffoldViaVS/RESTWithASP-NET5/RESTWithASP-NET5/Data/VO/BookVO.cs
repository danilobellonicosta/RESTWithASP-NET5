using RESTWithASP_NET5.Hypermidia;
using RESTWithASP_NET5.Hypermidia.Abstract;
using System;
using System.Collections.Generic;

namespace RESTWithASP_NET5.Data.VO
{
    public class BookVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public DateTime LaunchDate { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
