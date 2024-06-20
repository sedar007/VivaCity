namespace VivaCityWebApi.Common.DTO {
	public class RessourceDto {
		public int Id { get; set; } 
		public RessourceItemDto RessourceItem { get; set; } = null!;
		public double Nbr { get; set; } 
		public double Max { get; set; }
		public int? RessourceItemId { get; set; }
		
		public int? VillageId { get; set; }
	}
}






