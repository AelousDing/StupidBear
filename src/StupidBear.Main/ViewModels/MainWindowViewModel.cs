using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StupidBear.Core.Mvvm;
using StupidBear.Core.Navigation.Regions;
using StupidBear.Wpf.Navigation.Regions;

namespace StupidBear.Main.ViewModels
{
    internal partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string message = "";

        private IRegionManager regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            Message = "测试MVVM";
            this.regionManager = regionManager;
        }
        private RelayCommand<string>? navigateCommand;
        public RelayCommand<string> NavigateCommand
        {
            get
            {
                return navigateCommand ?? new RelayCommand<string>(navigatePath =>
                {
                    if (navigatePath != null)
                        regionManager.RequestNavigate("ContentRegion", navigatePath);
                });
            }
        }
    }
}
