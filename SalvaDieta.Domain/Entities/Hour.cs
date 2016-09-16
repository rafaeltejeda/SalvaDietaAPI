using SalvaDieta.Domain.Scopes;
using System;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Entities
{
    public class Hour
    {

        protected Hour() { }

        public Hour(
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

        public int Id { get; private set; }
        public DateTime HourOfDay { get; private set; }
        public bool Active { get; private set; }

        public bool Reserved { get; private set; }

        public int DayId { get; private set; }
        public Day Day { get; private set; }

        public void Create()
        {
            if (!this.CreateHourScopeIsValid())
                return;
        }

        public void Update(
                            DateTime hourOfDay,
                            bool active,
                            bool reserved,
                            int dayId
                          )
        {
            if (!this.UpdateHourScopeIsValid())
                return;

            this.HourOfDay = hourOfDay;
            this.Active = active;
            this.Reserved = reserved;
            this.DayId = dayId;

        }
    }
}
