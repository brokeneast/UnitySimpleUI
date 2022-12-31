using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Tab : UIWidget<TabOption>
{
    [SerializeField] Color colorCanceled; //未選擇時顏色
    [SerializeField] Color colorSelected; //選擇時顏色

    [Tooltip("當選擇到該頁籤時觸發動作。")]
    public UnityEvent onSelected;
    [Tooltip("當取消該頁籤時觸發動作。")]
    public UnityEvent onCanceled;

    [SerializeField] Text titleText = null;

    public TabOption option { get; protected set; }
    public bool isSelected { get; protected set; }

    Image tabImg;

    private void Awake()
    {
        tabImg = GetComponent<Image>();
        tabImg.color = colorCanceled;
    }

    /// <summary>
    /// 頁籤初始化，使用進階設定。
    /// </summary>
    public override void Init(TabOption option)
    {
        if(this.option != null)
        {

        }
        else if(option== null || option.tabsGroup == null)
        {
            Debug.LogError("無法初始化Tab元件，必須以tabsGroup元件去Create後初始化。於TabsGroup(Component)點選Create New Tab。");
            return;
        }

        //設定內容
        this.option = option;

        if(titleText.text == "")
        {
            titleText.text = option.name;
        }

        SpecificInit();
    }


    /// <summary>
    /// 根據類型頁籤進行初始化。
    /// </summary>
    protected override void SpecificInit() 
    {

    }

    /// <summary>
    /// 銷毀該元件。
    /// </summary>
    public override void Delete()
    {
        DestroyImmediate(gameObject);
    }

    /// <summary>
    /// 選擇該頁籤。
    /// </summary>
    public void Select()
    {
        //壓下選擇中
        isSelected = true;
        UIResult result = new UIResult();
        result.message = option.index.ToString();
        option.onClick?.Invoke(result);
        onSelected?.Invoke();
        //View
        SelectView();
    }

    /// <summary>
    /// 選擇該頁籤之樣式。
    /// </summary>
    protected virtual void SelectView()
    {
        tabImg.color = colorSelected;
    }

    /// <summary>
    /// 解除該頁籤。
    /// </summary>
    public void Cancel()
    {
        //取消選擇中
        isSelected = false;
        onCanceled?.Invoke();
        //View
        CancelView();

    }

    /// <summary>
    /// 取消該頁籤之樣式。
    /// </summary>
    protected virtual void CancelView()
    {
        tabImg.color = colorCanceled;
    }
}
