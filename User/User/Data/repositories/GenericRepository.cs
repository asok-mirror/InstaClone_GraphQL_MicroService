
using Microsoft.EntityFrameworkCore;
using User.Data.datacontext;
using System.Collections.Generic;
using System.Linq;

namespace User.Data.repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllByPage(int? pageNumber, int pageSize);

        T GetById<Tkey>(Tkey id);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected UserDataContext _context;
        protected DbSet<T> _table;

        public GenericRepository(UserDataContext context) 
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList<T>();
        }

        public virtual T GetById<Tkey>(Tkey id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAllByPage(int? pageNumber, int pageSize)
        {
            return Page(GetAllAsQueryable(), pageNumber, pageSize);
        }

        protected IQueryable<T> GetAllAsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        protected IEnumerable<T> Page(IQueryable<T> collection, int? pageNumber, int pageSize) 
        {
            return collection.Skip((pageNumber ?? 0) * pageSize)
                             .Take(pageSize).ToList();
        }
    }
}