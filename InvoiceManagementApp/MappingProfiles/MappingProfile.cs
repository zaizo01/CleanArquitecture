using AutoMapper;
using InvoiceManagementApp.Application.DTOs;
using InvoiceManagementApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementApp.MappingProfiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorGetDTO>().ReverseMap();
            CreateMap<Doctor, DoctorPostDTO>().ReverseMap();

            CreateMap<Patient, PatientGetDTO>().ReverseMap();
            CreateMap<Patient, PatientPostDTO>().ReverseMap();

            CreateMap<AppointmentDate, AppointmentDateGetDTO>().ReverseMap();
            CreateMap<AppointmentDate, AppointmentDatePostDTO>().ReverseMap();

            CreateMap<AppointmentDate, ListOfDateByDoctors>().ReverseMap();
            CreateMap<AppointmentDate, ListOfDatesByPatient>().ReverseMap();
        }
    }
}
