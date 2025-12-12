namespace LeOmni.Services;

/// <summary>
/// SV_FileIO
/// </summary>
public partial class SV_FileIO {
  /// <summary>
  /// 取得絕對路徑的 Uri
  /// </summary>
  /// <param name="filePath"></param>
  /// <returns></returns>
  public static Uri GetUriFromFilePath(string filePath) {
    return new Uri(filePath, UriKind.Absolute);
  }
}
