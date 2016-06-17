using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        public CreateCategoryCommand(string title, string icon)
        {
            this.Title = title;
            this.Icon = icon;
        }

        public string Title { get; private set; }
        public string Icon { get; private set; }
    }
}
