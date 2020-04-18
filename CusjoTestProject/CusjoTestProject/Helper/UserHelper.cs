using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace CusjoTestProject.Helper
{
    public class UserHelper
    {
        private readonly string endpoint = string.Empty;
        private HttpClient client = null;
        public UserHelper()
        {
            endpoint = "http://localhost:59370/api/"; // Should be configurable
            client = new HttpClient();
            client.BaseAddress = new Uri(endpoint);
        }

        public async Task<List<Models.User>> GetAllUsers()
        {
            try
            {
                HttpResponseMessage response =
                    await client.GetAsync("User/GetUsers");
                if (response.IsSuccessStatusCode)
                {
                    string userString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Models.User>>(userString);
                }
                else
                {
                    throw new Exception("Http Response Error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Models.User> GetUserByEmail(string id)
        {
            try
            {
                HttpResponseMessage response =
                    await client.GetAsync($"User/GetUserByEmail?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    string userString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Models.User>(userString);
                }
                else
                {
                    throw new Exception("Http Response Error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Models.User> GetUserById(int id)
        {
            try
            {
                HttpResponseMessage response =
                    await client.GetAsync($"User/GetUserById/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string userString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Models.User>(userString);
                }
                else
                {
                    throw new Exception("Http Response Error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> CreateUser(Models.User user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var response =
                    await client.PostAsync("User/PostNewUser", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Http Response Error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message +  " ==>" +ex.StackTrace);
            }
        }

        public async Task<bool> UpdateUser(Models.User user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync("User/UpdateUser", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Http Response Error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> VerifyUserById(int id)
        {
            try
            {
                HttpResponseMessage response =
                    await client.PutAsync($"User/VerifyUserById/{id}", null);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Http Response Error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}