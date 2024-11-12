using Microsoft.EntityFrameworkCore;
using MobileRepository.Base.Context;
using MobileRepository.Base.UnitOfWork.Interface;

namespace MobileRepository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(MobileContext context)
        {
            Context = context;
        }

        public MobileContext Context { get; private set; }

        /*public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            return new DbTransaction(Context.Database.BeginTransaction(isolationLevel));
        }*/

        public void Add<T>(T obj)
             where T : class
        {
            var set = Context.Set<T>();
            set.Add(obj);
        }
        //ExceptionChange
        public async Task AddAsync<T>(T obj)
            where T : class
        {
            var set = Context.Set<T>();
            await set.AddAsync(obj);
        }
        public void Update<T>(T obj)
            where T : class
        {
            var set = Context.Set<T>();
            set.Attach(obj);
            Context.Entry(obj).State = EntityState.Modified;
        }

        void IUnitOfWork.Remove<T>(T obj)
        {
            var set = Context.Set<T>();
            set.Remove(obj);
        }

        void IUnitOfWork.Remove<T>(List<T> obj)
        {
            var set = Context.Set<T>();
            set.RemoveRange(obj);
        }

        public IQueryable<T> Query<T>()
            where T : class
        {
            return Context.Set<T>();
        }

        public bool Commit()
        {
            return Context.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }

        public void Attach<T>(T newUser) where T : class
        {
            var set = Context.Set<T>();
            set.Attach(newUser);
        }
        public void Detach<T>(T newUser) where T : class
        {
            Context.Entry(newUser).State = EntityState.Detached;
        }
        public void Dispose()
        {
            Context = null;
        }

        public DbSet<T> GetEntities<T>() where T : class
        {
            return Context.Set<T>();
        }

        public void Rollback()
        {
            Context.Dispose();
        }

    }
}
