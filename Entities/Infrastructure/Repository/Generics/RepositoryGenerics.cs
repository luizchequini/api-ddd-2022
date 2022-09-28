using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _ContextOptions;
        public RepositoryGenerics()
        {
            _ContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task Add(T entity)
        {
            using(var data = new ContextBase(_ContextOptions))
            {
                await data.Set<T>().AddAsync(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T entity)
        {
            using (var data = new ContextBase(_ContextOptions))
            {
                data.Set<T>().Remove(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAll()
        {
            using(var data = new ContextBase(_ContextOptions))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetEntityById(int id)
        {
            using (var data = new ContextBase(_ContextOptions))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task Update(T entity)
        {
            using (var data = new ContextBase(_ContextOptions))
            {
                data.Set<T>().Update(entity);
                await data.SaveChangesAsync();
            }
        }

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose() { Disposed(true); GC.SuppressFinalize(this); }

        private void Disposed(bool disposing)
        {
            if(disposed) return;
            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }
    }
}
