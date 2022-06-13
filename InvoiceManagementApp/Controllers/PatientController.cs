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
    public class PatientController : ControllerBase
    {
        private readonly IGenericRepository<Patient> repository;
        //private readonly IAppointmentDateRepository<AppointmentDate> repositoryAppointment;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;

        public PatientController(IGenericRepository<Patient> repository,/* IAppointmentDateRepository<AppointmentDate> repositoryAppointment,*/ IMapper mapper, ILoggerManager logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            //this.repositoryAppointment = repositoryAppointment;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            try
            {
                var patient = await repository.GetById(id);
                if (patient is null) return NotFound();
                return Ok(mapper.Map<PatientGetDTO>(patient));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPatiens()
        {
            try
            {
                var patiens = await repository.GetAll();
                return Ok(mapper.Map<List<PatientGetDTO>>(patiens));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the GetPatiens action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetPatientListDates(Guid patientId)
        //{
        //    try
        //    {
        //        var patientDates = await repositoryAppointment.GetPatientListOfDates(patientId);
        //        return Ok(mapper.Map<List<ListOfDatesByPatient>>(patientDates));
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError($"Something went wrong inside the GetPatientListDates action: {ex.Message}");
        //        return StatusCode(500, "Internal server error.");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> PostPatient(PatientPostDTO patientDto)
        {
            try
            {
                var patient = mapper.Map<Patient>(patientDto);
                await repository.Create(patient);
                return Ok(patientDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the PostPatient action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }

        }

        [HttpPut]
        public async Task<IActionResult> PutPatient(Patient patient)
        {
            try
            {
                var item = await repository.Update(patient);
                return Ok(item);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the PutPatient action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            try
            {
                await repository.Delete(id);
                return Ok("Record deleted");
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the DeletePatient action: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
