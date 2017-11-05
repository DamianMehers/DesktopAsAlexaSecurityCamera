using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HomeCamLambda.AlexaSmartHomeCamera
{
  public class CameraDiscoveryRequest {

    [JsonProperty("directive")]
    public Directive Directive { get; set; }
  }
}
