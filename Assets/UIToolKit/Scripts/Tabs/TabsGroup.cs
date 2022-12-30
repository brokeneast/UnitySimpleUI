using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class TabsGroup : UIWidgetManager<Tab, TabOption>
{
    #region Tab Prefab Settings
    private readonly string tabPath = "Assets/UIToolkit/Prefabs/Tabs/Tab.prefab";

    [SerializeField]
    [Tooltip("頁籤，在同一群組下可進行連動。")]
    GameObject _tabPrefab;

    private GameObject tabPrefab
    {
        get { return _tabPrefab; }
        set
        {
            if (value != null)
            {
                _tabPrefab = value;
            }
        }
    }
    #endregion

    /// <summary>
    /// 目前有被註冊到的Tab。
    /// </summary>
    public List<Tab> tabs = new List<Tab>();

    /// <summary>
    /// 初始化，並設定預設位置。
    /// </summary>
    public override void Init()
    {
        //初始化
        _tabPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(tabPath, typeof(GameObject));
    }

    private void Update()
    {
        if(transform.childCount!= tabs.Count)
        {
            Refresh();
        }
    }

    /// <summary>
    /// 加入Tab至該元件下。
    /// </summary>
    public void CreateTab()
    {
        TabOption option = new TabOption(this, tabs.Count);
        Create(option);
    }

    /// <summary>
    /// 根據Index刪除Tab。
    /// </summary>
    public void DeleteTab(int index)
    {
        tabs.RemoveAt(index);
        UpdateTabsIndex();
    }


    /// <summary>
    /// 根據目前該Group下的子Tabs重新編Index。
    /// </summary>
    private void UpdateTabsIndex()
    {
        for (int i = 0; i < tabs.Count; i++)
        {
            tabs[i].option.SetIndex(i);
        }
    }

    /// <summary>
    /// 根據該物件下的子物件(包含Tab元件)，重新註冊。
    /// 主要用在未按正常程序加入Tab的情形。
    /// </summary>
    public void Refresh()
    {
        tabs.Clear();
        Tab[] find = GetComponentsInChildren<Tab>();
        foreach (Tab t in find)
        {
            tabs.Add(t);
        }
    }


    /// <summary>
    /// 進階創建。
    /// </summary>
    public override void Create(TabOption option)
    {
        this.option = option;

        GameObject widget;
        defaultParent = option.parent != null ? option.parent : defaultParent;

        //物件生成
        widget = Instantiate(tabPrefab, defaultParent.transform);
        //加入管理
        tabs.Add(widget.GetComponent<Tab>());
        WidgetInit(widget);
    }
}
