using Net.Core.IDomainServices.Core;
using System.Collections.Generic;
using Net.Core.ViewModels;
using Net.Core.EntityModels.Queues;

namespace Net.Core.IDomainServices.Queues
{
    public interface IPdfQueueService : IBaseService<PdfQueue, PdfQueueViewModel>
    {
        List<PdfQueueViewModel> GetPendingPdfQueue();
        bool ProcessPendingPdfs();
        //List<PdfResultViewModel> GetRequestsForEmailQueue();
    }
}
