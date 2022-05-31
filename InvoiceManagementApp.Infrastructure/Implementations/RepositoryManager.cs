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
    public class RepositoryManager /*: IRepositoryManager*/
    {
        //private readonly ApplicationDbContext context;
        //private IDoctorRepository<Doctor> _doctorRepository;
        //private IPatientRepository<Patient> _patientRepository;
        //private IAppointmentDateRepository<AppointmentDate> _appointDateRepository;

        //public RepositoryManager(ApplicationDbContext context)
        //{
        //    this.context = context;
        //}
        //public IDoctorRepository<Doctor> Doctor
        //{
        //    get
        //    {
        //        if (_doctorRepository == null)
        //            _doctorRepository = new DoctorRepository(context);
        //        return _doctorRepository;
        //    }
        //}

        //public IPatientRepository<Patient> Patient
        //{
        //    get
        //    {
        //        if (_patientRepository == null)
        //            _patientRepository = new PatientRepository(context);
        //        return _patientRepository;
        //    }
        //}

        //public IAppointmentDateRepository<AppointmentDate> AppointmentDate
        //{
        //    get
        //    {
        //        if (_appointDateRepository == null)
        //            _appointDateRepository = new AppointmentDateRepository(context);
        //        return _appointDateRepository;
        //    }
        //}
        //public void Save()
        //{
        //    context.SaveChanges();
        //}
    }
}
