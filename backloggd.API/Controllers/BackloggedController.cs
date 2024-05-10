using backlogged.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using backlogged.Repostiory.GenericRepository;
using backlogged.Core.IGenericRepository;
using backlogged.Core.Models;
using Apiresponse = backlogged.Core.Models.Apiresponse;
using AutoMapper;
using backlogged.API.DTO;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Booky.MVC.DTO;
using Newtonsoft.Json;
using Azure;

namespace backloggd.API.Controllers
{
	//https://localhost:7227/api/Backlogged/apimethod
	[ApiController]
	public class BackloggedController : Controller
	{
		private readonly HttpClient _httpClient;
		protected Apiresponse _apiresponse;
		private string gameapiurl;
		private string ApiKey;
		public BackloggedController(  HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_apiresponse = new Apiresponse();
			gameapiurl = configuration.GetValue<string>("ServicesUrl:Apigameurl");
			ApiKey = configuration.GetValue<string>("ServicesUrl:ApiKey");

		}
		[Route("api/[controller]/getAllbyapi")]
		[HttpGet]
		public async Task<ActionResult<Apiresponse>> getAllbyapi( int? pageNumber, int? pageSize,string? Genra)
		{
			if(Genra !=null)
			{
                HttpResponseMessage response2 = await _httpClient.GetAsync(gameapiurl + ApiKey+ "&genres="+Genra);
				if (response2.IsSuccessStatusCode)
				{
                    string apiResponse2 = await response2.Content.ReadAsStringAsync();

                    var listofgames = JsonConvert.DeserializeObject<RootDTO>(Convert.ToString(apiResponse2));
                    _apiresponse.Result = listofgames;
                    _apiresponse.StatusCode = HttpStatusCode.OK;
                    _apiresponse.IsSucssess = true;
                    return Ok(_apiresponse);
                }
                }
			else
			{
                HttpResponseMessage response = await _httpClient.GetAsync(gameapiurl + ApiKey);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var listofgames = JsonConvert.DeserializeObject<RootDTO>(Convert.ToString(apiResponse));
                    _apiresponse.Result = listofgames;
                    _apiresponse.StatusCode = HttpStatusCode.OK;
                    _apiresponse.IsSucssess = true;
                    return Ok(_apiresponse);
                }
                else
                {
                    return Ok();
                }
            }

            return Ok();

        }

        [Route("api/[controller]/getupcominggames")]
		[HttpGet]
		public async Task<ActionResult<Apiresponse>> getupcominggames()
		{
			DateTime currentDateTime = DateTime.Now;
			DateTime upcomingDateTime = DateTime.Now.AddYears(1);
			// Format the date as day-month-year
			string currentdDate = currentDateTime.ToString("yyyy-MM-dd");
			string upcomingDate = upcomingDateTime.ToString("yyyy-MM-dd");

			HttpResponseMessage response = await _httpClient.GetAsync(gameapiurl + ApiKey+ "&dates="+ currentdDate+","+ upcomingDate);
			if (response.IsSuccessStatusCode)
			{
				string apiResponse = await response.Content.ReadAsStringAsync();
				var listofgames = JsonConvert.DeserializeObject<RootDTO>(Convert.ToString(apiResponse));
				_apiresponse.Result = listofgames;
				_apiresponse.StatusCode = HttpStatusCode.OK;
				_apiresponse.IsSucssess = true;
				return Ok(_apiresponse);
			}
			else
			{
				return Ok();
			}

		}
	}
}
