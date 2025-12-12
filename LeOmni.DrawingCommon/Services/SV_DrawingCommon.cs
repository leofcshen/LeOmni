using System.Drawing;
using System.Drawing.Imaging;

namespace LeOmni.DrawingCommon.Services;

/// <summary>
/// SV_DrawingCommon
/// </summary>
public class SV_DrawingCommon {
  /// <summary>
  /// 把 Image 存到指定路徑
  /// </summary>
  /// <param name="image"></param>
  /// <param name="filePath"></param>
  public static void SaveImageToFile(Image image, string filePath) {
    string directory = Path.GetDirectoryName(filePath);

    if (!Directory.Exists(directory)) {
      Directory.CreateDirectory(directory);
    }

    // 也可以用其他格式儲存
    image.Save(filePath, ImageFormat.Jpeg);
  }
}
