using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MVVM
{
  public static class PageExtensions
  {
    public static IBaseViewModel GetViewModel(this Page page)
    {
      return page.BindingContext as IBaseViewModel ?? default;
    }
  }
}
