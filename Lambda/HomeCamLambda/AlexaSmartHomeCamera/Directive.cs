using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HomeCamLambda.AlexaSmartHomeCamera
{
  public class Directive
  {

    [JsonProperty("header")]
    public Header Header { get; set; }

    [JsonProperty("endpoint")]
    public Endpoint Endpoint { get; set; }

    [JsonProperty("payload")]
    public Payload Payload { get; set; }
  }
}
