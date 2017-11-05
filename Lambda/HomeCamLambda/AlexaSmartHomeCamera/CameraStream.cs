using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HomeCamLambda.AlexaSmartHomeCamera
{
  public class CameraStream
  {

    [JsonProperty("uri")]
    public string Uri { get; set; }

    [JsonProperty("expirationTime")]
    public DateTime ExpirationTime { get; set; }

    [JsonProperty("idleTimeoutSeconds")]
    public int IdleTimeoutSeconds { get; set; }

    [JsonProperty("protocol")]
    public string Protocol { get; set; }

    [JsonProperty("resolution")]
    public Resolution Resolution { get; set; }

    [JsonProperty("authorizationType")]
    public string AuthorizationType { get; set; }

    [JsonProperty("videoCodec")]
    public string VideoCodec { get; set; }

    [JsonProperty("audioCodec")]
    public string AudioCodec { get; set; }
  }
}
