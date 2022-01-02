using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MVVM
{
  public class Color_SV : IStatusColor
  {
    public void SetBarColor(Color color)
    {
      var ds = DependencyService.Get<IStatusColor>();
      if (ds != null) ds.SetBarColor(color);
    }

    public void SetNavigationBarColor(Color color)
    {
      var ds = DependencyService.Get<IStatusColor>();
      if (ds != null) ds.SetNavigationBarColor(color);
    }

    public void SetStatusBarColor(Color color)
    {
      var ds = DependencyService.Get<IStatusColor>();
      if (ds != null) ds.SetStatusBarColor(color);
    }
  }
}
