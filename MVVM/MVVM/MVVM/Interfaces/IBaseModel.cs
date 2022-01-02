using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM
{
  public interface IBaseModel
  {
    void OnPropertyChanged(string propertyName);
  }
}
