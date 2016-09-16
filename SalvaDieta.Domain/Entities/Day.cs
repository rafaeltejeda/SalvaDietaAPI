using System.Collections.Generic;
using SalvaDieta.Domain.Scopes;
using System;

namespace SalvaDieta.Domain.Entities
{
    public class Day
    {
        protected Day() { }

        public Day(
                    DateTime dayofweek,
                    bool active,
                    bool reserved
                  )
        {
            this.DayOfWeek = dayofweek;
            this.Active = active;
            this.Reserved = reserved;            
            this.Hours = new List<Hour>();
        }

        public int Id { get; private set; }
        public DateTime DayOfWeek { get; private set; }
        public bool Active { get; private set; }
        public bool Reserved { get; private set; }

        public int HourId { get; set; }
        public Hour Hour { get; set; }
        public ICollection<Hour> Hours { get; private set; }

        public void Create()
        {
            if (!this.CreateDayScopeIsValid())
                return;
        }

        public void Update(
                           DateTime dayofweek,
                           bool active,
                           bool reserved                           
                          )
        {
            if (!this.UpdateDayScopeIsValid())
                return;

            this.DayOfWeek = dayofweek;
            this.Active = active;
            this.Reserved = reserved;
        }
    }
}
