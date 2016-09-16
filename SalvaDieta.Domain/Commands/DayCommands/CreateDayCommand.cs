using SalvaDieta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Commands.DayCommands
{
    public class CreateDayCommand
    {
        public CreateDayCommand(
                                DateTime dayofweek,
                                bool active,
                                bool reserved
                               )
        {
            this.DayOfWeek = dayofweek;
            this.Active = active;
            this.Reserved = reserved;
        }
               
        public DateTime DayOfWeek { get; private set; }
        public bool Active { get; private set; }
        public bool Reserved { get; private set; }

    }
}
