#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace EMSI.Fuga.Config;

public class DatabaseConfig
{
    public string ConnectionString { get; set; }
}