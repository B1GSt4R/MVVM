using MVVM.Structs;

namespace MVVM
{
  public static class MVVMConfig
  {
    public static Stats Stats = new Stats();
    public static bool UsePageAnimation { get; set; } = true;
  }
}
