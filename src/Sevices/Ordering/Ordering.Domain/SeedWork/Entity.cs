using System;

namespace Ordering.Domain.SeedWork
{
    public class Entity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBt { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
