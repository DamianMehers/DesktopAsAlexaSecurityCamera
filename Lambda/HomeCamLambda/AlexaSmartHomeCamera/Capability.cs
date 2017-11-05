using System.Collections.Generic;
using Newtonsoft.Json;

namespace HomeCamLambda.AlexaSmartHomeCamera
{
  public class Capability {
    public const string AlexaInterfaceType = "AlexaInterface";
    public const string AlexaCameraStreamControllerInterface =  "Alexa.CameraStreamController";
    public const string AlexaPowerControllerControllerInterface = "Alexa.PowerController";

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("interface")]
    public string Interface { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("cameraStreamConfigurations")]
    public List<CameraStreamConfiguration> CameraStreamConfigurations { get; set; }
  }
}