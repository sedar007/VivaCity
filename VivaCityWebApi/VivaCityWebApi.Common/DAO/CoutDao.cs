namespace VivaCityWebApi.Common.DAO {
	public class CoutDao
	{
		public int Id { get; set; } 
		public int Nbr { get; set; } 
		public RessourceDao Ressource { get; set; } = null!;
		public int? RessourceId { get; set; }
	}
}
