using FluentAssertions;
using System;
using TesteVolvo.Domain.Entities;
using Xunit;

namespace TesteVolvo.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1,"FM");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();

        }
        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid id value");
        }
        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Category. Category is required");
        }
        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }
    }

}
