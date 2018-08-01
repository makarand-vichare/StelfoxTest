using System;

namespace Net.Core.ViewModels.Core
{
    [Serializable]
    public abstract class IdentityColumnViewModel : BaseViewModel
    {
        public long Id { get; set; }
    }
}
