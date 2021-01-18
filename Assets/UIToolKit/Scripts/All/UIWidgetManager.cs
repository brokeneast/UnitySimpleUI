/*
 * UI小工具的管理類。
 */
using UnityEngine;

public abstract class UIWidgetManager<T> : MonoBehaviour
    where T : Option
{
    protected T option;//設定選項
    protected GameObject parent;//元件放置位置
    protected GameObject currentWidget;//目前產生的UI元件

    /// <summary>
    /// 初始化於對應位置。
    /// </summary>
    public virtual void Init(GameObject parent)
    {
        this.parent = parent;
    }

    /// <summary>
    /// 創建項目UI工具。
    /// </summary>
    public virtual void Create(T option)
    {
        this.option = option;
    }

    /// <summary>
    /// 關閉產生的介面。
    /// </summary>
    public abstract void Cancel();
}
