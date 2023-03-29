using APIManager.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Text;
using System.Text.Json.Nodes;

namespace APIManager.Controllers
{
    public class EngineController : SecurityController
    {
       // [HttpGet]
        public object Index()
        {
            var a =  Request.Method;
            CommonFunction cf = new CommonFunction();
            return cf.InvokeFunction("MODULE1");
        }


      
        public async Task<JsonResult> PostAPI()
        {

            Outputenum oe = new Outputenum();
            Security sec = new Security();
            string ip = "";
            Inputenum InputJson = new Inputenum() ;
            CommonFunction cf = new CommonFunction();
            DBComponent db = new DBComponent();

            //Check security valid IPAddress client

            ip = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (sec.IsValidIpAddress(ip))
            {

                string rawValue = "";

                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    rawValue = await reader.ReadToEndAsync();
                }

                 InputJson = JsonConvert.DeserializeObject<Inputenum>(rawValue);

                 oe=  cf.ValidateRequest(InputJson);

                 db.SelectStatement(QueryManager.VALIDATE_UC_ID, QueryManager.MSSQL);

                 if ( oe.STATUS == null)
                 {
                    oe = cf.InvokeRequest(InputJson);

                 }
            }
            else
            {
                oe.STATUS = "F";
                oe.StatusMessage = "IP Not whitelisted";
                oe.output = new JsonArray();
                this.HttpContext.Response.StatusCode = 401; // Unauthorized
            }

          

            return Json(oe);
        }
    }
}
