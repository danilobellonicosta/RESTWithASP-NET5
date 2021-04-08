using Microsoft.EntityFrameworkCore;
using RESTWithASP_NET5.Models.Base;
using RESTWithASP_NET5.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTWithASP_NET5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindByID(long id)
        {
            return _dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            if (!Exists(item.Id))
                return null;

            var result = _dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();

                    return item;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                return null;
        }

        public void Delete(long id)
        {
            var result = _dataset.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private bool Exists(long id)
        {
            return _dataset.Any(p => p.Id.Equals(id));
        }
    }
}
