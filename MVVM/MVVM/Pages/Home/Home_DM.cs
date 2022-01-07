using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM
{
  public class Home_DM : BaseDataModel
  {
    public string Name { get => _Name; set => SP(ref _Name, value); }
    private string _Name;
    public string Vorname { get => _Vorname; set => SP(ref _Vorname, value); }
    private string _Vorname;
    [DependsOn(nameof(Vorname), nameof(Name))]
    public string Mix => $"- {Vorname.Substring(0, 1)}. {Name}";
  }
}
