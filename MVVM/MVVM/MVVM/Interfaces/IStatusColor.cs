using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MVVM
{
  public interface IStatusColor
  {
    void SetStatusBarColor(Color color);
    void SetNavigationBarColor(Color color);
    void SetBarColor(Color color);
  }
}
