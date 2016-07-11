using SalvaDieta.ApplicationService.Service.Common;
using SalvaDieta.Domain.Events.UserEvents;
using SalvaDieta.SharedKernel;
using System;
using System.Collections.Generic;

namespace SalvaDieta.ApplicationService.Handlers.Account
{
    public class OnUserRegisteredHandler : IHandler<OnUserRegisteredEvent>
    {
        public void Dispose()
        {
            // 
        }

        public void Handle(OnUserRegisteredEvent args)
        {
            var user = args.User;
            var title = args.EmailTitle;
            var body = args.EmailBody.Replace("##EMAIL##", user.Email);

            EmailService.Send(user.Email, title, body);
        }

        public bool HasNotifications()
        {
            return false;
        }

        public IEnumerable<OnUserRegisteredEvent> Notify()
        {
            return null;
        }
    }
}
