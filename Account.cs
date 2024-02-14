namespace ConsoleApp2;

class Account
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}