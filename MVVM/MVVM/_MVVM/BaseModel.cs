using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM
{
  public class BaseModel : IBaseModel, INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SP<T>(ref T field, T data, string propertyName = "")
    {
      if (!Equals(field, data))
      {
        field = data;
        OnPropertyChanged(propertyName);
        return true;
      }
      return false;
    }
  }
}
