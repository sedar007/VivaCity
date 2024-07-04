namespace VivaCityWebApi.Common.DTO {
	public class RessourceDto {
		public int Id { get; set; } 
		public RessourceItemDto RessourceItem { get; set; } = null!;
		public int Nbr { get; set; } 
		public int Max { get; set; }
		//public int? RessourceItemId { get; set; }
		
		public int? VillageId { get; set; }
	}
}






