using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MVVM
{
  public class DataList<TModel> : ObservableCollection<TModel>
  {

  }

  public class BigDataList<TModel> : DataList<TModel> where TModel : IBaseModel
  {

  }
}
