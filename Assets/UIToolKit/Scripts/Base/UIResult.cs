/*
 * 用於承接UI執行後之動作及狀態。
 */

public struct UIResult
{
    /// <summary>
    /// 是否獲得結果。
    /// </summary>
    public bool ok;
    /// <summary>
    /// 傳送之內容。
    /// </summary>
    public string message;

    public UIResult(bool ok, string message = "")
    {
        this.ok = ok;
        this.message = message;
    }

    /// <summary>
    /// 成功獲得結果。
    /// </summary>
    /// <returns></returns>
    public static UIResult Ok()
    {
        return new UIResult(true);
    }

    /// <summary>
    /// 出現問題。
    /// </summary>
    /// <returns></returns>
    public static UIResult Failed()
    {
        return new UIResult(false);
    }

    /// <summary>
    /// 獲得結果，並傳話。
    /// </summary>
    public static UIResult Memo(string message)
    {
        return new UIResult(true, message);
    }
}
