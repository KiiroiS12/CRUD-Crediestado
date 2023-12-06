using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Data
{
    [Table("ProductType")]
    public class ProductType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = default!;
    }
}
