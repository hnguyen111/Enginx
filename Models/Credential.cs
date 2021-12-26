namespace API.Models;

public class Credential
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public byte[]? PasswordHash { get; set; }
}