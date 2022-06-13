using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.DTOs
{
    public class AppointmentDatePostDTO
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
