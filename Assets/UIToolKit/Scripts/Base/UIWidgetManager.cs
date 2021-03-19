/*
 * UI小工具的管理類。
 */
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIWidgetManager<T, TOption> : MonoBehaviour
    where T : UIWidget<TOption>
    where TOption : Option
{
    public GameObject defaultParent;//元件放置位置
    protected TOption option;//設定選項
    protected List<GameObject> widgetList = new List<GameObject>();//受管理之UI元件

    private GameObject currentWidget;//目前產生的UI元件

    /// <summary>
    /// 初始化於對應位置。
    /// </summary>
    public virtual void Init(){}

    /// <summary>
    /// 創建項目UI工具。
    /// </summary>
    public virtual void Create(TOption option)
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
