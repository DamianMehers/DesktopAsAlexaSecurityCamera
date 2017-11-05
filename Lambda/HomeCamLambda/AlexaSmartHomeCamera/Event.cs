
using Amazon.Lambda.Core;
using Newtonsoft.Json;


namespace HomeCamLambda.AlexaSmartHomeCamera
{
  public class Event {

    [JsonProperty("header")]
    public Header Header { get; set; }

    [JsonProperty("endpoint")]
    public Endpoint Endpoint { get; set; }

    [JsonProperty("payload")]
    public Payload Payload { get; set; }
  }
}
