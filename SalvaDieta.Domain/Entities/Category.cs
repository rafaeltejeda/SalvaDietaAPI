using SalvaDieta.Domain.Scopes;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Entities
{
    public class Category
    {
        protected Category() { }

        public Category(string title, string decription, string icon)
        {
            this.Title = title;
            this.Decription = decription;
            this.Icon = Icon;
            Product = new List<Product>();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Decription { get; private set; }
        public string Icon { get; private set; }

        public ICollection<Product> Product { get; set; }

        public void Register()
        {
            if (!this.CreateCategoryScopeIsValid())
                return;
        }

        public void Update(string title, string decription, string icon)
        {
            if (!this.EditCategoryScopeIsValid(title, decription, icon))
                return;

            this.Title = title;
            this.Decription = decription;
            this.Icon = icon;
        }
    }
}
