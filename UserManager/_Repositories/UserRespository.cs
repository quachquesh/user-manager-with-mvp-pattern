using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;
using UserManager.Configs;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UserManager._Repositories
{
    public class UserRespository : IUserRepository
    {
        // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        private Env env = new Env();
        public async void Add(UserModel userModel)
        {
            using (var client = new HttpClient())
            {
                string jsonData = JsonConvert.SerializeObject(userModel);
                var response = await client.PostAsync($"{env.apiUrl}/users", new StringContent(jsonData, Encoding.UTF8, "application/json"));
                //if (response.IsSuccessStatusCode)
                //{
                //    string responseBody = await response.Content.ReadAsStringAsync();
                //    userList = JsonConvert.DeserializeObject<List<UserModel>>(responseBody);
                //}
            }
        }

        public async void Delete(string id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{env.apiUrl}/users/{id}");
            }
        }

        public async void Edit(UserModel userModel)
        {
            using (var client = new HttpClient())
            {
                string jsonData = JsonConvert.SerializeObject(userModel);
                var response = await client.PutAsync($"{env.apiUrl}/users/{userModel.Id}", new StringContent(jsonData, Encoding.UTF8, "application/json"));
                //if (response.IsSuccessStatusCode)
                //{
                //    string responseBody = await response.Content.ReadAsStringAsync();
                //    userList = JsonConvert.DeserializeObject<List<UserModel>>(responseBody);
                //}
            }
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            var userList = new List<UserModel>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{env.apiUrl}/users");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<UserModel>>(responseBody);
                }
            }
            return userList;
        }

        public async Task<IEnumerable<UserModel>> GetByName(string value)
        {
            var userList = new List<UserModel>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{env.apiUrl}/users?name_like={value}");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<UserModel>>(responseBody);
                }
            }
            return userList;
        }
    }
}
