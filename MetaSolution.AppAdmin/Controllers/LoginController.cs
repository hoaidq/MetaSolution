using MetaSolution.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using MetaSolution.IntegrationAPI.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using MetaSolution.Utilities.Constants;

namespace MetaSolution.AppAdmin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public LoginController(IUserService userService,
            IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [Route("/dang-nhap")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return Json(ModelState);

            var result = await _userService.Login(request);
            if (result.ResultObj != null)
            {

                var userPrincipal = this.ValidateToken(result.ResultObj);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    IsPersistent = false
                };

                HttpContext.Session.SetString(SystemConstants.AppSettings.DefaultLanguageCode, _configuration[SystemConstants.AppSettings.DefaultLanguageCode]);
                HttpContext.Session.SetString(SystemConstants.AppSettings.Token, result.ResultObj);
                await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            userPrincipal,
                            authProperties);
            }

            return Json(result);
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
    }
}
