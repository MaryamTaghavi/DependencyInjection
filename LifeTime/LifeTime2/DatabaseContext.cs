namespace LifeTime2;

public class DatabaseContext
{
    static readonly Random _random = new Random();
    public int RowCount { get; }
    public DatabaseContext()
    {
        RowCount = _random.Next(1, 1_000_000_000);
    }
}
