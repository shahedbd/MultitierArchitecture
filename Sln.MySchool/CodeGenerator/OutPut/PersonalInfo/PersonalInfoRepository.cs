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
public class PersonalInfoRepository : DBOperations<PersonalInfo>, IRepository<PersonalInfo>
{

protected ILogger Logger { get; set; }

public PersonalInfoRepository(ILogger logger)
{
Logger = logger;
}

/// <summary>
/// Insert PersonalInfo
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Insert(PersonalInfo entity)
{
try
{
var cmd = new SqlCommand("sp_PersonalInfo");
cmd.Parameters.AddWithValue("@PersonalInfoID", entity.PersonalInfoID);
cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
cmd.Parameters.AddWithValue("@LastName", entity.LastName);
cmd.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth);
cmd.Parameters.AddWithValue("@City", entity.City);
cmd.Parameters.AddWithValue("@Country", entity.Country);
cmd.Parameters.AddWithValue("@MobileNo", entity.MobileNo);
cmd.Parameters.AddWithValue("@NID", entity.NID);
cmd.Parameters.AddWithValue("@Email", entity.Email);
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
/// Update PersonalInfo
/// </summary>
/// <param name="entity"></param>
/// <returns>Message</returns>
public async Task<string> Update(PersonalInfo entity)
{
try
{
var cmd = new SqlCommand("sp_PersonalInfo");
cmd.Parameters.AddWithValue("@PersonalInfoID", entity.PersonalInfoID);
cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
cmd.Parameters.AddWithValue("@LastName", entity.LastName);
cmd.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth);
cmd.Parameters.AddWithValue("@City", entity.City);
cmd.Parameters.AddWithValue("@Country", entity.Country);
cmd.Parameters.AddWithValue("@MobileNo", entity.MobileNo);
cmd.Parameters.AddWithValue("@NID", entity.NID);
cmd.Parameters.AddWithValue("@Email", entity.Email);
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
/// Delete PersonalInfo
/// </summary>
/// <param name="PersonalInfoID"></param>
/// <returns>Message</returns>
public async Task<string> Delete(long PersonalInfoID)
{
try
{
var cmd = new SqlCommand("sp_PersonalInfo");
cmd.Parameters.AddWithValue("@PersonalInfoID", PersonalInfoID);
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
/// Get All PersonalInfo
/// </summary>
/// <returns>List ofPersonalInfo</returns>
public async Task<IEnumerable<PersonalInfo>> GetAll()
{
try
{
var cmd = new SqlCommand("sp_PersonalInfo");
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
/// Get PersonalInfo by PersonalInfoID
/// </summary>
/// <param name="PersonalInfoID"></param>
/// <returns>PersonalInfo Object</returns>
public async Task<PersonalInfo> GetByID(long PersonalInfoID)
{
try
{
var cmd = new SqlCommand("sp_PersonalInfo");
cmd.Parameters.AddWithValue("@PersonalInfoID", PersonalInfoID);
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
/// Data Mapping for PersonalInfo
/// </summary>
/// <param name="sqldatareader"></param>
/// <returns>PersonalInfo Object</returns>
public PersonalInfo Mapping(SqlDataReader sqldatareader)
{
try
{
PersonalInfo oPersonalInfo = new PersonalInfo();
oPersonalInfo.PersonalInfoID = Helper.ColumnExists(sqldatareader, "PersonalInfoID") ? ((sqldatareader["PersonalInfoID"] == DBNull.Value) ? 0 : Convert.ToInt64(sqldatareader["PersonalInfoID"])) : 0 ;
oPersonalInfo.FirstName = Helper.ColumnExists(sqldatareader, "FirstName") ? sqldatareader["FirstName"].ToString() : "";
oPersonalInfo.LastName = Helper.ColumnExists(sqldatareader, "LastName") ? sqldatareader["LastName"].ToString() : "";
oPersonalInfo.DateOfBirth = Helper.ColumnExists(sqldatareader, "DateOfBirth") ? ((sqldatareader["DateOfBirth"] == DBNull.Value) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(sqldatareader["DateOfBirth"])) : Convert.ToDateTime("01/01/1900");
oPersonalInfo.City = Helper.ColumnExists(sqldatareader, "City") ? sqldatareader["City"].ToString() : "";
oPersonalInfo.Country = Helper.ColumnExists(sqldatareader, "Country") ? sqldatareader["Country"].ToString() : "";
oPersonalInfo.MobileNo = Helper.ColumnExists(sqldatareader, "MobileNo") ? sqldatareader["MobileNo"].ToString() : "";
oPersonalInfo.NID = Helper.ColumnExists(sqldatareader, "NID") ? sqldatareader["NID"].ToString() : "";
oPersonalInfo.Email = Helper.ColumnExists(sqldatareader, "Email") ? sqldatareader["Email"].ToString() : "";
oPersonalInfo.Status = Helper.ColumnExists(sqldatareader, "Status") ? ((sqldatareader["Status"] == DBNull.Value) ? 0 : Convert.ToInt32(sqldatareader["Status"])) : 0 ;
return oPersonalInfo;
}
catch (Exception ex)
{
Logger.Error(ex.Message);
throw ex;
}
}


   }
}
