using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        [JsonPropertyName("scName")]
        public string Name { get; set; }
        [JsonPropertyName("scDescription")]
        public string Description { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
      
    }
}
