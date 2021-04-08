using System.Collections.Generic;

namespace RESTWithASP_NET5.Hypermidia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
