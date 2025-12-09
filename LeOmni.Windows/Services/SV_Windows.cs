namespace LeOmni.Windows.Services;

/// <summary>
/// SV_Windows
/// </summary>
public partial class SV_Windows {
  /// <summary>
  /// 刪除資源回收筒中超過指定 n 天的檔案或資料夾。
  /// </summary>
  /// <param name="day">n 天數</param>
  /// <exception cref="Exception"></exception>
  [SupportedOSPlatform(OSPlatform.Windows)]
  public static void ClearRecycleOverDay(int day) {
    DateTime limit = DateTime.Now.AddDays(-day);
    // Shell.Application COM
    Type shellType = Type.GetTypeFromProgID("Shell.Application") ?? throw MyException.無法建立ShellApplication_COM物件();
    dynamic shell = Activator.CreateInstance(shellType) ?? throw MyException.無法啟動ShellApplication();
    // 0xA = Recycle Bin
    dynamic recycleBin = shell.NameSpace(0xA) ?? throw MyException.無法取得資源回收筒();
    // 回收筒項目數量
    int itemCount = recycleBin.Items().Count;

    for (int i = itemCount - 1; i >= 0; i--) {
      //var listError = new List<(Exception Ex, string Path)>();
      dynamic item = recycleBin.Items().Item(i);

      // 取得 System.Recycle.DateDeleted
      object? deletedObj = item.ExtendedProperty("System.Recycle.DateDeleted");

      if (deletedObj is DateTime deletedTime) {
        // 找超過天數的
        if (deletedTime < limit) {
          // 實體檔案位置（被刪除前）
          string path = item.Path;

          try {
            // 直接刪除 (送到 Recycle Bin 的暫存檔)
            File.Delete(path);
          } catch {
            // 有些項目不是純檔案 (資料夾等)
            try {
              Directory.Delete(path, true);
            } catch /*(Exception ex)*/ {
              //listError.Add((ex, path));
            }
          }
        }
      }
    }
  }
}