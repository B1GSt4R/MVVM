using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM
{
  public interface IBaseViewModel<TPage> where TPage : Page
  {
    #region Properties
    string Title { get; set; }
    bool IsModal { get; set; }
    TPage Page { get; }
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
    Page MainPage();
    Task ShowAsync(bool isModal = false);
    #endregion
  }

  public interface IBaseViewModel { }
}
