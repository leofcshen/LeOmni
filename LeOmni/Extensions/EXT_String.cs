namespace LeOmni.Extensions;

/// <summary>
/// string 擴充方法
/// </summary>
public static class EXT_String {
  extension(string x) {
    /// <summary>
    /// 移除字串裡的目標字串
    /// </summary>
    /// <param name="removeTarget"></param>
    /// <returns></returns>
    public string Remove(string removeTarget) => x.Replace(removeTarget, string.Empty);

    /// <summary>
    /// 移除字串裡的空格
    /// </summary>
    /// <returns></returns>
    public string RemoveSpace() => x.Replace(" ", string.Empty);
  }
}
