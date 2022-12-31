/*
 * 吐司提示，在不干擾使用者流程下的提示介面。
 */

public abstract class Toast : UIWidget<ToastOption>
{
    protected ToastOption option;

    /// <summary>
    /// 吐司提示初始化。
    /// </summary>
    public override void Init(ToastOption option)
    {
        this.option = option;
        SpecificInit();
    }

    /// <summary>
    /// 根據類型吐司進行初始化。
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
