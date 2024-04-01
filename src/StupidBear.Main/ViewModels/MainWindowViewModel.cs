using CommunityToolkit.Mvvm.ComponentModel;
using StupidBear.Core.Mvvm;

namespace StupidBear.Main.ViewModels
{
    internal partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string message = "";

        public MainWindowViewModel()
        {
            Message = "测试MVVM";
        }
    }
}
