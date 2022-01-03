using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM
{
  public class BaseDataModel : BaseModel, IBaseDataModel
  {
    public TModel FromJson<TModel>(string data)
    {
      return JsonConvert.DeserializeObject<TModel>(data);
    }

    public string ToJson()
    {
      return JsonConvert.SerializeObject(this);
    }

    public T Clone<T>()
    {
      if (Object.ReferenceEquals(this, null)) return default(T);
      return (T)this.MemberwiseClone();
    }
  }
}
