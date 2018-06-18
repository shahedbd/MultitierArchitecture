using FXTF.CRM.Common.Log;
using FXTF.CRM.Common.Utility;
using FXTF.CRM.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FXTF.CRM.Data.Repositories.Interfaces;
using FXTF.CRM.Model.Model.Admin;

namespace FXTF.CRM.Data.Repositories.Implementations
{
public class HolidayRepository : DBOperations<Holiday>, IRepository<Holiday>
{

protected ILogger Logger { get; set; }

public HolidayRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert Holiday
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(Holiday entity)
{
try
{
var cmd = new SqlCommand("sp_Holiday");
cmd.Parameters.AddWithValue("@SL", entity.SL);
cmd.Parameters.AddWithValue("@HolidayStartDate", entity.HolidayStartDate);
cmd.Parameters.AddWithValue("@HolidayEndDate", entity.HolidayEndDate);
cmd.Parameters.AddWithValue("@Notes", entity.Notes);
cmd.Parameters.AddWithValue("@Status", entity.Status);

cmd.Parameters.Add("@Msg", SqlDbType.NChar, 500);
cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
cmd.Parameters.AddWithValue("@pOptions", 1);

var result = await ExecuteNonQueryProc(cmd);
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
public async Task<string> Update(Holiday entity)
{
try
{
var cmd = new SqlCommand("sp_Holiday");
cmd.Parameters.AddWithValue("@SL", entity.SL);
cmd.Parameters.AddWithValue("@HolidayStartDate", entity.HolidayStartDate);
cmd.Parameters.AddWithValue("@HolidayEndDate", entity.HolidayEndDate);
cmd.Parameters.AddWithValue("@Notes", entity.Notes);
cmd.Parameters.AddWithValue("@Status", entity.Status);

cmd.Parameters.Add("@Msg", SqlDbType.NChar, 500);
cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
cmd.Parameters.AddWithValue("@pOptions", 2);

var result = await ExecuteNonQueryProc(cmd);
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
public async Task<string> Delete(long SL)
{
try
{
var cmd = new SqlCommand("sp_Holiday");
cmd.Parameters.AddWithValue("@SL", SL);
cmd.Parameters.Add("@Msg", SqlDbType.NChar, 500);


cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
cmd.Parameters.AddWithValue("@pOptions", 3);


var result = await ExecuteNonQueryProc(cmd);
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
public async Task<IEnumerable<Holiday>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_Holiday");
cmd.Parameters.AddWithValue("@pOptions", 4);
var result = await GetDataReaderProc(cmd);
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
public async Task<Holiday> GetByID(long SL)
{
try
{
var cmd = new SqlCommand("sp_Holiday");
cmd.Parameters.AddWithValue("@SL", SL);
cmd.Parameters.AddWithValue("@pOptions", 5);
var result = await GetByDataReaderProc(cmd);
return result;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}

/// <summary>
/// Data Mapping for Holiday
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>Holiday Object</returns>
public Holiday Mapping(SqlDataReader sqldatareader)
{
try
{
Holiday oHoliday = new Holiday();
oHoliday.SL = Helper.ColumnExists(sqldatareader, "SL") ? ((sqldatareader["SL"] == DBNull.Value) ? 0 : Convert.ToInt64(sqldatareader["SL"])) : 0 ;
oHoliday.HolidayStartDate = Helper.ColumnExists(sqldatareader, "HolidayStartDate") ? ((sqldatareader["HolidayStartDate"] == DBNull.Value) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(sqldatareader["HolidayStartDate"])) : Convert.ToDateTime("01/01/1900");
oHoliday.HolidayEndDate = Helper.ColumnExists(sqldatareader, "HolidayEndDate") ? ((sqldatareader["HolidayEndDate"] == DBNull.Value) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(sqldatareader["HolidayEndDate"])) : Convert.ToDateTime("01/01/1900");
oHoliday.Notes = Helper.ColumnExists(sqldatareader, "Notes") ? sqldatareader["Notes"].ToString() : "";
oHoliday.Status = Helper.ColumnExists(sqldatareader, "Status") ? ((sqldatareader["Status"] == DBNull.Value) ? 0 : Convert.ToInt32(sqldatareader["Status"])) : 0 ;
return oHoliday;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}


   }
}
