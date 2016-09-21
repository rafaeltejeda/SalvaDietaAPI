using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Commands.UserCommands
{
    public class UpdatePasswordCommand
    {
        public UpdatePasswordCommand(
                                      string newPassword,
                                      string confirmeNewPassword,
                                      string password,
                                      string email,
                                      string currentPassword

                                    )
        {
            this.NewPassword = newPassword;
            this.ConfirmeNewPassword = confirmeNewPassword;
            this.Password = password;
            this.CurrentPassword = currentPassword;
            this.Email = email;
        }

        public string Email { get; set; }
        public string Password { get; set; }     
        public string NewPassword { get; set; }
        public string ConfirmeNewPassword { get; set; }
        public string CurrentPassword { get; set; }
        
    }
}
