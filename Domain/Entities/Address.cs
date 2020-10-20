using Domain.Common;

namespace Domain.Entities
{
    public class Address : AuditableEntity
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}