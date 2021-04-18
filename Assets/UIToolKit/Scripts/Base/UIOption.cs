/*
 * 用來設計介面的選項集。
 */
using UnityEngine;

public abstract class UIOption
{
    /// <summary>
    /// UI生成位置，若有特定指定將使用。
    /// </summary>
    public GameObject parent { get; private set; }

    public void SetParent(GameObject p)
    {
        parent = p;
    }

    /// <summary>
    /// UI互動委派。
    /// </summary>
    public delegate void UICallback();

    /// <summary>
    /// UI互動委派並帶結果。
    /// </summary>
    public delegate void UICallbackWithData(UIResult result);


    /// <summary>
    /// 與該UI互動後，所委派之動作，需挾帶UI互動結果。
    /// </summary>
    public UICallback onClick { get; protected set; }

    /// <summary>
    /// 設置點擊該元件後之委派動作。
    /// </summary>
    public virtual void SetClickCallback(UICallback callback)
    {
        onClick = callback;
    }
}
