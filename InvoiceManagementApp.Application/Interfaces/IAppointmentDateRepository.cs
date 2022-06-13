using InvoiceManagementApp.Application.DTOs;
using InvoiceManagementApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.Interfaces
{
    public interface IAppointmentDateRepository<TEntity> : IGenericRepository<AppointmentDate>
    {
        Task<int> ValidateEntities(AppointmentDatePostDTO appointmentDatePostDTO);
        Task<List<TEntity>> GetDoctorListOfDates(Guid doctorId);
        Task<List<TEntity>> GetPatientListOfDates(Guid patientId);
    }
}
