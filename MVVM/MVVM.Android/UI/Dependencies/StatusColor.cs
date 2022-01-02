using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MVVM.Droid
{
  public class StatusColor : IStatusColor
  {
    public static MainActivity Activity { get; set; }
    public static void Init(MainActivity activity) => Activity = activity;

    public void SetBarColor(Color color)
    {
      SetStatusBarColor(color);
      SetNavigationBarColor(color);
    }

    public void SetStatusBarColor(Color color)
    {
      var androidColor = Android.Graphics.Color.ParseColor(color.ToHex());
      Activity.Window.SetStatusBarColor(androidColor);
    }

    public void SetNavigationBarColor(Color color)
    {
      var androidColor = Android.Graphics.Color.ParseColor(color.ToHex());
      Activity.Window.SetNavigationBarColor(androidColor);
    }
  }
}