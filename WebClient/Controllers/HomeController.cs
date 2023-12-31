﻿using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebClient.Constants;
using WebClient.Models;
using WebDAL.Entities;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            ViewBag.Name = User.Identity.Name;
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            
            var accountCookie = ControllerContext.HttpContext.Request.Cookies[CookieNames.Account] ?? "{}";
            var account = JsonSerializer.Deserialize<Account>(accountCookie);
            account.name ??= "Незнакомец";
            return View(account);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult AccessDenied()
        {
            return View();
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}