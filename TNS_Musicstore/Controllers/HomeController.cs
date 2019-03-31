using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using System;
using System.Diagnostics;
using System.Linq;
using TNS_Musicstore.Models;

namespace TNS_Musicstore.Controllers
{
	public class HomeController : Controller
	{

		private readonly StoreContext _context;

		public HomeController(StoreContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var albums = _context.Albums.OrderBy(a => Guid.NewGuid()).Take(6);
			return View(albums.ToList());
		}

		[Authorize (Roles = "admin")]
		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
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
