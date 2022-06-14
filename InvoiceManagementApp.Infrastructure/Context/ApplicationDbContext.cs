using InvoiceManagementApp.Application.Interfaces;
using InvoiceManagementApp.Domain.Common;
using InvoiceManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<AppointmentDate> AppointmentDates { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "CRISTOPHER ADD";
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.IsActive = true;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "CRISTOPHER MODIFIED";
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.IsActive = true;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.LastModifiedBy = "CRISTOPHER DELETED";
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.IsActive = false;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
