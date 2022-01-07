using System;
using System.Linq;
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

    public Page GetActivePage(bool isModal = false)
    {
      if (isModal) return Navigation?.ModalStack?.LastOrDefault();
      else return Navigation?.NavigationStack?.LastOrDefault();
    }

    public Page GetPreviousActivePage(bool isModal = false)
    {
      if (isModal)
      {
        int previousIndex = Navigation?.ModalStack?.Count - 1 ?? -1;
        if(previousIndex == -1) return null;
        return Navigation?.ModalStack?[previousIndex];
      }
      else
      {
        int previousIndex = Navigation?.NavigationStack?.Count - 1 ?? -1;
        if (previousIndex == -1) return null;
        return Navigation?.NavigationStack?[previousIndex];
      }
    }
  }
}
