using System.Collections;
using System.Text.Json.Nodes;

namespace APIManager.Models
{
    public class Outputenum
    {
        public string STATUS { get; set; }
        public string StatusMessage { get; set; }
        public List<Hashtable> output { get; set; }
    }
}
