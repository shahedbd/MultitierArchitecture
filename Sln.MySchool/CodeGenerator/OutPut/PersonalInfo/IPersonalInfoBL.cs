using FXTF.CRM.Model.Model.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FXTF.CRM.Service.Admin.Interfaces
{
    public interface IPersonalInfoBL
    {
        Task<string> InsertPersonalInfo(PersonalInfo entity);
        Task<string> UpdatePersonalInfo(PersonalInfo entity);
        Task<string> DeletePersonalInfo(PersonalInfo entity);
        Task<IEnumerable<PersonalInfo>> GetAllPersonalInfo();
        Task<PersonalInfo> GetPersonalInfoByPersonalInfoID(long PersonalInfoID);
    }
}
