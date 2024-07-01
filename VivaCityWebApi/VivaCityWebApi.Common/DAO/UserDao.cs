namespace VivaCityWebApi.Common.DAO;

public class UserDao {
    public int Id { get; set; }
    public string Pseudo { get; set; } = null!;
    public IEnumerable<VillageDao> Villages {get; set;} = null!;
    public double Scores { get; set; } = 0!;
}