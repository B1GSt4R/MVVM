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

    public static IRestApi Api { get => _Api ?? (_Api = new RestApi("")); }
    private static IRestApi _Api;

    public static RestApi AuthApi { get => _RestApi ?? (_RestApi = new RestApi("")); }
    private static RestApi _RestApi;
  }
}
