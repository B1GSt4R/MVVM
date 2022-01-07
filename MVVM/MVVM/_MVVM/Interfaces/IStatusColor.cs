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
