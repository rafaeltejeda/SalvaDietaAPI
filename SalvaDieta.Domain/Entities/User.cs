using SalvaDieta.Domain.Enums;
using SalvaDieta.Domain.Scopes;
using SalvaDieta.SharedKernel.Helpers;
using System;

namespace SalvaDieta.Domain.Entities
{
    public class User
    {
        protected User() { }

        public User(string name,                                
                    string email,
                    string password,
                    string address,
                    string complement,
                    string number,
                    string district,
                    string city,
                    string zip,
                    string state,
                    string homePhone,
                    string cellPhone,
                    string photo,
                    string facebook,
                    string twitter,
                    string instagram,
                    string youTube                    
                    )
        {
            this.Name = name;
            this.Email = email;
            this.Password = StringHelper.Encrypt(password); ;
            this.Address = address;
            this.Complement = complement;
            this.Number = number;
            this.District = district;
            this.City = city;
            this.Zip = zip;
            this.State = state;
            this.Homephone = homePhone;
            this.Cellphone = cellPhone;
            this.Photo = photo;
            this.Facebook = facebook;
            this.Twitter = twitter;
            this.Instagram = instagram;
            this.YouTube = youTube;
            this.Role = ERole.Customer;
            this.LastLoginDate = DateTime.Now;
            this.Joined = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }        
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Address { get; private set; }
        public string Complement { get; private set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string Zip { get; private set; }
        public string State { get; private set; }
        public string Homephone { get; private set; }
        public string Cellphone { get; private set; }
        public string Photo { get; private set; }
        public string Facebook { get; private set; }
        public string Twitter { get; private set; }
        public string Instagram { get; private set; }
        public string YouTube { get; private set; }
        public ERole Role { get; private set; }        
        public DateTime LastLoginDate { get; private set; }
        public DateTime Joined { get; private set; }

        public void Authenticate(string email,
                                 string password)
        {
            if (!this.AuthenticateUserScopeIsValid(email, password))
                return;
        }

        public void Register()
        {
            if (!this.RegisterUserScopeIsValid())
                return;
        }

        public void UpdateUser(
                    string name,
                    string email,
                    string password,
                    string address,
                    string complement,
                    string number,
                    string district,
                    string city,
                    string zip,
                    string state,
                    string homePhone,
                    string cellPhone,
                    string photo,
                    string facebook,
                    string twitter,
                    string instagram,
                    string youTube
                    )
        {
            if (!this.UpdateScopeIsValid())
                return;
        }

      
    }
}
