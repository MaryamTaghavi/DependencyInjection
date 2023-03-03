using DependencyInjectionLifeTime.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionLifeTime.Controllers
{
    public class LifeTimeController : Controller
    {
        private readonly SingletonService _singletonService;
        private readonly TransientService _transientService;
        private readonly ScopedService _scopedService;

        public LifeTimeController(SingletonService singletonService , TransientService transientService , ScopedService scopedService)
        {
            _singletonService = singletonService;
            _transientService = transientService;
            _scopedService = scopedService;
        } 
        public IActionResult Index()
        {
            var lifeTimeList = new List<string>();
            lifeTimeList.Add($"Singleton Guid From Controller = {_singletonService.GetGuid()}");
            lifeTimeList.Add(HttpContext.Items["SingletoneService"].ToString());
            lifeTimeList.Add("----------------------------------------------------");

            lifeTimeList.Add($"Transient Guid From Controller = {_transientService.GetGuid()}");
            lifeTimeList.Add(HttpContext.Items["TransientService"].ToString());
            lifeTimeList.Add("----------------------------------------------------");

            lifeTimeList.Add($"Scoped Guid From Controller = {_scopedService.GetGuid()}");
            lifeTimeList.Add(HttpContext.Items["ScopedService"].ToString());
            lifeTimeList.Add("----------------------------------------------------");

            ViewData["LifeTimeList"] = lifeTimeList;
            return View();
        }
    }
}
