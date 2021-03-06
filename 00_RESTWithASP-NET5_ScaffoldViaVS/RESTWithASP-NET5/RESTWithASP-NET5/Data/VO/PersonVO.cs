using RESTWithASP_NET5.Hypermidia;
using RESTWithASP_NET5.Hypermidia.Abstract;
using System.Collections.Generic;

namespace RESTWithASP_NET5.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool Enable { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
