public class Loading : UIWidget<LoadingOption>
{
    protected LoadingOption option;

    /// <summary>
    /// 讀取提示初始化。
    /// </summary>
    public override void Init(LoadingOption option)
    {
        this.option = option;
        SpecificInit();
    }

    /// <summary>
    /// 根據類型讀取進行初始化。
    /// </summary>
    protected override void SpecificInit() { }

    /// <summary>
    /// 關閉。
    /// </summary>
    public override void Delete()
    {
        option.afterCancel?.Invoke();
        Destroy(gameObject);
    }
}
