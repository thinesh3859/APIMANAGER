using System.Text.Json.Nodes;

namespace APIManager.Models
{
    public class Outputenum
    {
        public string STATUS { get; set; }
        public string StatusMessage { get; set; }
        public JsonArray output { get; set; }
    }
}
