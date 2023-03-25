using APIManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIManager.Controllers
{
    public class EngineController : Controller
    {
        public object Index()
        {
            CommonFunction cf = new CommonFunction();
                
            return cf.InvokeFunction("MODULE1");
        }
    }
}
