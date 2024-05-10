namespace backlogged.API.DTO
{
	public class GamePlatformDTO
	{
		public PlatformDTO Platform { get; set; }
		public DateTime ReleasedAt { get; set; }
		public object RequirementsEn { get; set; }
		public object RequirementsRu { get; set; }
	}
}
