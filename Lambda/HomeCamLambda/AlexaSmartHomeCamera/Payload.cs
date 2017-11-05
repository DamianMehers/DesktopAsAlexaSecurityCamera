using System.Collections.Generic;
using Newtonsoft.Json;

namespace HomeCamLambda.AlexaSmartHomeCamera
{
  public class Payload
  {
    [JsonProperty("endpoints")]
    public List<Endpoint> Endpoints { get; set; }

    [JsonProperty("scope")]
    public Scope Scope { get; set; }

    [JsonProperty("cameraStreams")]
    public List<CameraStream> CameraStreams { get; set; }

    [JsonProperty("imageUri")]
    public string ImageUri { get; set; }
  }
}