#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace EMSI.Fuga.Infrastructure.DAO;

public class PassengerDAO
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Tel { get; set; }
    public string Nationality { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? PassportNumber { get; set; }
}