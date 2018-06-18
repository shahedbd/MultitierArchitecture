using System;
namespace FXTF.CRM.Model.Model.Admin
{
    public class Holiday
    {
        public long SL { get; set; }
        public DateTime HolidayStartDate { get; set; }
        public DateTime HolidayEndDate { get; set; }
        public string Notes { get; set; }
        public int Status { get; set; }
    }
}
