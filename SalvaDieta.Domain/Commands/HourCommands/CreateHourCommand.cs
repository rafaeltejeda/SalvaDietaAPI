using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Commands.HourCommands
{
    public class CreateHourCommand
    {
        public CreateHourCommand(
                                 DateTime hourOfDay,
                                 bool active,
                                 bool reserved,
                                 int dayId
                                 )
        {
            this.HourOfDay = hourOfDay;
            this.Active = active;
            this.Reserved = reserved;
            this.DayId = dayId;
        }

        public DateTime HourOfDay { get; private set; }
        public bool Active { get; private set; }
        public bool Reserved { get; private set; }
        public int DayId { get; private set; }

    }
}
