using SalvaDieta.Domain.Scopes;
using System.Collections.Generic;

namespace SalvaDieta.Domain.Entities
{
    public class Category
    {
        protected Category() { }

        public Category(string title)
        {
            this.Title = title;
            Product = new List<Product>();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Icon { get; private set; }

        public ICollection<Product> Product { get; set; }

        public void Register()
        {
            if (!this.CreateCategoryScopeIsValid())
                return;
        }

        public void UpdateTitle(string title)
        {
            if (!this.EditCategoryScopeIsValid(title))
                return;

            this.Title = title;
        }
    }
}
