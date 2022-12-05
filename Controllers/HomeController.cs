using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportSite6.Models;
using System.Net;

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

		var pagesAff = await _context.Pages
			.Where(p => p.categoryID == 3)
			.OrderByDescending(p => p.id)
			.Take(count).ToArrayAsync();
		foreach (Page p in pagesAff)
		{
			var media = await _context.Medias.Where(m => m.id == p.mediaID).SingleAsync();
			var category = await _context.Categories.Where(c => c.id == p.categoryID).SingleAsync();
			p.media = media;
			p.category = category;
		}

		ViewData["pagesHeader"] = pages;
		ViewData["pagesWC"] = pagesWC;
		ViewData["pagesESport"] = pagesESport;
		ViewData["pagesAff"] = pagesAff;
		ViewData["script"] = "/js/home.js";
		ViewData["Title"] = "Trang chủ";
		return View();
	}

	[Route("tin-tuc/{slug}")]
	public async Task<IActionResult> SinglePost(string slug)
	{
		var page = await _context.Pages.Where(p => p.slug.Equals("/tin-tuc/"+slug)).SingleAsync();
		page.views += 1;
		var media = await _context.Medias.Where(m => m.id == page.mediaID).SingleAsync();
		var category = await _context.Categories.Where(c => c.id == page.categoryID).SingleAsync();
		page.media = media;
		page.category = category;
		await _context.SaveChangesAsync();
		ViewData["page"] = page;
		ViewData["script"] = "/js/single-post.js";
		ViewData["Title"] = page.title;
		return View();
	}

	[Route("danh-muc/{slug}")]
	public async Task<IActionResult> CategoryPage(string slug)
	{
		var category = await _context.Categories.Where(p => p.slug.Equals(slug)).SingleAsync();
		var media = await _context.Medias.Where(m=>m.id == category.mediaID).SingleAsync();
		category.media = media;
		ViewData["category"] = category;
		ViewData["script"] = "/js/category.js";
		ViewData["Title"] = category.title;
		return View();
	}

	[Route("/error")]
	public IActionResult Error(){
		return View();
	}
}
