namespace Domain.Entities;

public class User
{
    // Required columns
    public int Id { get; set; }
    public string Username { get; set; }
    public byte[] Password { get; set; }
}