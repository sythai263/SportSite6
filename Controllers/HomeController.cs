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
		string cover = "";
		var pages = await _context.Pages.OrderByDescending(p => p.id).ToArrayAsync();
		foreach (Page p in pages)
		{
			var media = await _context.Medias.Where(m => m.id == p.mediaID).SingleAsync();
			var category = await _context.Categories.Where(c => c.id == p.categoryID).SingleAsync();
			p.media = media;
			p.category = category;
		}
		ViewData["pages"] = pages;
		return View();
	}


}
