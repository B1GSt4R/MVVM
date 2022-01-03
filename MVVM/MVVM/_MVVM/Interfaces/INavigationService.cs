using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM
{
  public interface INavigationService
  {
    Task GoToAsync(Page page, bool isModal = false);
    Task GoBackAsync(bool isModal = false);
  }
}
