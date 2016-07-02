using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public UpdateCategoryCommand(int id, string title, string description, string icon)
        {
            this.Id = id; 
            this.Title = title;
            this.Description = description;
            this.Icon = icon;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }
    }
}
