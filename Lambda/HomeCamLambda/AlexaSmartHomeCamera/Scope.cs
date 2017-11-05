using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HomeCamLambda.AlexaSmartHomeCamera
{
  public class Scope
  {

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("token")]
    public string Token { get; set; }
  }
}
