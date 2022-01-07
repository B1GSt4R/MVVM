using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM
{
  public static partial class ListExtension
  {
    public static DataList<T> ToDataList<T>(this IEnumerable<T> source) => new DataList<T>(source);
    public static BigDataList<T> ToBigDataList<T>(this IEnumerable<T> source) where T : IBaseDataModel => new BigDataList<T>(source);
    public static DataList<T> ToDataList<T>(this IList<T> source) => new DataList<T>(source);
    public static BigDataList<T> ToBigDataList<T>(this IList<T> source) where T : IBaseDataModel => new BigDataList<T>(source);
    public static IList<T> ToList<T>(this DataList<T> source) => new List<T>(source);
    public static IList<T> ToList<T>(this BigDataList<T> source) where T : IBaseDataModel => new List<T>(source);
  }
}
