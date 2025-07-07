namespace LeOmni.Playwright.Extensions;

public static class PlaywrightIPageExtension {
  public static async Task<string> GetXPathAsync(this IPage page, string xpath) {
    var locator = page.Locator($"xpath={xpath}");
    await locator.WaitForAsync();

    return await locator.InnerTextAsync();
  }

  public static async Task<List<string>> GetXPathAsync(this IPage page, params string[] xpaths) {
    var results = new List<string>();

    foreach (var xpath in xpaths) {
      var locator = page.Locator($"xpath={xpath}");
      await locator.WaitForAsync();
      results.Add(await locator.InnerTextAsync());
    }

    return results;
  }
}