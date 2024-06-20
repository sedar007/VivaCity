namespace VivaCityWebApi.Common.DTO {
	public class CoutDto {
		public int Id { get; set; } 
		public int Nbr { get; set; } 
		public RessourceDto Ressource { get; set; } = null!;
		public int? RessourceId { get; set; }
	}
}
