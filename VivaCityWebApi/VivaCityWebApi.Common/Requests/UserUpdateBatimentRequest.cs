using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Common.Requests {
	public class UserUpdateBatimentRequest {
		public int IdBatiment { get; set; }
		public int IdUser { get; set; }
		
		public int IdVillage { get; set; }
		
	}
}
