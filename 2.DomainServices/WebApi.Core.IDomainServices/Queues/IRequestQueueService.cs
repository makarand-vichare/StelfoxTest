using Net.Core.IDomainServices.Core;
using System.Collections.Generic;
using Net.Core.ViewModels;
using Net.Core.EntityModels.Queues;

namespace Net.Core.IDomainServices.Queues
{
    public interface IRequestQueueService : IBaseService<RequestQueue, RequestQueueViewModel>
    {
        List<RequestQueueViewModel> GetPendingRequestQueue();
        bool ProcessPendingRequests();
    }
}
