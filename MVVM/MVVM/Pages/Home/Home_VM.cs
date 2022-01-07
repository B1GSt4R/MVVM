using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM
{
  public class Home_VM : BaseViewModel<Home_Page>
  {
    public ICommand CM_OpenSettings { get => _CM_OpenSettings ?? (_CM_OpenSettings = new Command(OnOpenSettings)); }
    private Command _CM_OpenSettings;
    public override void OnAppearing(bool isGoingBack)
    {
      Title = "Home";
    }

    private async void OnOpenSettings(object obj)
    {
      bool modal = Boolean.Parse(obj.ToString());
      await new Settings_VM(modal).ShowAsync(modal);
    }
  }
}
