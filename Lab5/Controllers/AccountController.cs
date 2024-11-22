using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi;
using Lab5.Models;
using Newtonsoft.Json;

namespace Lab5.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newClient = new HttpClient();
                    var requestData = new Dictionary<string, string>
                    {
                        { "client_id", _configuration["Auth0:ClientId"] },
                        { "client_secret", _configuration["Auth0:ClientSecret"] },
                        { "audience", $"https://{_configuration["Auth0:Domain"]}/api/v2/" },
                        { "grant_type", "client_credentials" }
                    };

                    var content = new FormUrlEncodedContent(requestData);
                    var response = await newClient.PostAsync($"https://{_configuration["Auth0:Domain"]}/oauth/token", content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Failed to obtain access token: {responseString}");
                    }

                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseString);
                    var accessToken = tokenResponse?.AccessToken;

                    if (string.IsNullOrEmpty(accessToken))
                    {
                        throw new Exception("Access token is missing or invalid.");
                    }

                    var client = new ManagementApiClient(accessToken, new Uri($"https://{_configuration["Auth0:Domain"]}/api/v2"));

                    var userCreateRequest = new UserCreateRequest
                    {
                        Connection = "Username-Password-Authentication",
                        Email = model.Email,
                        Password = model.Password,
                        UserMetadata = new { FullName = model.FullName, PhoneNumber = model.PhoneNumber },
                        UserName = model.Username
                    };

                    var user = await client.Users.CreateAsync(userCreateRequest);
                    return RedirectToAction("Login", "Account");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error creating user: {ex.Message}");
                    Console.WriteLine(ex.Message);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            var redirectUri = "http://localhost:5115/signin-oidc";
            return Challenge(new AuthenticationProperties { RedirectUri = redirectUri }, OpenIdConnectDefaults.AuthenticationScheme);
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var user = authenticateResult?.Principal;

            if (user == null)
                return RedirectToAction("Login", "Account");

            return View(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
