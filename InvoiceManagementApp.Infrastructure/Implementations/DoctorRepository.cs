using InvoiceManagementApp.Application.Interfaces;
using InvoiceManagementApp.Context;
using InvoiceManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.Implementations
{
    public class DoctorRepository : RepositoryBase<Doctor>
    {
        private readonly ApplicationDbContext context;

        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Doctor> GetByName(string name)
        {
            var doctor = await context.Doctors.FirstOrDefaultAsync(x => x.FistName == name);
            return doctor;
        }

    }
}
