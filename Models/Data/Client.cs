using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Data
{
    [Table("Client")]
    public class Client
    {
        public int Id { get; set; }
        public string Identification { get; set; } = default!;
        public string IdentificationType { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
