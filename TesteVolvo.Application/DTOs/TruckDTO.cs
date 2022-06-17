using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Domain.Entities;

namespace TesteVolvo.Application.DTOs
{
    public class TruckDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Year Manufacture is Required")]
        public DateTime YearManufacture { get; set; }
        [Required(ErrorMessage = "The Year Model is Required")]
        public DateTime YearModel { get; set; }


        public Category Category { get; set; }

        [DisplayName("Categories")]
        public int CategoryId { get; set; }
    }
}
