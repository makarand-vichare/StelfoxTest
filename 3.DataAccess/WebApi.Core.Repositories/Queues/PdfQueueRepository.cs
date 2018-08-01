using Net.Core.Repositories.Core;
using System.Collections.Generic;
using System;
using Net.Core.EntityModels.Queues;
using Net.Core.IRepositories.Queues;

namespace Net.Core.Repositories.Queues
{
    public class PdfQueueRepository : IdentityBaseRepository<PdfQueue>, IPdfQueueRepository
    {

        //public PdfQueueRepository(DataContext dataContext)
        //    : base(dataContext)
        //{
        //}

        public IEnumerable<PdfQueue> GetPendingPdfQueue()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<PdfQueueEntityModel> GetPendingPdfQueue()
        //{
        //    var entityList = this.DbSet.PdfQueues.Where(o => o.IsPdfGenerationSucceed == false);
        //    return entityList;
        //}
    }
 
}
