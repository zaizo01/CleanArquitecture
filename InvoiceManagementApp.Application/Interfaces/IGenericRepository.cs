using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<T> Delete(Guid id);
        void Save();

        Task<int> SaveChangesAsync();
    }
}
