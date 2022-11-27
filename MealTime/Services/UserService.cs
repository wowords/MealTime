using MealTime.Models;
using Newtonsoft.Json;
using System.Text;

namespace MealTime.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri = "https://localhost:7027";        
        public UserService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<ServiceResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            var uri = API.User.GetUsers(_baseUri);
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return ServiceResult<IEnumerable<UserViewModel>>.Ok(JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(responseString));
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return ServiceResult<IEnumerable<UserViewModel>>.Error("Hiba történt lekérdezés során");

                return ServiceResult<IEnumerable<UserViewModel>>.Error("Hiba történt lekérdezés során");
            }
            catch (Exception e)
            {
                return ServiceResult<IEnumerable<UserViewModel>>.Error("Hiba történt lekérdezés során");
            }
        }

        public async Task<ServiceResult> CreateUser(UserViewModel user)
        {
            var uri = API.User.CreateUser(_baseUri);
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(uri, content);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                string msg = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(msg))
                {
                    return ServiceResult.Ok();
                }
                else
                {
                    return ServiceResult.Error(msg);
                }
            }
            return ServiceResult.Error("Hiba történt a végrehajtás során");
        }
    }
}
