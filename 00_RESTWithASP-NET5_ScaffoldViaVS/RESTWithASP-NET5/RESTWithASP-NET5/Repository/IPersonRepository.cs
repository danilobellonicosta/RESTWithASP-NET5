using RESTWithASP_NET5.Models;
using RESTWithASP_NET5.Repository.Generic;
using System.Collections.Generic;

namespace RESTWithASP_NET5.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName, string secondName);
    }
}
