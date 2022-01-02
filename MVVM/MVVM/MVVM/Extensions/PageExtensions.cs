using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MVVM
{
  public static class PageExtensions
  {
    public static IBaseViewModel<TPage> GetViewModel<TPage>(this Page page) where TPage : Page
    {
      return null;
    }
  }
}
