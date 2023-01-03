public abstract class Dialog : UIWidget<DialogOption>
{
    protected DialogOption option = new DialogOption();

    /// <summary>
    /// 彈跳視窗初始化，使用進階設定。
    /// </summary>
    public override void Init(DialogOption option)
    {
        this.option = option;
        SpecificInit();
    }

    /// <summary>
    /// 根據類型視窗進行初始化。
    /// </summary>
    protected override void SpecificInit(){}

    /// <summary>
    /// 清空視窗所有顯示設定。
    /// </summary>
    protected virtual void ResetDialog(){}

    /// <summary>
    /// 預設按鍵配置。
    /// </summary>
    protected abstract void DefaultBtnSettings();

    /// <summary>
    /// 關閉視窗。
    /// </summary>
    public override void Delete()
    {
        option.onCancel?.Invoke(UIResult.Ok());
        Destroy(gameObject);
    }

}
