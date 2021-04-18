/*
 * 吐司指示選項。
 */
using UnityEngine.Events;

public class ToastOption : UIOption
{
    public enum Type {TEXT_TOAST,FADING_TOAST};
    public Type type { get; private set; }

    /// <summary>
    /// 吐司指示文字內容。
    /// </summary>
    public string message;

    /// <summary>
    /// 當吐司提示關閉時。
    /// </summary>
    public UnityAction afterCancel;

    /// <summary>
    /// 保留時間，並於時間到後自動消逝，適用於FadingToast。
    /// </summary>
    private float holdingTime;

    public ToastOption(Type type)
    {
        this.type = type;
    }


}
