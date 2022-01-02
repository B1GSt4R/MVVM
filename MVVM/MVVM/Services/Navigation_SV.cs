using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM
{
  public class Navigation_SV : INavigationService
  {
    private static INavigation Navigation { get => Application.Current?.MainPage?.Navigation; }
    public async Task GoBackAsync(bool isModal = false)
    {
      if (isModal)
      {
        await Navigation.PopModalAsync(true);
      }
      else
      {
        await Navigation.PopAsync(true);
      }
    }

    public async Task GoToAsync(Page page, bool isModal = false)
    {
      if (isModal)
      {
        await Navigation.PushModalAsync(page, true);
      }
      else
      {
        await Navigation.PushAsync(page, true);
      }
    }
  }
}
