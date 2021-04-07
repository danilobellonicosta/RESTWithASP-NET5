using RESTWithASP_NET5.Models;
using System.Collections.Generic;

namespace RESTWithASP_NET5.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book FindByID(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
