using SalvaDieta.Domain.Scopes;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Entities
{
    public class Category
    {
        protected Category() { }

        public Category(string title, 
                        string description, 
                        string icon)
        {
            this.Title = title;
            this.Description = description;
            this.Icon = Icon;    
            this.Products = new List<Product>();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }

        public ICollection<Product> Products { get; set; }

        public void Register()
        {
            if (!this.CreateCategoryScopeIsValid())
                return;
        }

        public void Update(string title, string description, string icon)
        {
            if (!this.EditCategoryScopeIsValid(title, description, icon))
                return;

            this.Title = title;
            this.Description = description;
            this.Icon = icon;
        }
    }
}
