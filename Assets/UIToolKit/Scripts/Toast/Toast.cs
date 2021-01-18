/*
 * 吐司提示，在不干擾使用者流程下的提示介面。
 */
using UnityEngine;

public abstract class Toast : MonoBehaviour
{
    protected string message;

    /// <summary>
    /// 吐司提示初始化。
    /// </summary>
    public void Init(string message)
    {
        this.message = message;
        SpecificInit();
    }

    /// <summary>
    /// 根據類型吐司進行初始化。
    /// </summary>
    protected virtual void SpecificInit() { }

    /// <summary>
    /// 關閉。
    /// </summary>
    public virtual void Cancel()
    {
        Destroy(gameObject);
    }
}
