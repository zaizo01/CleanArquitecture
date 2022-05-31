using InvoiceManagementApp.Application.Interfaces;
using InvoiceManagementApp.Context;
using InvoiceManagementApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.Implementations
{
    public class PatientRepository 
    {
        private readonly ApplicationDbContext context;
        public PatientRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
