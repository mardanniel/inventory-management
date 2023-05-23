using System.Text;
using InventorySystem.Web.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InventorySystem.Web.Repositories.Accounts
{
    public class AccountApiRepository : IAccountRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _appConfig;

        public AccountApiRepository(HttpClient httpClient, IConfiguration appConfig)
        {
            this._appConfig = appConfig;
            this._httpClient = httpClient;
            this._httpClient.BaseAddress = new Uri("http://localhost:5257");
            this._httpClient.DefaultRequestHeaders.Add("ApiKey", this._appConfig.GetValue<string>("ApiKey"));
        }

        public async Task<string> LoginUserAsync(LoginUserViewModel loginUser)
        {
            var loginDataString = JsonConvert.SerializeObject(loginUser);
            var requestBody = new StringContent(loginDataString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/account/login", requestBody);
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            var token = JObject.Parse(content)["token"].ToString();
            return token;
        }

        public async Task<bool> SignUpUserAsync(RegisterUserViewModel registerUser)
        {
            var signUpDataString = JsonConvert.SerializeObject(registerUser);
            var requestBody = new StringContent(signUpDataString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/account/signup", requestBody);
            return response.IsSuccessStatusCode;
        }
    }
}