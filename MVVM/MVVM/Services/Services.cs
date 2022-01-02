using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM
{
  public static class Services
  {
    public static Color_SV Colors { get => _Colors ?? (_Colors = new Color_SV()); }
    private static Color_SV _Colors;

    public static INavigationService Navigation { get => _Navigation ?? (_Navigation = new Navigation_SV()); }
    private static INavigationService _Navigation;
  }
}
