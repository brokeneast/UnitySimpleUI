using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIWidget<T> : MonoBehaviour
    where T : UIOption
{
    /// <summary>
    /// 初始化。
    /// </summary>
    public abstract void Init(T option);

    /// <summary>
    /// 根據類型初始化。
    /// </summary>
    protected abstract void SpecificInit();

    /// <summary>
    /// 關閉。
    /// </summary>
    public abstract void Delete();
}
