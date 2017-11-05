using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.Lambda.Core;
using HomeCamLambda.AlexaSmartHomeCamera;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace HomeCamLambda {
  public class Function {

    public object FunctionHandler(object inputString, ILambdaContext context) {
      JsonConvert.DefaultSettings = () => new JsonSerializerSettings {
        NullValueHandling = NullValueHandling.Ignore
      };
      LambdaLogger.Log($"inputString: {inputString}{Environment.NewLine}");
      var input = JsonConvert.DeserializeObject<CameraDiscoveryRequest>(inputString.ToString());
      LambdaLogger.Log($"Namespace: {input?.Directive?.Header?.Namespace}{Environment.NewLine}");
      LambdaLogger.Log($"Name: {input?.Directive?.Header?.Name}{Environment.NewLine}");
      if (input?.Directive?.Header == null) throw new Exception("Unexpected input");

      if (input.Directive.Header.Namespace == Header.DiscoveryNamespace &&
          input.Directive.Header.Name == Header.DiscoverRequestName) {
        return GenerateCameraDiscoveryResponse();
      }
      if (input.Directive.Header.Namespace == Header.CameraStreamControllerNamespace &&
          input.Directive.Header.Name == Header.InitializeCameraStreamsName) {
        return GenerateInitializeCameraStreamsResponse(input);
      }
      LambdaLogger.Log($"Don't know how to handle request{Environment.NewLine}");
      return null;
    }


    private object GenerateInitializeCameraStreamsResponse(CameraDiscoveryRequest input) {
      var response = new CameraDiscoveryResponse {
        Event = new Event {
        Header = new Header {
          Namespace = Header.CameraStreamControllerNamespace,
          Name = Header.ResponseName,
          PayloadVersion = "3",
          MessageId = GenerateMessageId(),
          CorrelationToken = input.Directive.Header.CorrelationToken
        },
        Endpoint = input.Directive.Endpoint = new Endpoint {EndpointId = input.Directive.Endpoint.EndpointId},
        Payload = new Payload {
          CameraStreams = new List<CameraStream> {
            new CameraStream {
              Uri = "rtsp://macbookairubuntu.1l.io:443/h264",
              ExpirationTime = DateTime.UtcNow.AddDays(1),
              IdleTimeoutSeconds = 30,
              Protocol = "RTSP",
              Resolution = input.Directive.Payload.CameraStreams.First().Resolution,
              AuthorizationType = "NONE",
              AudioCodec = "NONE"
            }
          },
          ImageUri = "https://upload.wikimedia.org/wikipedia/commons/0/05/Photographic_pastimes_-_a_series_of_interesting_experiments_for_amateurs_for_obtaining_novel_and_curious_effects_with_the_aid_of_the_camera_%281891%29_%2814785935653%29.jpg"
        }
        }
      };

      LambdaLogger.Log($"Built response ...{Environment.NewLine}");
      LambdaLogger.Log($"result: {JsonConvert.SerializeObject(response)}{Environment.NewLine}");
      return response;
    }

    private static object GenerateCameraDiscoveryResponse() {
      LambdaLogger.Log($"Building camera discovery response ...{Environment.NewLine}");
      var response = new CameraDiscoveryResponse {
        Event = new Event {
          Header = new Header {
            Namespace = Header.DiscoveryNamespace,
            Name = Header.DiscoverResponseName,
            MessageId = GenerateMessageId(),
            PayloadVersion = "3"
          },
          Payload = new Payload {
            Endpoints = new List<Endpoint> {
              new Endpoint {
                EndpointId = "c1f48218-1b0d-474e-8232-0cb7b154c35a",
                EndpointTypeId = "45baba54-089a-4626-b66d-3375561d8a29",
                ManufacturerName = "Security Cameras",
                ModelName = "Zaphod 1",
                Description = "Security Cameras",
                FriendlyName = "Security Cameras",
                DisplayCategories = new List<string> {"CAMERA"},
                Capabilities = new List<Capability> {
                  new Capability {
                    Type = Capability.AlexaInterfaceType,
                    Interface = Capability.AlexaCameraStreamControllerInterface,
                    Version = "3",
                    CameraStreamConfigurations = new List<CameraStreamConfiguration> {
                      new CameraStreamConfiguration {
                        Protocols = new List<string> {"RTSP"},
                        AuthorizationTypes = new List<string> {"NONE"},
                        AudioCodecs = new List<string> {"NONE"},
                        VideoCodecs = new List<string> {"H264"},
                        Resolutions = new List<Resolution> {new Resolution {Width = 1920/2 , Height = 1080/2 } }
                      }
                    }
                  },
                  new Capability {
                    Type = Capability.AlexaInterfaceType,
                    Interface = Capability.AlexaPowerControllerControllerInterface,
                    Version = "3"
                  }
                }
              }
            }
          }
        }
      };


      LambdaLogger.Log($"Built response ...{Environment.NewLine}");
      LambdaLogger.Log($"result: {JsonConvert.SerializeObject(response)}{Environment.NewLine}");
      return response;
    }

    private static string GenerateMessageId() {
      return Guid.NewGuid().ToString().ToLowerInvariant();
    }
  }
}
