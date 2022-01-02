using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM
{
  public class Main_DM : BaseDataModel
  {
    public string TestTitle { get => _TestTitle; set => SP(ref _TestTitle, value); }
    private string _TestTitle;
  }
}
