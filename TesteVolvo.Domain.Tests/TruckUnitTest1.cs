using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Domain.Entities;
using Xunit;

namespace TesteVolvo.Domain.Tests
{
    public class TruckUnitTest1
    {
        [Fact]
        public void CreateTruck_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Truck(1, DateTime.Now, DateTime.Now);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateTruck_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Truck(-1, DateTime.Now, DateTime.Now);

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateTruck_InvalidDateManufactureValue_DomainExceptionYearManufacture()
        {
            int year = 2019;
            Action action = () => new Truck(1, DateTime.UtcNow.AddYears(year), DateTime.Now);

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Year Manufacture. Only current year");
        }
        [Fact]
        public void CreateTruck_InvalidDateModelValue_DomainExceptionYearModel()
        {
            Action action = () => new Truck(1, DateTime.Now, DateTime.Now.AddYears(-1));

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Year Model. Only current or subsequent year");
        }

    }
}
