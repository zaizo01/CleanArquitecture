using AutoMapper;
using InvoiceManagementApp.Application.DTOs;
using InvoiceManagementApp.Application.Interfaces;
using InvoiceManagementApp.Domain.Entities;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Controllers
{
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class AppointmentDateController : ControllerBase
        {
            private readonly IGenericRepository<AppointmentDate> repository;
            private readonly IMapper mapper;
            private readonly ILoggerManager logger;
            private readonly IAppointmentDateRepository<AppointmentDate> repositoryAppointment;

            public AppointmentDateController(IGenericRepository<AppointmentDate> repository, IAppointmentDateRepository<AppointmentDate> repositoryAppointment, IMapper mapper, ILoggerManager logger)
            {
                this.repository = repository;
                this.mapper = mapper;
                this.logger = logger;
                this.repositoryAppointment = repositoryAppointment;
            }

            [HttpGet]
            public async Task<IActionResult> GetAppointmentDateById(Guid id)
            {
                try
                {
                    var appointmentDate = await repository.GetById(id);
                    if (appointmentDate == null) return NotFound();
                    return Ok(appointmentDate);
                }
                catch (Exception ex)
                {
                    logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                    return StatusCode(500, "Internal server error.");
                }
            }

            [HttpGet]
            public async Task<IActionResult> GetAppointmentDate()
            {
                try
                {
                    var appointmentDate = await repository.GetAll();
                    return Ok(appointmentDate);
                }
                catch (Exception ex)
                {
                    logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                    return StatusCode(500, "Internal server error.");
                }
            }

            [HttpPost]
            public async Task<IActionResult> PostAppointmentDate(AppointmentDatePostDTO appointmentDateDto)
            {
                try
                {
                    var validationEntitiesExist = await repositoryAppointment.ValidateEntities(appointmentDateDto);
                    if (validationEntitiesExist == 1) return new JsonResult("El Doctor no existe");
                    if (validationEntitiesExist == 5) return new JsonResult("La fecha de inicio no puede ser igual a la fecha fin");
                    if (validationEntitiesExist == 2) return new JsonResult("El Paciente no existe");
                    if (validationEntitiesExist == 3) return new JsonResult("El Doctor tiene una cita agendada en esa fecha");
                    if (validationEntitiesExist == 5) return new JsonResult("La fecha de inicio no puede ser igual a la fecha fin");
                    if (validationEntitiesExist == 6) return new JsonResult("La fecha fin es menor que la fecha de inicio");
                    else
                    {
                        var appointmentDate = mapper.Map<AppointmentDate>(appointmentDateDto);
                        await repository.Create(appointmentDate);
                        return Ok(mapper.Map<AppointmentDatePostDTO>(appointmentDate));
                    }

                }
                catch (Exception ex)
                {
                    logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                    return StatusCode(500, "Internal server error.");
                }
            }

            [HttpPut]
            public async Task<IActionResult> PutAppointmentDate(AppointmentDate appointmentDate)
            {
                try
                {
                    var item = await repository.Update(appointmentDate);
                    return Ok(item);
                }
                catch (Exception ex)
                {
                    logger.LogError($"Something went wrong inside the GetPatientById action: {ex.Message}");
                    return StatusCode(500, "Internal server error.");
                }
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAppointmentDate(Guid id)
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

