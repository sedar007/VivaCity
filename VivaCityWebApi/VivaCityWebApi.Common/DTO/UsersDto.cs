namespace VivaCityWebApi.Common.DTO;

public class UsersDto
{
    public string Pseudo { get; set; } = null!;
    public int Id { get; set; }
    public IEnumerable<VillageDto> Villages {get; set;} = null!;
    public double Scores { get; set; } = 0!;
}


