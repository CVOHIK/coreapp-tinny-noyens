using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace TNS_Musicstore.Controllers
{
	public class StoreController : Controller
    {

		private readonly StoreContext _context;

		public StoreController(StoreContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
            return View();
        }

		public IActionResult ListGenres()
		{
			var genres = _context.Genres.OrderBy(g => g.Name);
			return View(genres);
		}

		public IActionResult Details(int? id)
		{
			//eerst controleren of er een id wordt meegegeven
			if (id == null || id == 0)
			{
				return NotFound();
			}
			//als id niet leeg of nul is album maken waar album id == aan id dat meegegeven is
			var album = _context.Albums.Include(a => a.Genre).Include(a => a.Artist).Where(a => a.AlbumID == id).Single();
			// view van gevonden album teruggeven
			return View(album);
		}

		public IActionResult ListAlbums(int? genreID)
		{
			var albums = from a in _context.Genres.OrderBy(a => a.Description).Include(g => g.GenreID)
							select a;


			//dan controleren of er een id wordt meegegeven
			if (genreID != null && genreID != 0)
			{
				albums = albums.Where(a => a.GenreID == genreID);
			}
			return View(albums);
		}
		
	}
}