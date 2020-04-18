using DotVVM.Framework.ViewModel;

namespace TodoPwa.Web.ViewModels
{
    public class MasterPageViewModel : DotvvmViewModelBase
    {
        public bool IsPageOffline { get; set; } = false;
    }
}
