namespace VivaCityWebApi.Common.DAO;

public class BatimentDao
{
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public int Level { get; set; }
    public CoutDao cout { get; set; } = null!;
    public VillageDao? Village { get; set; }
    public int? VillageId { get; set; }
}