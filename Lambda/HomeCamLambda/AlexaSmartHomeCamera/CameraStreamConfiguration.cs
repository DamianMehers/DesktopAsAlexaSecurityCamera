using System.Collections.Generic;
using Newtonsoft.Json;

namespace HomeCamLambda.AlexaSmartHomeCamera { 
  public class CameraStreamConfiguration {

    [JsonProperty("protocols")]
    public List<string> Protocols { get; set; } = new List<string> {"RTSP"};

    [JsonProperty("resolutions")]
    public List<Resolution> Resolutions { get; set; }

    [JsonProperty("authorizationTypes")]
    public List<string> AuthorizationTypes { get; set; }

    [JsonProperty("videoCodecs")]
    public List<string> VideoCodecs { get; set; }

    [JsonProperty("audioCodecs")]
    public List<string> AudioCodecs { get; set; }
  }
}