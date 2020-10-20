using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Festival : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Website { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}