using System.Collections.Generic;

namespace RESTWithASP_NET5.Data.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parse(O Origin);
        List<D> Parse(List<O> Origin);
    }
}
