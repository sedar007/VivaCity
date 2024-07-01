namespace VivaCityWebApi.Common.Requests {
	public class RessourceItemUpdateRequest {
		public int Id { get; init; }
		public string Picture { get; init; } = null!;
		public string Name { get; init; } = null!;
	}
}
