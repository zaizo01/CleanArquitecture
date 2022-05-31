using InvoiceManagementApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Domain.Entities
{
    public class AppointmentDate: AuditEntity
    {
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public string Subject { get; set; }
        public string Ubication { get; set; }
        public string AppointmentClasification { get; set; }
        public string AppointmentStatus { get; set; }
        public string Note { get; set; }
        public bool ItsAllDay { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
