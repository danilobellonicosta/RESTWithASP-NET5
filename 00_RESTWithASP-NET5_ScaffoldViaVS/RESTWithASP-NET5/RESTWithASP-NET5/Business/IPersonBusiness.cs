using RESTWithASP_NET5.Data.VO;
using RESTWithASP_NET5.Hypermidia.Util;
using System.Collections.Generic;

namespace RESTWithASP_NET5.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
        PersonVO Disable(long id);
        List<PersonVO> FindByName(string firstName, string secondName);
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
