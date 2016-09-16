using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Commands.DayCommands
{
    public class UpdateDayCommand
    {
        public UpdateDayCommand(
                                int id,
                                DateTime dayofweek,
                                bool active,
                                bool reserved
                               )
        {
            this.Id = id;
            this.DayOfWeek = dayofweek;
            this.Active = active;
            this.Reserved = reserved;
        }

        public int Id { get; private set; }
        public DateTime DayOfWeek { get; private set; }
        public bool Active { get; private set; }
        public bool Reserved { get; private set; }
    }
}
