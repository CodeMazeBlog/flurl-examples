using Newtonsoft.Json;

namespace FlurlExamples
{
    public class Authorization
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}