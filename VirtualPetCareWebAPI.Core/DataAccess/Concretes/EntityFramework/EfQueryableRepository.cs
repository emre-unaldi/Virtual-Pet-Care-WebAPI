using Microsoft.EntityFrameworkCore;
using VirtualPetCareWebAPI.Core.DataAccess.Abstracts;
using VirtualPetCareWebAPI.Entity.Abstracts;

namespace VirtualPetCareWebAPI.Core.DataAccess.Concretes.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private DbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this.Entities;

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }

                return _entities;
            }
        }
    }
}
