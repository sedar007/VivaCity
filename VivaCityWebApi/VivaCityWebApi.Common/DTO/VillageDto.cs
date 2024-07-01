namespace VivaCityWebApi.Common.DTO {
	public class VillageDto {
		public int Id { get; set; }
		public IEnumerable<BatimentDto> Batiments { get; set; } = null!;
		public IEnumerable<RessourceDto> Ressources {get; set;} = null!;
		public UsersDto? User { get; set; }
		public int? UserId { get; set; }
	}
}
