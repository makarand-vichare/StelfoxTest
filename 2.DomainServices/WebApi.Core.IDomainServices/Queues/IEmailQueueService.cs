using Net.Core.IDomainServices.Core;
using System.Collections.Generic;
using Net.Core.EntityModels.Queues;
using Net.Core.ViewModels.Identity.WebApi;
using Net.Core.ViewModels;
using Net.Core.ServiceResponse;

namespace Net.Core.IDomainServices.Queues
{
    public interface IEmailQueueService : IBaseService<EmailQueue, EmailQueueViewModel>
    {
        BaseResponseResult SendUserRegistrationMail(IdentityUserViewModel viewModel);
        List<EmailQueueViewModel> GetEmailsFromQueue();
    }
}
