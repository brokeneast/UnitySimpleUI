/*
 * UI小工具的管理類。
 */
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIWidgetManager<T, T1> : MonoBehaviour
    where T : UIWidget<T1>
    where T1 : Option
{
    protected T1 option;//設定選項
    protected GameObject defaultParent;//元件放置位置
    protected List<GameObject> widgetList;//受管理之UI元件

    private GameObject currentWidget;//目前產生的UI元件

    /// <summary>
    /// 初始化於對應位置。
    /// </summary>
    public virtual void Init(GameObject defaultParent)
    {
        this.defaultParent = defaultParent;
        widgetList = new List<GameObject>();
    }

    /// <summary>
    /// 創建項目UI工具。
    /// </summary>
    public virtual void Create(T1 option)
    {
        this.option = option;
        WidgetInit(null);//需放入欲初始化的UI物件
    }

    /// <summary>
    /// UI元件初始化。
    /// </summary>
    protected void WidgetInit(GameObject widget)
    {
        if (widget != null)
        {
            widget.GetComponent<T>().Init(option);
            SetCurrentWidget(widget);
            widgetList.Add(widget);
        }
        else
        {
            Debug.LogWarning("未生成對應之物件。");
        }
    }

    protected void SetCurrentWidget(GameObject widget)
    {
        currentWidget = widget;
    }

    /// <summary>
    /// 關閉目前產生的介面。
    /// </summary>
    public virtual void Cancel()
    {
        widgetList.Remove(currentWidget);
        Destroy(currentWidget);

        currentWidget = widgetList.Count > 0 ? widgetList[widgetList.Count - 1] : null;//指向最後一個
    }

    /// <summary>
    /// 關閉所有該管理所產生的介面。
    /// </summary>
    public virtual void AllCancel()
    {
        foreach(GameObject w in widgetList)
        {
            Destroy(w);
        }
        widgetList = null;
        widgetList = new List<GameObject>();

        currentWidget = null;
    }
}
