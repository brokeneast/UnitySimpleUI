public abstract class Dialog : UIWidget<DialogOption>
{
    protected DialogOption option;

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
    /// 清空視窗所有顯示設定，用於介面重整。
    /// </summary>
    protected virtual void ResetDialog(){}

    /// <summary>
    /// 關閉視窗。
    /// </summary>
    public override void Cancel()
    {
        option.afterCancel?.Invoke();
        Destroy(gameObject);
    }

}
