using VirtualPetCareWebAPI.Entity.Abstracts;

namespace VirtualPetCareWebAPI.Core.DataAccess.Abstracts
{
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}
