using System;

namespace MVVM
{
  public interface IDataList<T>
  {
    T Find(Predicate<T> predicate);
    IDataList<T> FindAll(Predicate<T> predicate);
    int FindIndex(Predicate<T> predicate);
  }
}
