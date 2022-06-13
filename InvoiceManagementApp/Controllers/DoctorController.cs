using AutoMapper;
using InvoiceManagementApp.Application.DTOs;
using InvoiceManagementApp.Application.Interfaces;
using InvoiceManagementApp.Domain.Entities;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IGenericRepository<Doctor> repository;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;
        //private readonly IAppointmentDateRepository<AppointmentDate> repositoryAppointment;

        public DoctorController(IGenericRepository<Doctor> repository, /*IAppointmentDateRepository<AppointmentDate> repositoryAppointment,*/ IMapper mapper, ILoggerManager logger)
        {
            this.repository = repository;
            //this.repositoryAppointment = repositoryAppointment;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            try
            {
                var doctor = await repository.GetById(id);
                if (doctor == null) return NotFound();
                return Ok(mapper.Map<DoctorGetDTO>(doctor));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            try
            {
                var doctors = await repository.GetAll();
                return Ok(mapper.Map<List<DoctorGetDTO>>(doctors));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetListOfDates(Guid doctorId)
        //{
        //    try
        //    {
        //        var dates = await repositoryAppointment.GetDoctorListOfDates(doctorId);
        //        return Ok(mapper.Map<List<ListOfDateByDoctors>>(dates));
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
        //        return StatusCode(500, "Internal server error.");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> PostDoctor(DoctorPostDTO doctorDto)
        {
            try
            {
                var doctor = mapper.Map<Doctor>(doctorDto);
                await repository.Create(doctor);
                return Ok(mapper.Map<DoctorPostDTO>(doctor));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutDoctor(Doctor doctor)
        {
            try
            {
                var doctorDB = await repository.Update(doctor);
                return Ok(doctorDB);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            try
            {
                await repository.Delete(id);
                return Ok("Record deleted");
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
