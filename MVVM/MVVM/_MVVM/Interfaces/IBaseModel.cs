using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVM
{
  public interface IBaseModel
  {
    void OnPropertyChanged(string propertyName);
  }
}
