using Azure;
using backloggd.API.Services;
using backlogged.API.DTO;
using backlogged.MVC.Models;
using backlogged.MVC.ViewModels;
using Booky.MVC.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace backlogged.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly Ibackloggedservice Ibackloggedservice;

		public HomeController(ILogger<HomeController> logger, Ibackloggedservice Ibackloggedservice)
        {
            _logger = logger;
			this.Ibackloggedservice = Ibackloggedservice;

		}


	
		public async Task<IActionResult> Index()
        {
			var HomeViewModel = new HomeViewModel();
			try
			{
				var gamesResponse = await Ibackloggedservice.getAllfromApiAsync<Apiresponse>();
				var upcominggamesResponse = await Ibackloggedservice.getupcominggamesfromApiAsync<Apiresponse>();
				var gamingbygenra = await Ibackloggedservice.getAllfromApiAsync<Apiresponse>("indie");

				if (gamesResponse.IsSucssess)
				{
					var listoffgames = JsonConvert.DeserializeObject<RootDTO>(Convert.ToString(gamesResponse.Result)).Results.OrderBy(x => x.SuggestionsCount).Take(6).ToList();
					HomeViewModel.TrendingGames = listoffgames;
				}
				else
				{
					return StatusCode((int)gamesResponse.StatusCode, "Failed to retrieve Games");
				}
				if(gamingbygenra.IsSucssess)
				{
					var listoffgames = JsonConvert.DeserializeObject<RootDTO>(Convert.ToString(gamingbygenra.Result)).Results.Take(6).ToList();
					HomeViewModel.SleepingHits = listoffgames;
				}
				if (upcominggamesResponse.IsSucssess)
				{
					var upcominglistoffgames = JsonConvert.DeserializeObject<RootDTO>(Convert.ToString(upcominggamesResponse.Result)).Results.OrderBy(x => x.SuggestionsCount).ToList();
					HomeViewModel.UpcomingGames = upcominglistoffgames.Take(6).ToList();
					HomeViewModel.Recentlyanticipated = upcominglistoffgames.Skip(6).Take(6).ToList();
				}
				else
				{
					return StatusCode((int)gamesResponse.StatusCode, "Failed to retrieve Games");
				}
				return View(HomeViewModel);

			}
			catch (Exception ex)
			{
				// Handle any exceptions that occur during the process
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
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
