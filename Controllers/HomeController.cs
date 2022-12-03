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
		int count = 4;
		var pages = await _context.Pages.OrderByDescending(p => p.id).Take(3).ToArrayAsync();
		foreach (Page p in pages)
		{
			var media = await _context.Medias.Where(m => m.id == p.mediaID).SingleAsync();
			var category = await _context.Categories.Where(c => c.id == p.categoryID).SingleAsync();
			p.media = media;
			p.category = category;
		}

		var pagesHot = await _context.Pages.OrderByDescending(p => p.views).Take(5).ToArrayAsync();
		foreach (Page p in pagesHot)
		{
			var media = await _context.Medias.Where(m => m.id == p.mediaID).SingleAsync();
			var category = await _context.Categories.Where(c => c.id == p.categoryID).SingleAsync();
			p.media = media;
			p.category = category;
		}

		var pagesWC = await _context.Pages
			.Where(p => p.categoryID == 1)
			.OrderByDescending(p => p.id)
			.Take(count).ToArrayAsync();
		foreach (Page p in pagesWC)
		{
			var media = await _context.Medias.Where(m => m.id == p.mediaID).SingleAsync();
			var category = await _context.Categories.Where(c => c.id == p.categoryID).SingleAsync();
			p.media = media;
			p.category = category;
		}

		var pagesESport = await _context.Pages
			.Where(p => p.categoryID == 6)
			.OrderByDescending(p => p.id)
			.Take(count).ToArrayAsync();
		foreach (Page p in pagesESport)
		{
			var media = await _context.Medias.Where(m => m.id == p.mediaID).SingleAsync();
			var category = await _context.Categories.Where(c => c.id == p.categoryID).SingleAsync();
			p.media = media;
			p.category = category;
		}

		var pagesRace = await _context.Pages
			.Where(p => p.categoryID == 6)
			.OrderByDescending(p => p.id)
			.Take(count).ToArrayAsync();
		foreach (Page p in pagesRace)
		{
			var media = await _context.Medias.Where(m => m.id == p.mediaID).SingleAsync();
			var category = await _context.Categories.Where(c => c.id == p.categoryID).SingleAsync();
			p.media = media;
			p.category = category;
		}

		ViewData["pagesHeader"] = pages;
		ViewData["pagesWC"] = pagesWC;
		ViewData["pagesHot"] = pagesHot;
		ViewData["pagesESport"] = pagesESport;
		ViewData["pagesRace"] = pagesRace;
		ViewData["Title"] = "Trang chủ";
		return View();
	}


}
