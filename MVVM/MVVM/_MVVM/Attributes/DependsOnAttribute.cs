using System;

namespace MVVM
{
  [AttributeUsage(AttributeTargets.Property)]
  public class DependsOnAttribute : Attribute
  {
    public string[] Properties { get; }
    public DependsOnAttribute(params string[] properties)
    {
      Properties = properties;
    }
  }
}
