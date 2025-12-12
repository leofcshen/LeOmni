using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;

namespace LeOmni.Windows.Services;

public partial class SV_Windows {
  /// <summary>
  /// Windows 通知
  /// </summary>
  public class Toast {
    /// <summary>
    /// 顯示 Windows 通知
    /// </summary>
    /// <param name="text"></param>
    /// <param name="title"></param>
    /// <param name="uri"></param>
    public static void ShowToast(string? text = null, string? title = null, Uri? uri = null) {
      //title ??= Assembly.GetExecutingAssembly().GetName().Name; //這個會顯示類別庫名稱
      title ??= Process.GetCurrentProcess().ProcessName;

      var toastBuilder = new ToastContentBuilder()
        .AddText(title);

      if (text is not null) {
        toastBuilder.AddText(text);
      }

      if (uri is not null) {
        toastBuilder.AddInlineImage(uri);
      }

      toastBuilder.Show(x => x.ExpirationTime = DateTimeOffset.Now.AddSeconds(3));
    }
  }
}
