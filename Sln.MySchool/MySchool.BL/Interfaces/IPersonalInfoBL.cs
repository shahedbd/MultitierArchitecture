using MySchool.Model.DBModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.BL.Interfaces
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
