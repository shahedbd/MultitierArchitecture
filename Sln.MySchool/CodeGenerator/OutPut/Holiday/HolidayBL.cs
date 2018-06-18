using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FXTF.CRM.Common.Log;
using FXTF.CRM.Service.Admin.Interfaces;
using FXTF.CRM.Data.Repositories.Implementations;
using FXTF.CRM.Model.Model.Admin;

namespace FXTF.CRM.Service.Admin.Implementations
{
public class HolidayBL : IHolidayBL
{

protected ILogger Logger { get; set; }

public HolidayBL(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert Holiday
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> InsertHoliday(Holiday entity)
{
try
{
var result = await new HolidayRepository(Logger).Insert(entity);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Update Holiday
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> UpdateHoliday(Holiday entity)
{
try
{
var result = await new HolidayRepository(Logger).Update(entity);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Delete Holiday
/// </summary>
/// <param name="SL"></param>
/// <returns>Message</returns>
public async Task<string> DeleteHoliday(Holiday entity)
{
try
{
var result = await new HolidayRepository(Logger).Delete(entity.SL);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get All Holiday
/// </summary>
/// <returns>List ofHoliday</returns>
public async Task<IEnumerable<Holiday>> GetAllHoliday()
{
try
{
var result = await new HolidayRepository(Logger).GetAll();
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Get Holiday by SL
/// </summary>
/// <param name="SL"></param>
/// <returns>Holiday Object</returns>
public async Task<Holiday> GetHolidayBySL(long SL)
{
try
{
var result = await new HolidayRepository(Logger).GetByID(SL);
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
