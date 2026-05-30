namespace LeOmni.Services;

/// <summary>
/// SV_DateTime
/// </summary>
public class SV_DateTime {
  /// <summary>回傳現在的 yyyyMMdd 字串</summary>
  public static string Now_yyyyMMdd => DateTime.Today.ToString("yyyyMMdd");
  /// <summary>回傳現在的 yyyyMM 字串</summary>
  public static string Now_yyyyMM => DateTime.Today.ToString("yyyyMM");
  /// <summary>回傳現在的 yyyy-MM-dd 字串</summary>
  public static string Now_yyyyMMddByDash => DateTime.Today.ToString("yyyy-MM-dd");
  /// <summary>回傳現在的 HH-mm-ss 字串</summary>
  public static string Now_HHmmssByDash => DateTime.Now.ToString("HH-mm-ss");

  /// <summary>
  /// 計算兩個日期之間的年、月、日差異
  /// </summary>
  /// <param name="start">yyyy/MM/dd</param>
  /// <param name="end">yyyy/MM/dd</param>
  /// <returns></returns>
  public static (int Years, int Months, int Days) CountDuring(DateTime start, DateTime end) {
    ArgumentOutOfRangeException.ThrowIfGreaterThan(start, end);

    int years = end.Year - start.Year;
    int months = end.Month - start.Month;
    int days = end.Day - start.Day;

    // 如果天數是負的月數要 -1 拿來補天數
    if (days < 0) {
      months--;
      var prevMonth = end.AddMonths(-1);
      days += DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);
    }

    // 如果月數是負的年數要 -1 拿來補月數
    if (months < 0) {
      years--;
      months += 12;
    }

    return (years, months, days);
  }
}
