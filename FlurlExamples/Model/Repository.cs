using Newtonsoft.Json;

namespace FlurlExamples.Model
{
    public class Repository
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "html_url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "private")]
        public bool Private { get; set; }
    }
}
