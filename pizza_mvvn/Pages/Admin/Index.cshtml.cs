using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace pizza_mvvn.Pages.Admin
{
    public class IndexModel : PageModel
    {
        IConfiguration configuration;
        public bool authenticated = true;
        public bool IsDevelopmentMode = false;


        public IndexModel(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;

            if (env.IsDevelopment())
            {
                IsDevelopmentMode = true;
            }

         }
        public IActionResult OnGet()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
            {              
                return Redirect("/Admin/Pizzas");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string username, string password, string ReturnUrl)
        {
            var authSection = configuration.GetSection("Auth");
            string adminLogin = authSection["AdminLogin"];
            string adminPassword = authSection["AdminPassword"];


            if ((username == adminLogin) && (password == adminPassword))
            {
                authenticated = true;

                var claims = new List<Claim>
                 {
                    new Claim(ClaimTypes.Name, username)
                 };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/Admin/Pizzas" : ReturnUrl);
            }
            authenticated = false;
            return Page();
        }

        public async Task<IActionResult> OnGetLogoutAsync(string logoutId)
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin");
        }
    }
}
