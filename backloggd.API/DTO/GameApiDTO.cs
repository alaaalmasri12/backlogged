namespace backlogged.API.DTO
{
	public class GameApiDTO
	{
		public int Id { get; set; }
		public string Slug { get; set; }
		public string Name { get; set; }
		public DateTime Released { get; set; }
		public bool Tba { get; set; }
		public string background_image { get; set; }
		public double Rating { get; set; }
		public int RatingTop { get; set; }
		//public IReadOnlyList<RatingDTO> Ratings { get; set; }
		//public int RatingsCount { get; set; }
		//public int ReviewsTextCount { get; set; }
		//public int Added { get; set; }
		//public AddedByStatusDTO AddedByStatus { get; set; }
		//public int Metacritic { get; set; }
		//public int Playtime { get; set; }
		public int SuggestionsCount { get; set; }
		//public DateTime Updated { get; set; }
		//public object UserGame { get; set; }
		//public int ReviewsCount { get; set; }
		//public string SaturatedColor { get; set; }
		//public string DominantColor { get; set; }
		//public IReadOnlyList<GamePlatformDTO> Platforms { get; set; }
		//public IReadOnlyList<GenreDTO> Genres { get; set; }
		//public IReadOnlyList<StoreDTO> Stores { get; set; }
		//public object Clip { get; set; }
		//public IReadOnlyList<object> Tags { get; set; }
		//public object EsrbRating { get; set; }
		//public IReadOnlyList<object> ShortScreenshots { get; set; }
	}
}
