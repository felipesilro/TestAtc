using System;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? BirthDate { get; set; }
        public string SpouseName { get; set; }
        public DateTime? SpouseBirthDate { get; set; }
    }
}