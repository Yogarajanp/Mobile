using Microsoft.EntityFrameworkCore;

namespace MobileRepository.Base.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {


        DbSet<T> GetEntities<T>() where T : class;
        void Add<T>(T obj) where T : class;
        Task AddAsync<T>(T obj) where T : class;
        void Update<T>(T obj) where T : class;
        void Remove<T>(T obj) where T : class;
        void Remove<T>(List<T> obj) where T : class;
        IQueryable<T> Query<T>() where T : class;
        bool Commit();
        Task<bool> CommitAsync();
        Task<int> CommitAsync(CancellationToken cancellationToken);
        void Attach<T>(T obj) where T : class;
        void Detach<T>(T obj) where T : class;
        void Rollback();
    }
}
