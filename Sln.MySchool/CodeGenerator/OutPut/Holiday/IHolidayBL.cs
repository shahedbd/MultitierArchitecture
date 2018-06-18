using FXTF.CRM.Model.Model.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FXTF.CRM.Service.Admin.Interfaces
{
    public interface IHolidayBL
    {
        Task<string> InsertHoliday(Holiday entity);
        Task<string> UpdateHoliday(Holiday entity);
        Task<string> DeleteHoliday(Holiday entity);
        Task<IEnumerable<Holiday>> GetAllHoliday();
        Task<Holiday> GetHolidayBySL(long SL);
    }
}
