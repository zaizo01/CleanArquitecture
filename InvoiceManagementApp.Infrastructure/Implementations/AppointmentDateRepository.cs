﻿using InvoiceManagementApp.Application.DTOs;
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
    public class AppointmentDateRepository 
    {
        private readonly ApplicationDbContext context;
        public AppointmentDateRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<AppointmentDate>> GetDoctorListOfDates(Guid doctorId)
        {
            var dates = await context.AppointmentDates
                .Include(d => d.Doctor)
                .Include(p => p.Patient)
                .Where(x => x.DoctorId == doctorId).ToListAsync();
            return dates;
        }

        public async Task<List<AppointmentDate>> GetPatientListOfDates(Guid patientId)
        {
            var dates = await context.AppointmentDates
                .Include(d => d.Doctor)
                .Where(x => x.PatientId == patientId).ToListAsync();
            return dates;
        }
        public async Task<int> ValidateEntities(AppointmentDatePostDTO appointmentDatePostDTO)
        {

            var existDoctor = await context.Doctors.FirstOrDefaultAsync(x => x.Id == appointmentDatePostDTO.DoctorId);
            var existPatient = await context.Patients.FirstOrDefaultAsync(x => x.Id == appointmentDatePostDTO.PatientId);
            if (existDoctor == null) return 1;
            if (existPatient == null) return 2;
            if (appointmentDatePostDTO.StartDate == appointmentDatePostDTO.FinishDate) return 5;
            if (appointmentDatePostDTO.FinishDate < appointmentDatePostDTO.StartDate) return 6;
            var appointmentsDoctor = await context.AppointmentDates.Where(x => x.DoctorId == appointmentDatePostDTO.DoctorId).ToListAsync();
            foreach (var appointment in appointmentsDoctor)
            {
                if (appointmentDatePostDTO.StartDate == appointment.StartDate || appointmentDatePostDTO.FinishDate == appointment.StartDate)
                {
                    return 3;
                }
                if (appointmentDatePostDTO.StartDate == appointment.FinishDate || appointmentDatePostDTO.FinishDate == appointment.FinishDate)
                {
                    return 3;
                }
                if (appointmentDatePostDTO.StartDate == appointment.StartDate || appointmentDatePostDTO.StartDate == appointment.FinishDate)
                {
                    return 3;
                }
                if (appointmentDatePostDTO.FinishDate == appointment.StartDate || appointmentDatePostDTO.FinishDate == appointment.FinishDate)
                {
                    return 3;
                }
                if (appointmentDatePostDTO.StartDate > appointment.StartDate && appointmentDatePostDTO.StartDate < appointment.FinishDate)
                {
                    return 3;
                }
                if (appointmentDatePostDTO.FinishDate > appointment.StartDate && appointmentDatePostDTO.FinishDate < appointment.FinishDate)
                {
                    return 3;
                }
            }
            if (appointmentDatePostDTO.StartDate == appointmentDatePostDTO.FinishDate)
            {
                return 5;
            }
            return 4;
        }
    }
}
