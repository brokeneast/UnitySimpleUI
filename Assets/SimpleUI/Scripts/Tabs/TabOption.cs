using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabOption : UIOption
{
    /// <summary>
    /// 該頁籤的父群組。
    /// </summary>
    public TabsGroup tabsGroup { get; protected set; }
    /// <summary>
    /// 該頁籤的索引值。
    /// </summary>
    public int index { get; protected set; }

    /// <summary>
    /// Tab名稱，將顯示於Tab上。
    /// </summary>
    public string name = "Tab";

    /// <summary>
    /// 必須有父元件且包含TabsGroup元件，及索引值方能初始化。
    /// </summary>
    public TabOption(TabsGroup tabsGroup, int indexInGroup)
    {
        this.tabsGroup = tabsGroup;
        index = indexInGroup;
        SetParent(tabsGroup.gameObject);
    }

    public TabOption()
    {
    }

    /// <summary>
    /// 重新設置該Tab的Index。
    /// </summary>
    public virtual void SetIndex(int index)
    {
        this.index = index;
    }
}
