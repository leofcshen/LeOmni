namespace LeOmni.Windows.Services;

/// <summary>
/// SV_Windows
/// </summary>
public partial class SV_Windows {
  /// <summary>
  /// 刪除資源回收筒中超過 n 天的檔案或資料夾。
  /// -1 表示全部刪除。
  /// </summary>
  /// <param name="day">n 天數</param>
  /// <exception cref="Exception"></exception>
  [SupportedOSPlatform(OSPlatform.Windows)]
  public static void ClearRecycleBin(int day) {
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

      if (day != -1) {
        // 取得 System.Recycle.DateDeleted
        object? deletedObj = item.ExtendedProperty("System.Recycle.DateDeleted");

        // 沒日期、不是 DateTime → 跳過
        if (deletedObj is not DateTime deletedTime)
          continue;

        // 還沒超過指定天數 → 跳過
        if (deletedTime >= limit)
          continue;
      }

      string path = item.Path;

      try {
        File.Delete(path);
      } catch {
        try {
          Directory.Delete(path, true);
        } catch {
          // ignore
        }
      }
    }
  }
}