using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, new()
    {
        protected readonly RepositoryContext _context;
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

    }
}