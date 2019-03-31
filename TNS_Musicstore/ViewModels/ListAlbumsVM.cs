using Microsoft.AspNetCore.Mvc.Rendering;
using MusicStore.Models;
using System.Collections.Generic;

namespace TNS_Musicstore.ViewModels
{
	public class ListAlbumsVM
	{
		public List<Album> Albums { get; set; }
		public SelectList Genres { get; set; }
		public SelectList Artists { get; set; }

		public int GenreID { get; set; }

		public int ArtistID { get; set; }
		
		//trefwoord titel
		public string Keyword { get; set; }
	}
}
