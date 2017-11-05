using Newtonsoft.Json;

namespace HomeCamLambda.AlexaSmartHomeCamera {
  public class CameraDiscoveryResponse
  {
    [JsonProperty("event")]
    public Event Event { get; set; }
  }
}
