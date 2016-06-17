using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Commands.CityCommands
{
    public class UpdateCityCommand
    {
        public UpdateCityCommand(
               int id, 
               string title, 
               bool isActeved)
        {
            this.Id = id;
            this.Title = title;
            this.IsActved = isActeved;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public bool IsActved { get; private set; }
    }
}
