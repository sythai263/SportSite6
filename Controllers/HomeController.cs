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

	[Route("home/cover")]
	public async Task<IActionResult> GetCover()
	{
		Random ran = new Random();
		var medias = await _context.Medias.ToListAsync();
		var cover = new List<Media>();
		for (int i = 0; i < 3; i++)
		{
			cover.Add(medias.ElementAt<Media>(ran.Next(0, medias.Count)));
		}
		return Json(cover);
	}




}
