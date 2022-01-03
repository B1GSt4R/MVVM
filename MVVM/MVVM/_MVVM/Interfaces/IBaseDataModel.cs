using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM
{
  public interface IBaseDataModel
  {
    string ToJson();
    TModel FromJson<TModel>(string data);
  }
}
