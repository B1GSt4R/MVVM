using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MVVM
{
  /// <summary>
  /// Used for Data Types like int, bool, ...
  /// </summary>
  /// <typeparam name="TModel">class</typeparam>
  public class DataList<T> : ObservableCollection<T>
  {

  }

  /// <summary>
  /// used for Data Models like User_DM
  /// </summary>
  /// <typeparam name="TModel">User_DM</typeparam>
  public class BigDataList<TModel> : DataList<TModel> where TModel : IBaseDataModel
  {

  }
}
