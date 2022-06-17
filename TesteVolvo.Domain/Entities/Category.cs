using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Domain.Validation;

namespace TesteVolvo.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name{ get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(name);
        }
        public void Update(string name)
        {
            ValidateDomain(name);

        }

        public ICollection<Truck> Trucks { get; set; }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Category. Category is required");

            Name = name;

        }
    }
}
