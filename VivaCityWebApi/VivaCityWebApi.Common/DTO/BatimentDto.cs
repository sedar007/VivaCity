namespace VivaCityWebApi.Common.DTO {
	public class BatimentDto {
		public int Id { get; set; } 
		public string Name { get; set; } = null!;
		public int Level { get; set; }
		public int Type { get; set; }
		public CoutDto Cout { get; set; } = null!;
		public VillageDto Village { get; set; }
		public int? VillageId { get; set; }
		public int? CoutId { get; set; }
	}
}
