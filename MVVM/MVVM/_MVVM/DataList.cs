using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MVVM
{
  /// <summary>
  /// Used for Data Types like int, bool, ...
  /// </summary>
  /// <typeparam name="T">class</typeparam>
  public class DataList<T> : ObservableCollection<T>
  {
    public DataList() : base() { }
    public DataList(IEnumerable<T> data) : base(data) { }
    public DataList(IList<T> data) : base(data) { }
  }

  /// <summary>
  /// used for Data Models like User_DM
  /// </summary>
  /// <typeparam name="TModel">User_DM</typeparam>
  public class BigDataList<TModel> : DataList<TModel> where TModel : IBaseDataModel
  {
    public BigDataList() : base() { }
    public BigDataList(IEnumerable<TModel> data) : base(data) { }
    public BigDataList(IList<TModel> data) : base(data) { }
  }
}
