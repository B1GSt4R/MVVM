using Xamarin.Forms;

namespace MVVM
{
  public static partial class PageExtension
  {
    public static IBaseViewModel GetViewModel(this Page page)
    {
      return page.BindingContext as IBaseViewModel ?? default;
    }
  }
}
