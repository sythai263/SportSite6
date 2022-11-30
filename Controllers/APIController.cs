using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using SportSite6.Models;


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

		[Route("api/home/hero")]
		public async Task<IActionResult> GetCover()
		{
			Random ran = new Random();
			var medias = await _context.Medias.ToListAsync();
			var cover = new List<Media>();
			for (int i = 0; i < 3; i++)
			{
				cover.Add(medias.ElementAt<Media>(ran.Next(25, medias.Count)));
			}
			return Json(cover);
		}
	}
}