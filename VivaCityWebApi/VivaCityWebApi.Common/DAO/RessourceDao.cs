namespace VivaCityWebApi.Common.DAO {
	public class RessourceDao
	{
		public int Id { get; set; } 
		public RessourceItemDao RessourceItem { get; set; } = null!;
		public int Nbr { get; set; } 
		public int Max { get; set; }
		public int? VillageId { get; set; }
		public int? RessourceItemId { get; set; }
	}
}
