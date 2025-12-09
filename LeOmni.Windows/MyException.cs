namespace LeOmni.Windows;

/// <summary>
/// 自訂例外
/// </summary>
/// <param name="message"></param>
public class MyException(string message) : Exception(message) {
  /// <summary>
  /// 無法取得資源回收筒
  /// </summary>
  /// <returns></returns>
  public static MyException 無法取得資源回收筒() => new(nameof(無法取得資源回收筒));

  /// <summary>
  /// 無法啟動 Shell.Application
  /// </summary>
  /// <returns></returns>
  public static MyException 無法啟動ShellApplication() => new(nameof(無法啟動ShellApplication));

  /// <summary>
  /// 無法建立 Shell.Application COM 物件
  /// </summary>
  /// <returns></returns>  
  public static MyException 無法建立ShellApplication_COM物件() => new("無法建立 Shell.Application COM 物件");
}
