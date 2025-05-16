using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Dtos.Movie;
using MovieAPI.Application.Features.CQRS.Queries.Categories.GetAllCategory;
using MovieAPI.Application.Features.CQRS.Queries.Movies.GetAllMovie;
using MovieAPI.Application.Repositories.Category;
using MovieAPI.Application.Repositories.Movie;
using MovieAPI.WebUI.ViewModels;
using Newtonsoft.Json;

namespace MovieAPI.WebUI.Controllers
{
	public class MoviesController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public MoviesController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> MovieList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44339/api/Movies/GetAllMovies");

			List<ResultMovieDto> movies = new();
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var response = JsonConvert.DeserializeObject<GetAllMovieQueryResponse>(jsonData);
				movies = response?.Movies ?? new List<ResultMovieDto>(); //null-coalescing operatörü: Sol taraf null ise sağ taraf kullanılır.
			}

			return View(movies);

		}

		public async Task<IActionResult> MovieDetail(int id)
		{
			id = 0;
			return View();
		}
		
	}
}
