using System;
using UnityEngine;

public abstract class Dialog : MonoBehaviour
{
    protected string message;
    protected DialogOption dialogOption;

    /// <summary>
    /// 彈跳視窗初始化。
    /// </summary>
    public void Init(string message)
    {
        this.message = message;
        SpecificInit();
    }

    /// <summary>
    /// 彈跳視窗初始化，使用進階設定。
    /// </summary>
    public void Init(DialogOption dialogOption)
    {
        this.dialogOption = dialogOption;
        SpecificInit();
    }

    /// <summary>
    /// 根據類型視窗進行初始化。
    /// </summary>
    protected virtual void SpecificInit(){}

    /// <summary>
    /// 清空視窗所有顯示設定。
    /// </summary>
    protected virtual void ResetDialog(){}

    /// <summary>
    /// 關閉視窗。
    /// </summary>
    public virtual void Cancel()
    {
        Destroy(gameObject);
    }

}
