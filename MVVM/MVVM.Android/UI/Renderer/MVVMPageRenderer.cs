using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MVVM.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(MVVMPageRenderer))]
namespace MVVM.Droid
{
  public class MVVMPageRenderer : NavigationPageRenderer
  {
    public MVVMPageRenderer(Context ctx) : base(ctx) { }

    protected override void SetupPageTransition(AndroidX.Fragment.App.FragmentTransaction transaction, bool isPush)
    {
      if (isPush)
      {
        transaction.SetCustomAnimations(Resource.Animation.EnterFromRight, Resource.Animation.ExitToLeft);
      }
      else
      {
        transaction.SetCustomAnimations(Resource.Animation.EnterFromLeft, Resource.Animation.ExitToRight);
      }
    }
  }
}