using Net.Core.IRepositories.Core;
using System.Collections.Generic;
using Net.Core.EntityModels.Queues;

namespace Net.Core.IRepositories.Queues
{
    public interface IEmailQueueRepository : IIdentityBaseRepository<EmailQueue>
    {
        IEnumerable<EmailQueue> GetPendingEmailQueue();
    }
}
