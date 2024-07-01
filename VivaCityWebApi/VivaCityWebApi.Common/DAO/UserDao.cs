namespace VivaCityWebApi.Common.DAO;

public class UserDao {
    public int Id { get; set; }
    public string Pseudo { get; set; } = null!;
    public IList<VillageDao> Villages {get; set;} = null!;
    public double Scores { get; set; } = 0!;
}