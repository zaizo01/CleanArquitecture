using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Domain.DTOs
{
    public class PatientGetDTO
    {
        public Guid DoctorId
        {
            get; set;
        }
        public Guid PatientId
        {
            get; set;
        }
        public DateTime StartDate
        {
            get; set;
        }
        public DateTime FinishDate
        {
            get; set;
       }
    } 
}
