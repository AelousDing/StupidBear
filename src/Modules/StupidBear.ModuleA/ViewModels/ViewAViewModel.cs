using CommunityToolkit.Mvvm.ComponentModel;
using StupidBear.Core.Mvvm;

namespace StupidBear.ModuleA.ViewModels
{
    public partial class ViewAViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string message;

        public ViewAViewModel()
        {
            Message = "测试MVVM";
        }
    }
}
