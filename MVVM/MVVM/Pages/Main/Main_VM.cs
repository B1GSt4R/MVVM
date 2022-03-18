using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
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

    [DependsOn(nameof(Author))]
    public ICommand CM_OpenChat { get => new Command(OnOpenChat, CanOpenChat); }

    public string Input { get => _Input; set => SP(ref _Input, value); }
    private string _Input;
    public string Author { get => _Author; set => SP(ref _Author, value, () => Preferences.Set(nameof(Author), value)); }
    private string _Author = string.Empty;

    [DependsOn(nameof(Input))]
    public string TestInput => Input;


    [DependsOn(nameof(Main_DM.TestTitle), nameof(Data))]
    public string Test => Data.TestTitle;

    public Main_VM()
    {
      Title = "Main";
      Data = new Main_DM();
      Data.TestTitle = "MVVM";
    }

    public override void OnAppearing(bool isGoingBack)
    {
      Data.TestTitle = "Dominic";

      Author = Preferences.Get(nameof(Author), string.Empty);

      // Rest API Test
      //test();
      // End Rest API Test
    }

    public async void test()
    {
      var x = await Services.Api.SendAsync<Main_DM>(HttpRequestMethod.GET, "artikel");
      var y = await Services.AuthApi.SendAsync<Main_DM>(HttpRequestMethod.POST, "login");
    }

    private async void OnOpenHome(object obj)
    {
      await new Home_VM().ShowAsync();
    }

    private async void OnOpenChat(object obj)
    {
      await new Chat_VM(Author, obj.ToString()).ShowAsync();
    }

    private bool CanOpenChat(object obj)
    {
      return !Author.ToLower().Equals(obj.ToString().ToLower());
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
