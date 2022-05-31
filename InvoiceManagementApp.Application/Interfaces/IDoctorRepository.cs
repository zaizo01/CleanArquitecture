using InvoiceManagementApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.Interfaces
{
    public interface IDoctorRepository<TEntity> : IGenericRepository<Doctor>
    {
        Task<TEntity> GetByName(string name);

    }
}
