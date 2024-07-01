namespace VivaCityWebApi.Common.Requests;

public class UserAddVillageRequest
{
    public int IdUser { get; init; }
    public string VillageName { get; init; } = null!;
    
}