using System.Text.Json.Serialization;
namespace WebApplication1.Models
{
    public class Product
    {
        public int id { get; set; }
        [JsonPropertyName("pName")]
        public string name { get; set; } = String.Empty;
        [JsonPropertyName("pProductType")]
        public string productType { get; set; } = String.Empty;
        [JsonPropertyName("pProductYear")]
        public  string productYear { get; set; } =  String.Empty;
    }
}

