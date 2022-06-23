using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace MyWeb.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //private async Task RefreshTokenAsync()
        //{
        //    var authrizationServerInformation =
        //        await DiscoveryClient.GetAsync("https://localhost:44358");
        //    var client = new TokenClient(authrizationServerInformation.TokenEndpoint, "IdentityServer4", "secret");
        //    var refreshToken= await HttpContext.authantication
        //}
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task Logout()
        {
            //    await HttpContext.Authentication.SignOutAsync("Cookies");
            //    await HttpContext.Authentication.SignOutAsync("oidc");
            await this.HttpContext.SignOutAsync("Cookies");
            await this.HttpContext.SignOutAsync("oidc");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
