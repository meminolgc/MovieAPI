using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Features.CQRS.Queries.Movies.GetAllMovie;
using MovieAPI.Dto.DTOs.MovieDtos;
using Newtonsoft.Json;

namespace MovieAPI.WebUI.Controllers
{
	public class MoviesController : Controller
	{
		 readonly IHttpClientFactory _httpClientFactory;

		public MoviesController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> MovieList()
		{
			@ViewBag.v1 = "Film Listesi";
			@ViewBag.v2 = "Ana Sayfa";
			@ViewBag.v3 = "Tüm Filmler";

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
	}
}

//DTO katmanı oluşturulacak 
//API adresi hardcoded (çıkarılacak) //appsettings dosyasından al. 
//var baseUrl = _configuration["ApiBaseUrl"];
//var responseMessage = await client.GetAsync($"{baseUrl}/api/Movies/GetAllMovies");
