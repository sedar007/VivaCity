using VivaCityWebApi.Common.DAO;
namespace VivaCityWebApi.Common.Requests {
	public class RessourceCreationRequest {
		public int Nbr { get; set; } 
		public int Max { get; set; } 
		public int? RessourceItemId { get; set; }
		
		public int? VillageId { get; set; }
		public RessourceItemDao RessourceItem { get; set; } = null!; 
	}
}
