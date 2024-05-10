namespace backlogged.API.DTO
{
	public class RootDTO
	{
		public int Count { get; set; }
		public string Next { get; set; }
		public object Previous { get; set; }
		public IReadOnlyList<GameApiDTO> Results { get; set; }
	}
}
