using System;

namespace BarnCase.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal Price { get; set; }
        public string DeathCause { get; set; }
    }
}
