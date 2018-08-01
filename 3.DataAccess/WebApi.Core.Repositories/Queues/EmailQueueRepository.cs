using Net.Core.Repositories.Core;
using System.Collections.Generic;
using System;
using Net.Core.IRepositories.Queues;
using Net.Core.EntityModels.Queues;

namespace Net.Core.Repositories.Queues
{
    public class EmailQueueRepository : IdentityBaseRepository<EmailQueue>, IEmailQueueRepository
    {

        //public EmailQueueRepository(DataContext dataContext)
        //    : base(dataContext) {
        //}

        public IEnumerable<EmailQueue> GetPendingEmailQueue()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<EmailQueueEntityModel> GetPendingEmailQueue()
        //{
        //    var entityList = this.DataContext.EmailQueues.Where(o => o.IsSucceedEmailSent == false);
        //    return entityList;

        //}
    }
 
}
