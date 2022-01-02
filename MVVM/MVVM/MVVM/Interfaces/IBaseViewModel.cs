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
    string Title { get; set; }
    bool IsModal { get; set; }
    TPage Page { get; }
    ICommand CM_Back { get; }
    void OnAppearing();
    void OnDisappearing();
    Page MainPage();
  }

  public interface IBaseViewModel { }
}
