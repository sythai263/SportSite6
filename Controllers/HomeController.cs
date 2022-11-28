using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportSite6.Models;

namespace SportSite6.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}
	[Route("trang-chu")]
	public IActionResult Index()
	{
		return View();
	}

	[Route("chinh-sach")]
	public IActionResult Privacy()
	{
		return View();
	}
}
