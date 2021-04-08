using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace RESTWithASP_NET5.Hypermidia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}
