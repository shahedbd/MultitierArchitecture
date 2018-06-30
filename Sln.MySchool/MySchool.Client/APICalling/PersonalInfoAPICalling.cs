using MySchool.Client.APICallingInterfaces;
using MySchool.Model.DBModel;
using MySchool.Shared.Log;
using MySchool.Shared.ResourceFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MySchool.Client.APICalling
{
    public class PersonalInfoAPICalling : IAPICalling<PersonalInfo>
    {
        private string Base_URL = ResCommon.APIURLLocal + "personalinfo/";
        protected ILogger Logger { get; set; }

        public PersonalInfoAPICalling(ILogger logger)
        {
            Logger = logger;
        }

        public List<PersonalInfo> GetAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("GetAll").Result;

                if (response.IsSuccessStatusCode)
                {
                    var jobj = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    return JsonConvert.DeserializeObject<List<PersonalInfo>>(jobj["result"].ToString());
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public PersonalInfo GetByID(long? id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("GetById/" + id).Result;


                if (response.IsSuccessStatusCode)
                {
                    var jobj = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    return JsonConvert.DeserializeObject<PersonalInfo>(jobj["result"].ToString());
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }

        public bool Create(PersonalInfo personalInfo)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Insert", personalInfo).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Edit(PersonalInfo personalInfo)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("Update", personalInfo).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("Delete/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }
    }
}
