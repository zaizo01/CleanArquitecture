using InvoiceManagementApp.Application.Interfaces;
using InvoiceManagementApp.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<T> Create(T obj)
        {
            context.Set<T>().Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public async Task<T> Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity == null) throw new Exception("The entity is null");
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
