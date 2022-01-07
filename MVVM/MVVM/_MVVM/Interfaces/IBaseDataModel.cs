namespace MVVM
{
  public interface IBaseDataModel
  {
    string ToJson();
    TModel FromJson<TModel>(string data);
    T Clone<T>();
  }
}
