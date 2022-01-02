using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM
{
  public class BaseViewModel<TPage> : BaseModel, IBaseViewModel<TPage> where TPage : Page, new()
  {
    public ICommand CM_Back { get => _CM_Back ?? (_CM_Back = new Command(OnBack, CanBack)); }
    private Command _CM_Back;

    public string Title { get => _Title; set => SP(ref _Title, value); }
    private string _Title;

    private bool IsModal { get; set; }

    public TPage Page { get; private set; }

    private async void OnBack(object obj)
    {
      await BackAsync();
    }

    private bool CanBack(object arg)
    {
      return true;
    }

    public virtual void OnAppearing()
    {

    }

    public virtual void OnDisappearing()
    {

    }

    public async Task ShowAsync(bool isModal = false)
    {
      InitPage<TPage>();
      Page.BindingContext = this;
      await Services.Navigation.GoToAsync(Page, (IsModal = isModal));
    }

    public async Task BackAsync()
    {
      await Services.Navigation.GoBackAsync(IsModal);
    }

    private void InitPage<T>() where T : Page, new()
    {
      if (Page != null) return;
      Page = new T() as TPage;
      Page.Appearing += DoAppearing;
      Page.Disappearing += DoDisappearing;
    }

    private void DoDisappearing(object sender, EventArgs e)
    {
      OnDisappearing();
    }

    private void DoAppearing(object sender, EventArgs e)
    {
      OnAppearing();
    }

    public Page MainPage()
    {
      InitPage<TPage>();
      Page.BindingContext = this;
      return new NavigationPage(Page);
    }
  }
}
