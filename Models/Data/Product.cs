using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Data
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int ProductTypeId { get; set; } = default!;
        public int Status { get; set; } = default!;
        public int ClientId { get; set; }
    }
}
