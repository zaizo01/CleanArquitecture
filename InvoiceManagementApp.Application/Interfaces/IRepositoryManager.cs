using InvoiceManagementApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.Interfaces
{
    public interface IRepositoryManager
    {
        IDoctorRepository<Doctor> Doctor { get; }
        IPatientRepository<Patient> Patient { get; }
        IAppointmentDateRepository<AppointmentDate> AppointmentDate { get; }
        void Save();
    }
}
