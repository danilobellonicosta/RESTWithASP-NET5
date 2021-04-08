using RESTWithASP_NET5.Hypermidia.Abstract;
using System.Collections.Generic;

namespace RESTWithASP_NET5.Hypermidia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
