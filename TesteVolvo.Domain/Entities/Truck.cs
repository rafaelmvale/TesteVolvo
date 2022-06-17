using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Domain.Validation;

namespace TesteVolvo.Domain.Entities
{
    public sealed class Truck : Entity
    {
        public DateTime YearManufacture { get; private set; }
        public DateTime YearModel { get; private set; }

        public Truck(DateTime yearManufacture, DateTime yearModel)
        {
            ValidateDomain(yearManufacture, yearModel);
        }

        public Truck(int id, DateTime yearManufacture, DateTime yearModel)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(yearManufacture, yearModel);
        }

        public void Update(DateTime yearManufacture, DateTime yearModel, int categoryId)
        {
            ValidateDomain(yearManufacture, yearModel);
            CategoryId = categoryId;
        }
        private void ValidateDomain(DateTime yearManufacture, DateTime yearModel)
        {
            int currentYear = DateTime.Now.Year;   
            DomainExceptionValidation.When(yearManufacture.Year < currentYear,
              "Invalid Year Manufacture. Only current year");
            DomainExceptionValidation.When(yearManufacture.Year > currentYear,
              "Invalid Year Manufacture. Only current year");
            DomainExceptionValidation.When(yearModel.Year < currentYear,
              "Invalid Year Model. Only current or subsequent year");

            YearManufacture = yearManufacture;
            YearModel = yearModel;
        }
        public int CategoryId {  get; set; }
        public Category Category { get; set; }
    }

}
