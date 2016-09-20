using SalvaDieta.Domain.Entities;
using SalvaDieta.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Scopes
{
    public static class UserScopes
    {
        public static bool RegisterUserScopeIsValid(this User user)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(user.Email, "O E-mail é obrigatório"),
                AssertionConcern.AssertNotEmpty(user.Password, "A senha é obrigatória")
            );
        }

        public static bool checkUserScopeIsValid(this User user)
        {
            return AssertionConcern.IsSatisfiedBy
            (
               AssertionConcern.AssertNotEmpty(user.Email, "O E-mail é obrigatório")
            );
        }

        public static bool AuthenticateUserScopeIsValid(this User user, string email, string encryptedPassword)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(email, "O usuário é obrigatório"),
                AssertionConcern.AssertNotEmpty(encryptedPassword, "A senha é obrigatória"),
                AssertionConcern.AssertAreEquals(user.Email, email, "Usuário ou senha inválidos"),
                AssertionConcern.AssertAreEquals(user.Password, encryptedPassword, "Usuário ou senha inválidos")
            );
        }

        public static bool UpdateScopeIsValid(this User user)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(user.Email, "O E-mail é obrigatório")
            );
        }

        public static bool UpdatePasswordScopeIsValid(this User user, string newPassword, string confirmeNewPassword)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertMatches(newPassword, confirmeNewPassword, "As senhas não conferem.")
            );
        }        
    }
}
