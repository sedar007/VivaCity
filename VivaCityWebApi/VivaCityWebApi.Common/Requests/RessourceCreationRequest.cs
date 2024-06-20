using VivaCityWebApi.Common.DAO;
namespace VivaCityWebApi.Common.Requests {
	public class RessourceCreationRequest {
		public int Nbr { get; set; } 
		public int Max { get; set; } 
		public int? RessourceId { get; set; }
	}
}
