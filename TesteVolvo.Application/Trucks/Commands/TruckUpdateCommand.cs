using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteVolvo.Application.Trucks.Commands
{
    public class TruckUpdateCommand : TruckCommand
    {
        public int Id { get; set; }
    }
}
