using InvoiceManagementApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.DTOs
{
    public class ListOfDateByDoctors
    {
        public Guid Id { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    } 
}
