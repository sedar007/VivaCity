namespace VivaCityWebApi.Common.Requests;

public class UserCreationRequest
{
    public string Pseudo { get; init; } = null!;
    public string Name { get; init; } = null!;
    //public string Id { get; init; } = null!;
}