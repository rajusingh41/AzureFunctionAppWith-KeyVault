using functionApp;
using Newtonsoft.Json.Linq;

namespace functionApp
{
    public class ApiConfig
    {
        public string EndpointUrl { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string DatabaseAlias { get; set; }
        public string CacheTimeInMinutes { get; set; }
        public OtherConfig OtherConfig { get; set; }
    }
     public class OtherConfig
    {
        public string Token { get; set; }
    }
}
