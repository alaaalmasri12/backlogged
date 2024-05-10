using backlogged.API.DTO;
using Booky.MVC.DTO;

namespace backloggd.API.Services
{
	public interface Ibackloggedservice
	{
		Task<T> getAllAsync<T>();
		Task<T> getAllfromApiAsync<T>();
		Task<T> getAllfromApiAsync<T>(string genra);

		Task<T> getupcominggamesfromApiAsync<T>();

		Task<T> getbyidAsync<T>(int id);
		Task<T> CreateAsync<T>(GameApiDTO GameApiDTO);
		Task<T> UpdateAsync<T>(GameApiDTO GameApiDTO);
		Task<T> DeleteAsync<T>(int id);
	}
}
