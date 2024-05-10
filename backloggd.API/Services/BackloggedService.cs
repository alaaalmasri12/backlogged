using backloggd.MVC.Models;
using backloggd.MVC.Services;
using backlogged.API.DTO;
using backlogged.Core.Models;
using Booky.MVC.DTO;
using static backlogged.Utility.StaticDetails;

namespace backloggd.API.Services
{
	public class BackloggedService : BaseService, Ibackloggedservice
	{
		private readonly IHttpClientFactory _httpClient;
		private string ApiURL;
		public BackloggedService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
		{
			_httpClient = httpClient;
			ApiURL = configuration.GetValue<string>("ServicesUrl:Apiurl");
		}

		public Task<T> CreateAsync<T>(GameApiDTO GameApiDTO)
		{
			throw new NotImplementedException();
		}

	
		public Task<T> DeleteAsync<T>(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<T> getAllAsync<T>()
		{
			var request = new ApiRequest();

			request.ApiType = ApiType.GET;
			request.Url =this.ApiURL+ "/api/Backlogged/";
			return await sendAsunc<T>(request);
		}

		public async Task<T> getAllfromApiAsync<T>()
		{
			var request = new ApiRequest();

			request.ApiType = ApiType.GET;
			request.Url = this.ApiURL + "/api/Backlogged/getAllbyapi";
			return await sendAsunc<T>(request);
		}

		public Task<T> getbyidAsync<T>(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<T> getupcominggamesfromApiAsync<T>()
		{
			var request = new ApiRequest();

			request.ApiType = ApiType.GET;
			request.Url = this.ApiURL + "/api/Backlogged/getupcominggames";
			return await sendAsunc<T>(request);
		}
		



		public Task<T> UpdateAsync<T>(GameApi estateDto)
		{
			throw new NotImplementedException();
		}

		
		public Task<T> UpdateAsync<T>(GameApiDTO GameApiDTO)
		{
			throw new NotImplementedException();
		}

		public async Task<T> getAllfromApiAsync<T>(string genra)
		{
			var request = new ApiRequest();

			request.ApiType = ApiType.GET;
			request.Url = this.ApiURL + "/api/Backlogged/getAllbyapi/?Genra=" + genra;
			return await sendAsunc<T>(request);
		}
	}
}
