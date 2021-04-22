using RESTWithASP_NET5.Models;
using RESTWithASP_NET5.Models.Context;
using RESTWithASP_NET5.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTWithASP_NET5.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly MySQLContext _context;

        public PersonRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.Id.Equals(id)))
                return null;

            var user = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (user != null)
            {
                user.Enabled = false;

                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return user;
        }

        public List<Person> FindByName(string firstName, string secondName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(secondName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName)
                                    && p.LastName.Contains(secondName))
                                    .ToList();
            }
            else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(secondName))
            {
                return _context.Persons.Where(p => p.LastName.Contains(secondName)).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(secondName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();
            }
            else
                return null;
        }
    }
}
