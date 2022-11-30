using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SportSite6.Models;

namespace SportSite6.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly DBContext _context;

	public HomeController(ILogger<HomeController> logger, DBContext context)
	{
		_logger = logger;
		_context = context;
	}
	[Route("")]
	[Route("trang-chu")]
	public async Task<IActionResult> Index()
	{
		var user = await _context.Users.ToListAsync();
		return Json(user);
	}

	[Route("chinh-sach")]
	public IActionResult Privacy()
	{
		return View();
	}
}
