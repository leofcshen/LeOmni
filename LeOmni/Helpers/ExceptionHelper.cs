namespace LeOmni.Helpers;

/// <summary>
/// ExceptionHelper
/// </summary>
public sealed class ExceptionHelper {
  /// <summary>
  /// 錯誤處理
  /// </summary>
  /// <param name="func"></param>
  /// <returns></returns>
  public static async Task<string> CatchAsync(Func<Task<string>> func) {
    try {
      return await func();
    } catch (Exception ex) {
      return $"出錯: {ex.Message}";
    }
  }
}
