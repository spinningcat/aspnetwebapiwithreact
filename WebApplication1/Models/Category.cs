using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }

        [JsonPropertyName("cName")]
        public string Name { get; set; }

        [JsonPropertyName("cDescription")]
        public string Description { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
