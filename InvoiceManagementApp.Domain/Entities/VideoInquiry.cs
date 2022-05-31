using InvoiceManagementApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Domain.Entities
{
    public class VideoInquiry: AuditEntity
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string VideoInquiryPerson { get; set; }
        public string VideoInquiryPersonFirstname { get; set; }
        public string VideoInquiryPersonLastName { get; set; }
    }
}
