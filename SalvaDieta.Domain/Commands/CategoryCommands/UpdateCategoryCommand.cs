﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public UpdateCategoryCommand(int id, string title, string decription, string icon)
        {
            this.Id = id; 
            this.Title = title;
            this.Decription = decription;
            this.Icon = icon;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Decription { get; private set; }
        public string Icon { get; private set; }
    }
}
