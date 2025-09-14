namespace LifeTime2; 

public class Repository
{
    private readonly DatabaseContext _dataContext;
    public Repository(DatabaseContext dataContext)
    {
        _dataContext = dataContext;
    }

    public int RowCount => _dataContext.RowCount ;
}
