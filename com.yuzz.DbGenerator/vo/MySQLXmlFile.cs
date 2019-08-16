using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace com.yuzz.DbGenerator.vo {
    [Serializable]
    public class MySQLXmlFile {
        [JsonProperty("dbip")]
        public string dbip { get; internal set; }
        [JsonProperty("port")]
        public string port { get; internal set; }
        [JsonProperty("user")]
        public string user { get; internal set; }
        [JsonProperty("pwd")]
        public string pwd { get; internal set; }
        [JsonProperty("schema")]
        public string schema { get; set; }
        [JsonProperty("SavePath")]
        public string SavePath { get; internal set; }
    }
}
