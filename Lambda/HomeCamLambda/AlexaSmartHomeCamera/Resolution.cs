using Newtonsoft.Json;

namespace HomeCamLambda.AlexaSmartHomeCamera {
  public class Resolution {

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }
  }
}