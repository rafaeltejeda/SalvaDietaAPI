using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Commands.CityCommands
{
    public class CreateCityCommand
    {
        public CreateCityCommand(string title, bool isActeved)
        {
            this.Title = title;
            this.IsActved = isActeved;
        }
        
        public string Title { get; private set; }
        public bool IsActved { get; private set; }
    }
}
