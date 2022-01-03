using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MVVM
{
  public class BaseModel : IBaseModel, INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      CheckProperties(propertyName);
    }

    protected bool SP<T>(ref T field, T data, [CallerMemberName] string propertyName = "")
    {
      if (!Equals(field, data))
      {
        field = data;
        OnPropertyChanged(propertyName);
        return true;
      }
      return false;
    }

    private void CheckProperties(string property)
    {
      //[DependsOn(nameof(Main_DM.TestTitle), nameof(Data))] --> not working/triggering cause of GetType is in Main_DM and not in Main_VM
      GetType().GetProperties().Where(x => x.GetCustomAttribute<DependsOnAttribute>() != null).ToList().ForEach(x =>
      {
        if (x.GetCustomAttribute<DependsOnAttribute>().Properties.Contains(property)) OnPropertyChanged(x.Name);
      });
    }
  }
}
