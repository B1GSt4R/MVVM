using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM
{
  public class Settings_VM : BaseViewModel<Settings_Page>
  {
    public bool Modal { get => _Modal; set => SP(ref _Modal, value); }
    private bool _Modal;
    public Settings_VM(bool modal)
    {
      this.Modal = modal;
    }

    public override void OnAppearing()
    {
      Title = "Settings";
    }
  }
}
