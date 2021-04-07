using RESTWithASP_NET5.Models;
using System.Collections.Generic;

namespace RESTWithASP_NET5.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
