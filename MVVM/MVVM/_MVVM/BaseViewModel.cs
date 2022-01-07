using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM
{
  public class BaseViewModel<TPage> : BaseModel, IBaseViewModel<TPage> where TPage : Page, new()
  {
    #region Properties
    public string Title { get => _Title; set => SP(ref _Title, value); }
    private string _Title;

    public bool IsModal { get; set; }

    public TPage Page { get; private set; }

    public bool IsStartPage { get; private set; }
    public bool IsLoginPage { get; set; }
    public bool IsHomePage { get; set; }
    #endregion

    #region Back Command
    public ICommand CM_Back { get => _CM_Back ?? (_CM_Back = new Command(OnBack, CanBack)); }
    private Command _CM_Back;

    public virtual async void OnBack(object obj)
    {
      await BackAsync();
    }

    public virtual bool CanBack(object arg)
    {
      return true;
    }

    public async Task BackAsync()
    {
      MVVMConfig.Stats.IsGoingBack = true;
      await Services.Navigation.GoBackAsync(IsModal);
      MVVMConfig.Stats.IsGoingBack = false;
    }
    #endregion

    #region BackHome Command
    public ICommand CM_BackHome { get => _CM_BackHome ?? (_CM_BackHome = new Command(OnBackHome, CanBackHome)); }
    private Command _CM_BackHome;

    public virtual async void OnBackHome(object obj)
    {
      await BackHomeAsync();
    }

    public virtual bool CanBackHome(object arg)
    {
      return true;
    }

    public async Task BackHomeAsync()
    {
      throw new NotImplementedException();
      //await BackAsync();
    }
    #endregion

    #region Logout Command
    public ICommand CM_Logout { get => _CM_Logout ?? (_CM_Logout = new Command(OnLogout, CanLogout)); }
    private Command _CM_Logout;

    public virtual async void OnLogout(object obj)
    {
      await LogoutAsync();
    }

    public virtual bool CanLogout(object arg)
    {
      return true;
    }

    public async Task LogoutAsync()
    {
      //await BackAsync();
      throw new NotImplementedException();
    }
    #endregion

    #region Appearing & Disappearing
    private void DoDisappearing(object sender, EventArgs e)
    {
      OnDisappearing(MVVMConfig.Stats.IsGoingBack);
    }

    private void DoAppearing(object sender, EventArgs e)
    {
      OnAppearing(MVVMConfig.Stats.IsGoingBack);
    }

    public virtual void OnAppearing(bool isGoingBack)
    {

    }

    public virtual void OnDisappearing(bool isGoingBack)
    {

    }
    #endregion

    #region Navigation
    private void InitPage<T>() where T : Page, new()
    {
      if (Page != null) return;
      Page = new T() as TPage;
      Page.Appearing += DoAppearing;
      Page.Disappearing += DoDisappearing;
    }

    public Page StartPage()
    {
      InitPage<TPage>();
      this.IsStartPage = true;
      Page.BindingContext = this;
      return new NavigationPage(Page);
    }

    public async Task ShowAsync(bool isModal = false)
    {
      InitPage<TPage>();
      Page.BindingContext = this;
      await Services.Navigation.GoToAsync(Page, (IsModal = isModal));
    }
    #endregion
  }

  public class BaseViewModel : BaseViewModel<ContentPage>
  {

  }
}
