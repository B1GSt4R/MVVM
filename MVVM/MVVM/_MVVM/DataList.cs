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
  public class DataList<T> : ObservableCollection<T>, IDataList<T>
  {
    public DataList() : base() { }
    public DataList(IEnumerable<T> data) : base(data) { }
    public DataList(IList<T> data) : base(data) { }

    public T Find(Predicate<T> predicate) => (this.ToList() as List<T>).Find(predicate);
    public IDataList<T> FindAll(Predicate<T> predicate) => (this.ToList() as List<T>).FindAll(predicate).ToDataList();
    public int FindIndex(Predicate<T> predicate) => (this.ToList() as List<T>).FindIndex(predicate);
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
