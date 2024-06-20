namespace VivaCityWebApi.Common.DAO;

public class VillageDao
{
    public int Id { get; set; }
    public IEnumerable<BatimentDao> batiments { get; set; } = null!;
    public UserDao? User { get; set; }
    public int? UserId { get; set; }
}