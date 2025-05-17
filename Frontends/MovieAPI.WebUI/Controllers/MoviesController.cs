using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Dtos.Movie;
using MovieAPI.Application.Features.CQRS.Queries.Movies.GetAllMovie;
using MovieAPI.Application.Features.CQRS.Queries.Movies.GetFilteredMovie;
using Newtonsoft.Json;
using System.Text;

namespace MovieAPI.WebUI.Controllers
{
	public class MoviesController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public MoviesController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
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

		[HttpPost]
		public async Task<IActionResult> MovieList(MovieFilterModel filter)
		{
			var client = _httpClientFactory.CreateClient();

			// Eğer filtre tamamen boşsa, tüm listeyi getirelim (isteğe bağlı)
			bool isFilterEmpty = filter == null ||
				(string.IsNullOrWhiteSpace(filter.Title) &&
				 (filter.CategoryIds == null || filter.CategoryIds.Count == 0) &&
				 filter.MinRating == null &&
				 filter.MaxRating == null &&
				 filter.StartYear == null &&
				 filter.EndYear == null);

			List<ResultMovieDto> movies = new();

			if (isFilterEmpty)
			{
				var responseMessage = await client.GetAsync("https://localhost:44339/api/Movies/GetAllMovies");
				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var response = JsonConvert.DeserializeObject<GetAllMovieQueryResponse>(jsonData);
					movies = response?.Movies ?? new List<ResultMovieDto>();
				}
			}
			else
			{
				var jsonContent = new StringContent(JsonConvert.SerializeObject(filter), Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("https://localhost:44339/api/Movies/filter", jsonContent);

				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					// Burada da aynı tipi kullanıyoruz:
					var response = JsonConvert.DeserializeObject<GetAllMovieQueryResponse>(jsonData);
					movies = response?.Movies ?? new List<ResultMovieDto>();
				}
			}

			ViewBag.Filter = filter;
			return View(movies);
		}


		public async Task<IActionResult> MovieDetail(int id)
		{
			id = 0;
			return View();
		}
		
	}
}
