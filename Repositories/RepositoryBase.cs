using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, new()
    {
        protected readonly RepositoryContext _context;
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;    //_context beni veritabanına bağlayacak olan ifadem
        }
        public IQueryable<T> FindAll(bool trackChanges)

        {
            return trackChanges
             ? _context.Set<T>()
             : _context.Set<T>().AsNoTracking();
        }


        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
            ? _context.Set<T>().Where(expression).SingleOrDefault()
            : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }
}