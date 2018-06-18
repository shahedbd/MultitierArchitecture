using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FXTF.CRM.Common.Log;
using FXTF.CRM.Service.Admin.Interfaces;
using FXTF.CRM.Data.Repositories.Implementations;
using FXTF.CRM.Model.Model.Admin;

namespace FXTF.CRM.Service.Admin.Implementations
{
public class PersonalInfoBL : IPersonalInfoBL
{

protected ILogger Logger { get; set; }

public PersonalInfoBL(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert PersonalInfo
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertPersonalInfo(PersonalInfo entity)
{
try
{
var result = await new PersonalInfoRepository(Logger).Insert(entity);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update PersonalInfo
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdatePersonalInfo(PersonalInfo entity)
{
try
{
var result = await new PersonalInfoRepository(Logger).Update(entity);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete PersonalInfo
/// </summary>
/// <param name="PersonalInfoID"></param>
/// <returns>Message</returns>
public async Task<string> DeletePersonalInfo(PersonalInfo entity)
{
try
{
var result = await new PersonalInfoRepository(Logger).Delete(entity.PersonalInfoID);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get All PersonalInfo
/// </summary>
/// <returns>List ofPersonalInfo</returns>
public async Task<IEnumerable<PersonalInfo>> GetAllPersonalInfo()
{
try
{
var result = await new PersonalInfoRepository(Logger).GetAll();
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get PersonalInfo by PersonalInfoID
/// </summary>
/// <param name="PersonalInfoID"></param>
/// <returns>PersonalInfo Object</returns>
public async Task<PersonalInfo> GetPersonalInfoByPersonalInfoID(long PersonalInfoID)
{
try
{
var result = await new PersonalInfoRepository(Logger).GetByID(PersonalInfoID);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}


    }
}
