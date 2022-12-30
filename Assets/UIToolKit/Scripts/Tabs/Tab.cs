using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Tab : UIWidget<TabOption>
{
    public TabOption option { get; protected set; }

    /// <summary>
    /// 頁籤初始化，使用進階設定。
    /// </summary>
    public override void Init(TabOption option)
    {
        if(option.tabsGroup == null)
        {
            Debug.LogError("無法產生Tab元件，必須以tabsGroup元件去初始化。");
            return;
        }

        this.option = option;
        SpecificInit();
    }


    /// <summary>
    /// 根據類型頁籤進行初始化。
    /// </summary>
    protected override void SpecificInit() { }

    /// <summary>
    /// 銷毀該元件。
    /// </summary>
    public override void Cancel()
    {
        DestroyImmediate(gameObject);
    }

}
