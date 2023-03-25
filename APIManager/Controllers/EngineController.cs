using APIManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIManager.Controllers
{
    public class EngineController : Controller
    {
       // [HttpGet]
        public object Index()
        {
            var a =  Request.Method;
            CommonFunction cf = new CommonFunction();
            return cf.InvokeFunction("MODULE1");
        }

        [HttpPost]
        public object PostAPI()
        {
            CommonFunction cf = new CommonFunction();

            return cf.InvokeFunction("MODULE2");
        }
    }
}
