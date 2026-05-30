using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LeOmni.Services;

/// <summary>
/// SV_CSharp
/// </summary>
public class SV_CSharp {
  private static readonly Dictionary<string, string> _type別名 = new() {
    //系統的
    { "Boolean", "bool" },
    { "Byte", "byte" },
    { "SByte", "sbyte" },
    { "Char", "char" },
    { "Decimal", "decimal" },
    { "Double", "double" },
    { "Single", "float" },
    { "Int32", "int" },
    { "UInt32", "uint" },
    { "Int64", "long" },
    { "UInt64", "ulong" },
    { "Object", "object" },
    { "Int16", "short" },
    { "UInt16", "ushort" },
    { "String", "string" },
    //void
    { "Void", "void" },
  };

  /// <summary>取得呼叫端的型別</summary>
  public static string GetClass() {
    StackTrace stackTrace = new();
    // 取得第二個 GetFrame(1)，GetFrame(0) 是當前 GetClassName 本身
    StackFrame? frame = stackTrace.GetFrame(1);
    Type? callerType = frame?.GetMethod()?.DeclaringType;

    return callerType != null ? callerType.Name : "Unknown";
  }

  /// <summary>
  /// 取得呼叫端的方法含簽章
  /// </summary>
  /// <param name="methodName"></param>
  /// <returns></returns>
  public static string GetMethod含簽章([CallerMemberName] string methodName = "")
    => GetMethod(true, methodName, 2);

  /// <summary>
  /// 取得呼叫端的方法
  /// </summary>
  /// <param name="isAddSignature">是否添加方法簽章</param>
  /// <param name="methodName"></param>
  /// <param name="frameIndex"></param>
  /// <returns></returns>
  public static string GetMethod(bool isAddSignature = false, [CallerMemberName] string methodName = "", int frameIndex = 1) {
    if (!isAddSignature)
      return methodName;

    // 使用 StackTrace 獲取調用堆棧
    StackTrace stackTrace = new();
    StackFrame? stackFrame = stackTrace.GetFrame(frameIndex); // 獲取調用該方法的堆棧幀

    MethodBase? method = stackFrame?.GetMethod(); // 獲取方法信息
    MethodInfo? methodInfo = method as MethodInfo; // 獲取方法詳細信息
    ParameterInfo[]? parameters = method?.GetParameters(); // 獲取方法參數

    // 構建方法簽章
    string returnType = string.Empty;

    if (methodInfo != null) {
      returnType = methodInfo.ReturnType.Name;

      if (_type別名.TryGetValue(returnType, out string? value)) {
        returnType = value;
      }
    }

    string methodSignature = $"{returnType} {method?.DeclaringType}.{methodName}(";

    for (int i = 0; i < parameters?.Length; i++) {
      var parameterType = parameters[i].ParameterType.Name;

      //有別名的話用別名
      if (_type別名.TryGetValue(parameterType, out string? value)) {
        parameterType = value;
      }

      methodSignature += $"{parameterType} {parameters[i].Name}";

      if (i < parameters.Length - 1) {
        methodSignature += ", ";
      }
    }

    methodSignature += ")";

    return methodSignature;
  }

  /// <summary>取得方法名稱</summary>
  public static string GetMethodName([CallerMemberName] string methodName = "") => methodName;

  /// <summary>
  /// STARun
  /// </summary>
  /// <param name="action"></param>
  public static void STARun(Action action) {
    var thread = new Thread(() => action());
    // 設定為 STA
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
  }
}

/// <summary>
/// </summary>
/// <remarks>
/// 參考文件
/// <see href="https://blog.miniasp.com/post/2023/01/12/LINQPad-Dump-with-Syntax-Highlighting#google_vignette">
/// 如何讓 LINQPad 輸出的 JSON 結果可以顯示語法高亮
/// </see>
/// </remarks>
public class MyT {

}
