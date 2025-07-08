namespace LeOmni.Helpers;

public sealed class ExceptionHelper {
  public static async Task<string> CatchAsync(Func<Task<string>> func) {
    try {
      return await func();
    } catch (Exception ex) {
      return $"出錯: {ex.Message}";
    }
  }
}
