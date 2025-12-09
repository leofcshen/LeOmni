namespace LeOmni.Playwright.Services;

public class PlaywrightService : IAsyncDisposable {
  private readonly IPlaywright _playwright;
  private readonly IBrowser _browser;
  public IPage Page { get; private set; }

  private PlaywrightService(IPlaywright playwright, IBrowser browser, IPage page) {
    _playwright = playwright;
    _browser = browser;
    Page = page;
  }

  public static async Task<PlaywrightService> CreateAsync(bool headless = false) {
    var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
    var browser = await playwright.Chromium.LaunchAsync(new() {
      Headless = headless
    });
    var page = await browser.NewPageAsync();

    return new PlaywrightService(playwright, browser, page);
  }

  public async ValueTask DisposeAsync() {
    await Page.CloseAsync();
    await _browser.CloseAsync();
    _playwright.Dispose();
    GC.SuppressFinalize(this);
  }
}