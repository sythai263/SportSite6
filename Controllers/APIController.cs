using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using SportSite6.Models;
using SportSite6.Dto;
using SportSite6.Utils;


namespace SportSite6.Controllers
{
	public class APIController : Controller
	{

		private readonly ILogger<HomeController> _logger;
		private readonly DBContext _context;

		public APIController(ILogger<HomeController> logger, DBContext context)
		{
			_logger = logger;
			_context = context;
		}

		[Route("api/news")]
		public async Task<IActionResult> GetNews()
		{
			int take = 5;
			int page = 1;

			var query = HttpContext.Request.Query;
			if (query["take"].ToString() != null)
			{
				take = Int32.Parse(query["take"].ToString());
			}

			if (query["page"].ToString() != null)
			{
				page = Int32.Parse(query["page"].ToString());
			}

			var pages = await _context.Pages
			.OrderByDescending(p => p.id)
			.Skip(take * page)
			.Take(take)
			.ToArrayAsync();
			foreach (Page p in pages)
			{
				var media = await _context.Medias.Where(m => m.id == p.mediaID).SingleAsync();
				var category = await _context.Categories.Where(c => c.id == p.categoryID).SingleAsync();
				p.media = media;
				p.category = category;
			}
			return Json(pages);
		}

		[Route("api/hot-news")]
		public async Task<IActionResult> HotNews()
		{
			var pagesHot = await _context.Pages.OrderByDescending(p => p.views).Take(5).ToArrayAsync();
			foreach (Page p in pagesHot)
			{
				var media = await _context.Medias.Where(m => m.id == p.mediaID).SingleAsync();
				var category = await _context.Categories.Where(c => c.id == p.categoryID).SingleAsync();
				p.media = media;
				p.category = category;
			}
			return Json(pagesHot);
		}

		[Route("api/pages/{id}/contents")]
		public async Task<IActionResult> GetContents(int id)
		{
			var contents = await _context.Contents.Where(c => c.pageID == id).ToArrayAsync();

			foreach (var con in contents)
			{
				if (con.mediaID != null)
				{
					var media = await _context.Medias.Where(m => m.id == con.mediaID).SingleAsync();
					con.media = media;
				}
				var category = await _context.Pages.Where(c => c.id == con.pageID).SingleAsync();
				con.page = category;
			}
			return Json(contents);
		}

		[Route("api/pages/{id}/related")]
		public async Task<IActionResult> GetRelated(int id)
		{
			var page = await _context.Pages.Where(p => p.id == id).SingleAsync();
			var pages = await _context.Pages
				.Where(p => p.id != id && p.categoryID == page.categoryID)
				.OrderByDescending(p => p.id)
				.Take(3)
				.ToListAsync();

			foreach (Page p in pages)
			{
				var media = await _context.Medias.Where(m => m.id == p.mediaID).SingleAsync();
				var category = await _context.Categories.Where(c => c.id == p.categoryID).SingleAsync();
				p.media = media;
				p.category = category;
			}

			return Json(pages);
		}
		

		[HttpPost]
		[Route("api/comments")]
		public async Task<IActionResult> CreateComment(CommentDto dto)
		{
			var page = await _context.Pages.Where(p => p.id == dto.pageID).SingleAsync();

			var users = await _context.Users
				.Where(u => u.email.Equals(dto.email)).ToListAsync();
			var user = new User { };
			var username = Utils.Utils.RemoveVietnameseTone(dto.name);
			username = username.Trim().Replace(" ", "_");
			if (users.Count == 0)
			{
				user = new User { email = dto.email, name = dto.name, username = username, birthday = DateTime.Now, gender = 0 };
				await _context.Users.AddAsync(user);
				await _context.SaveChangesAsync();
			}
			user = await _context.Users
				.Where(u => u.email.Equals(dto.email)).SingleAsync();

			var comment = new Evaluation { pageID = dto.pageID, userID = user.id, content = dto.content, createdAt = DateTime.Now };

			await _context.Evaluations.AddAsync(comment);
			await _context.SaveChangesAsync();

			return Json(comment);
		}

		[HttpGet]
		[Route("api/pages/{id}/comments")]
		public async Task<IActionResult> GetComment()
		{
			int take = 5;
			int page = 1;

			var query = HttpContext.Request.Query;
			if (query["take"].ToString() != null)
			{
				take = Int32.Parse(query["take"].ToString());
			}

			if (query["page"].ToString() != null)
			{
				page = Int32.Parse(query["page"].ToString());
			}

			var comments = await _context.Evaluations
			.OrderByDescending(p => p.id)
			.Skip(take * page)
			.Take(take)
			.ToArrayAsync();

			foreach (var item in comments)
			{
				var user = _context.Users.Where(u => u.id == item.userID).Single();
				item.user = user;
			}

			return Json(comments);
		}

		[Route("api/categories/{id}/news")]
		public async Task<IActionResult> GetNewsCategory(int id)
		{
			var category = await _context.Categories.Where(c=>c.id == id ).SingleAsync();

			int take = 5;
			int page = 1;

			var query = HttpContext.Request.Query;
			if (query["take"].ToString() != null)
			{
				take = Int32.Parse(query["take"].ToString());
			}

			if (query["page"].ToString() != null)
			{
				page = Int32.Parse(query["page"].ToString());
			}

			var pages = await _context.Pages
			.Where(p=>p.categoryID == id)
			.OrderByDescending(p => p.id)
			.Skip(take * page)
			.Take(take)
			.ToArrayAsync();
			foreach (Page p in pages)
			{
				var media = await _context.Medias.Where(m => m.id == p.mediaID).SingleAsync();
				p.media = media;
			}
			return Json(pages);
		}
	}
}