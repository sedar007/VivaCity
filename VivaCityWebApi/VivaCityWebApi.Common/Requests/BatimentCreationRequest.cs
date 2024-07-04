using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Common.Requests {
	public class BatimentCreationRequest {
		public string Name { get; init; } = null!;
		
		public string Picture { get; set; } = null!;
		public int Type { get; set; }
		
		public int nbCout { get; set; }
		/*public int? VillageId { get; set; }
		public int? CoutId { get; set; } */
		
		//public VillageDao Village { get; set; } = null!;
		
		//public int RessourceId { get; set; }
	}
}
