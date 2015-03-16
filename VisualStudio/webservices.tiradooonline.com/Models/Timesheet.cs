using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC3WebApplication.Models
{
    public class Timesheet : DbContext
    {
        public int TimesheetID { get; set; }
        public int TimesheetCompanyID { get; set; }
        public DateTime TimesheetInvoiceDate { get; set; }
        public int TimesheetInvoiceNumber { get; set; }
        public decimal TimesheetHourlyRate { get; set; }
        public DateTime TimesheetStartDate { get; set; }
        public DateTime TimesheetEndDate { get; set; }
        public string TimesheetHTML { get; set; }
        public bool Active { get; set; }
        public DateTime create_dt { get; set; }
    }
}