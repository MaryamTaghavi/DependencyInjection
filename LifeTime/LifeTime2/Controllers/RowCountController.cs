using Microsoft.AspNetCore.Mvc;

namespace LifeTime2.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class RowCountController : ControllerBase
{
    private readonly Repository _repositiry;
    private readonly DatabaseContext _dbContext;

    public RowCountController(Repository repositiry, DatabaseContext dbContext)
    {
        _repositiry = repositiry;
        _dbContext = dbContext;
    }

    [HttpGet]
    public RowCountViewModel Index()
    {
        // اگر lifetime مربوط به Repository , DatabaseContext
        // Transient باشد نتیجه این دو دو عدد متفاوت است
        // ولی اگر scoped باشد یکسان است

        var viewModel = new RowCountViewModel
        {
            DataContextCount = _dbContext.RowCount,
            RepositoryCount = _repositiry.RowCount
        };

        return viewModel;
    }
}
