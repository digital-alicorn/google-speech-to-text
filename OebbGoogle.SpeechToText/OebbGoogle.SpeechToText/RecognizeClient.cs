using OebbGoogle.SpeechToText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Flurl;
using System.Text.Json.Serialization;

namespace OebbGoogle.SpeechToText
{
    public class RecognizeClient
    {
        public RecognizeClient(string url, string apiKey, string gatewayKeyHeaderName, string gatewayKey)
        {
            Url = url;
            ApiKey = apiKey;
            GatewayKeyHeaderName = gatewayKeyHeaderName;
            GatewayKey = gatewayKey;
        }

        private string Url { get; }

        private string ApiKey { get; }

        private string GatewayKeyHeaderName { get; }

        private string GatewayKey { get; }

        public async Task<RecognizeResponse> RecognizeAsync(RecognizeRequest request)
        {
            var body = Serialize(request);

            using HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(GatewayKeyHeaderName, GatewayKey);
            var response = await httpClient.PostAsync(Url.SetQueryParam("key", ApiKey), new StringContent(body));
            var content = await response.Content.ReadAsStringAsync();
            
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Deserialize(content);
            }
            else
            {
                throw new ApiException(content);
            }
        }

        private string Serialize(RecognizeRequest request)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Serialize(request, serializeOptions);
        }

        private RecognizeResponse Deserialize(string response)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Deserialize<RecognizeResponse>(response, serializeOptions);
        }
    }
}
