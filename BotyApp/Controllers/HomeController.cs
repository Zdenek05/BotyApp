using System.Diagnostics;
using BotyApp.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using BotyApp.Models;

namespace BotyApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}