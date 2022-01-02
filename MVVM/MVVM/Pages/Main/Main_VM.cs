using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM
{
  public class Main_VM : BaseViewModel<Main_Page>
  {
    public Main_DM Data { get => _Data; set => SP(ref _Data, value); }
    private Main_DM _Data;
    public ICommand CM_OpenHome { get => _CM_OpenHome ?? (_CM_OpenHome = new Command(OnOpenHome)); }
    private Command _CM_OpenHome;
    public ICommand CM_Change { get => _CM_Change ?? (_CM_Change = new Command(OnChange, CanChange)); }
    private Command _CM_Change;

    public string Input { get => _Input; set => SP(ref _Input, value); }
    private string _Input;

    public Main_VM()
    {
      Title = "Main";
      Data = new Main_DM();
      Data.TestTitle = "MVVM";
    }

    public override void OnAppearing()
    {
      Data.TestTitle = "Dominic";
    }

    private async void OnOpenHome(object obj)
    {
      await new Home_VM().ShowAsync();
    }

    private void OnChange(object obj)
    {
      Data.TestTitle = Input;
      var tmp1 = Data.ToJson();
      var tmp2 = Data.FromJson<Main_DM>(tmp1);
      var tmp3 = Page.GetViewModel();
    }

    private bool CanChange(object arg)
    {
      return true;
    }
  }
}
