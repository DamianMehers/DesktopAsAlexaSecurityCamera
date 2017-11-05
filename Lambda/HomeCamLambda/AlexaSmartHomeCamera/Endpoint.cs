using System.Collections.Generic;
using Newtonsoft.Json;

namespace HomeCamLambda.AlexaSmartHomeCamera
{
  public class Endpoint
  {

    [JsonProperty("endpointId")]
    public string EndpointId { get; set; }

    [JsonProperty("endpointTypeId")]
    public string EndpointTypeId { get; set; }

    [JsonProperty("manufacturerName")]
    public string ManufacturerName { get; set; }

    [JsonProperty("modelName")]
    public string ModelName { get; set; }

    [JsonProperty("friendlyName")]
    public string FriendlyName { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("displayCategories")]
    public List<string> DisplayCategories { get; set; }

    [JsonProperty("cookie")]
    public Dictionary<string,string> Cookie { get; set; }

    [JsonProperty("capabilities")]
    public List<Capability> Capabilities { get; set; }
  }
}