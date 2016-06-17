using SalvaDieta.Domain.Scopes;

namespace SalvaDieta.Domain.Entities
{
    public class City
    {
        public City(string title, bool isActeved)
        {
            this.Title = title;
            this.IsActved = isActeved;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public bool IsActved { get; private set; }

        public void Register()
        {
            if (!this.CreateCityScopeIsValid())
                return;
        }

        public void Update(string title, bool isActved)
        {
            if (!this.UpdateCityScopeIsValid(title))
                return;

            this.Title = title;
            this.IsActved = isActved;
        }
    }
}
