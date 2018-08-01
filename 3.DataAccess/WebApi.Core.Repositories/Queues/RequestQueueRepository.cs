using Net.Core.Repositories.Core;
using System.Collections.Generic;
using System;
using Net.Core.EntityModels.Queues;
using Net.Core.IRepositories.Queues;

namespace Net.Core.Repositories.Queues
{
    public class RequestQueueRepository : IdentityBaseRepository<RequestQueue>, IRequestQueueRepository
    {

        //public RequestQueueRepository(DataContext dataContext)
        //    : base(dataContext)
        //{
        //}

        public IEnumerable<RequestQueue> GetPendingRequestQueue()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<RequestQueueEntityModel> GetPendingRequestQueue()
        //{
        //   var entityList = this.DataContext.RequestQueues.Where(o => o.IsRequestSucceed == false);
        //    return entityList;
        //}
    }
 
}
