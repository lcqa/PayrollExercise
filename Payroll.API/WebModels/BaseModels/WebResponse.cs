using System.Text.Json.Serialization;

namespace Payroll.API.WebModels.BaseModels
{
    public class WebResponse<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }
    }
}
