using backlogged.API.DTO;

namespace backlogged.MVC.ViewModels
{
	public class  HomeViewModel
	{
        public List<GameApiDTO> TrendingGames =new List<GameApiDTO>();
		public List<GameApiDTO> UpcomingGames = new List<GameApiDTO>();
		public List<GameApiDTO> Recentlyanticipated = new List<GameApiDTO>();
		public List<GameApiDTO> SleepingHits = new List<GameApiDTO>();


	}
}
