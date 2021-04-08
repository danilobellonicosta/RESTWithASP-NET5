using RESTWithASP_NET5.Data.Converter.Contract;
using RESTWithASP_NET5.Data.VO;
using RESTWithASP_NET5.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTWithASP_NET5.Data.Converter.Implementation
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO Origin)
        {
            if (Origin == null) 
                return null;

            return new Person
            {
                Id = Origin.Id,
                FirstName = Origin.FirstName,
                LastName = Origin.LastName,
                Address = Origin.Address,
                Gender = Origin.Gender
            };
        }

        public List<Person> Parse(List<PersonVO> Origin)
        {
            if (Origin == null)
                return null;

            return Origin.Select(item => Parse(item)).ToList();
        }

        public PersonVO Parse(Person Origin)
        {
            if (Origin == null)
                return null;

            return new PersonVO
            {
                Id = Origin.Id,
                FirstName = Origin.FirstName,
                LastName = Origin.LastName,
                Address = Origin.Address,
                Gender = Origin.Gender
            };
        }

        public List<PersonVO> Parse(List<Person> Origin)
        {
            if (Origin == null)
                return null;

            return Origin.Select(item => Parse(item)).ToList();
        }
    }
}
