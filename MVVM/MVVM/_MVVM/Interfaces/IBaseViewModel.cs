using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM
{
  public interface IBaseViewModel
  {
    #region Properties
    string Title { get; set; }
    bool IsModal { get; set; }

    bool IsStartPage { get; }
    bool IsLoginPage { get; set; }
    bool IsHomePage { get; set; }
    #endregion

    #region Back Command
    ICommand CM_Back { get; }
    void OnBack(object obj);
    bool CanBack(object arg);
    Task BackAsync();
    #endregion

    #region BackHome Command
    ICommand CM_BackHome { get; }
    void OnBackHome(object obj);
    bool CanBackHome(object arg);
    Task BackHomeAsync();
    #endregion

    #region Logout Command
    ICommand CM_Logout { get; }
    void OnLogout(object obj);
    bool CanLogout(object arg);
    Task LogoutAsync();
    #endregion

    #region Appearing & Disappearing
    void OnAppearing(bool isGoingBack);
    void OnDisappearing(bool isGoingBack);
    #endregion

    #region Navigation
    Page StartPage();
    Task ShowAsync(bool isModal = false);
    #endregion
  }

  public interface IBaseViewModel<TPage> : IBaseViewModel where TPage : Page
  {
    TPage Page { get; }
  }
}
