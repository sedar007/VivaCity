namespace VivaCityWebApi.Common.DAO {
	public class RessourceDao
	{
		public int Id { get; set; } 
		public RessourceItemDao RessourceItem { get; set; } = null!;
		public double Nbr { get; set; } 
		public double Max { get; set; } 
	}
}
