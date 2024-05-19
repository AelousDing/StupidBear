using CommunityToolkit.Mvvm.ComponentModel;
using StupidBear.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidBear.ModuleA.ViewModels
{
    public partial class ViewBViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string message;

        public ViewBViewModel()
        {
            Message = "ViewB";
        }
    }
}
