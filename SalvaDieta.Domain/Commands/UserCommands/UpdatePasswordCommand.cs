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
                                      string token,
                                      string email
                                    )
        {
            this.NewPassword = newPassword;
            this.ConfirmeNewPassword = confirmeNewPassword;
            this.Token = Token;
            this.Email = email;
        }

        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmeNewPassword { get; set; }
    }
}
