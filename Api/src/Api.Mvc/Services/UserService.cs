using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Api.Mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace Api.Mvc.Services
{
    public class UserService : IUserService
    {

        private readonly string _route = "https://localhost:6001/api/Users";
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _client.DeleteAsync(_route + "/" + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<UserModel> Get(int id)
        {
            using (var response = _client.GetAsync(_route + "/" + id).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<UserModel>(json);
                    return user;
                }

                return null;
            }
        }

        public async Task<IEnumerable<UserModel>> GetAll(string term)
        {
            using (var response = _client.GetAsync(_route).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(json);

                    if (!string.IsNullOrWhiteSpace(term))
                    {
                        list = list.Where(s => s.Name.Contains(term));
                    }

                    return list;
                }

                return null;
            }
        }

        public async Task<bool> Post(UserModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_route, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Put(UserModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_route, content);
            return response.IsSuccessStatusCode;
        }
    }
}