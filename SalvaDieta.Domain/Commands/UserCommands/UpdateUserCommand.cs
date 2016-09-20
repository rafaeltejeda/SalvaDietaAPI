using SalvaDieta.Domain.Enums;
using System;

namespace SalvaDieta.Domain.Commands.UserCommands
{
    public class UpdateUserCommand
    {
        public UpdateUserCommand(
                                   int id,
                                   string name,
                                   string email,
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
            this.Id = id;
            this.Name = name;
            this.Email = email;            
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
        }
       
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }       
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
    }
}
