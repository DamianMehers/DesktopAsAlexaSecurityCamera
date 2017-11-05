using Newtonsoft.Json;

namespace HomeCamLambda.AlexaSmartHomeCamera
{
  public class Header {
    public const string DiscoveryNamespace = "Alexa.Discovery";
    public const string CameraStreamControllerNamespace = "Alexa.CameraStreamController";

    public const string DiscoverRequestName = "Discover";
    public const string InitializeCameraStreamsName = "InitializeCameraStreams";
    public const string ResponseName = "Response";

    public const string DiscoverResponseName = "Discover.Response";

    [JsonProperty("namespace")]
    public string Namespace { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("payloadVersion")]
    public string PayloadVersion { get; set; } = "3";

    [JsonProperty("messageId")]
    public string MessageId { get; set; }

    [JsonProperty("correlationToken", NullValueHandling =NullValueHandling.Ignore)]
    public string CorrelationToken { get; set; }
  }
}