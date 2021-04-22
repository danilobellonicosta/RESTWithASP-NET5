using RESTWithASP_NET5.Models.Base;
using System.Collections.Generic;

namespace RESTWithASP_NET5.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
