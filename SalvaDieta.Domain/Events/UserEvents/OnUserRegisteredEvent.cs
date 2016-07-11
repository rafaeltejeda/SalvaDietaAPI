using SalvaDieta.Domain.Entities;
using SalvaDieta.SharedKernel.Events.Contracts;
using SalvaDieta.SharedKernel.Resourses;
using System;

namespace SalvaDieta.Domain.Events.UserEvents
{
    public class OnUserRegisteredEvent : IDomainEvent
    {
        public OnUserRegisteredEvent(User user)
        {
            DateOccurred = DateTime.Now;
            User = user;
            EmailTitle = EmailTemplates.WelcomeEmailTitle;
            EmailBody = EmailTemplates.WelcomeEmailBody;
        }

        public User User { get; private set; }
        public string EmailTitle { get; private set; }
        public string EmailBody { get; private set; }
        public DateTime DateOccurred { get; set; }
    }
}
