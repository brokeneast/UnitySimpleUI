using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
    /// 排版模式。
    /// VERTICAL: 垂直
    /// HORIZONTAL: 水平
    /// NONE: 無
    /// </summary>
    public enum Layout {VERTICAL, HORIZONTAL, NONE};
    public Layout layout {get; protected set;}

    /// <summary>
    /// 目前有被註冊到的Tab。
    /// </summary>
    public List<Tab> tabs { get; protected set; }

    private void Awake()
    {
        tabs = new List<Tab>();
        Init();
    }

    /// <summary>
    /// 初始化，並設定預設位置。
    /// </summary>
    public override void Init()
    {
        //初始化
        _tabPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(tabPath, typeof(GameObject));
        layout = Layout.NONE;
    }

    private void Update()
    {
        //若底下帶有Tab元件的物件數量與註冊不一，則重新註冊。
        if (transform.GetComponentsInChildren<Tab>().Length != tabs.Count)
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
    /// 進階創建。
    /// </summary>
    public override void Create(TabOption option)
    {
        this.option = option;

        GameObject widget;
        defaultParent = option.parent != null ? option.parent : defaultParent;

        //物件生成
        widget = Instantiate(tabPrefab, defaultParent.transform);
        widget.name = option.name;
        //加入管理
        tabs.Add(widget.GetComponent<Tab>());
        WidgetInit(widget);
    }

    /// <summary>
    /// 根據該物件下的子物件(包含Tab元件)，重新註冊。
    /// 主要用在未按正常程序加入Tab的情形。
    /// </summary>
    public void Refresh()
    {
        tabs.Clear();
        widgetList.Clear();

        Tab[] find = GetComponentsInChildren<Tab>();
        foreach (Tab t in find)
        {
            tabs.Add(t);
            widgetList.Add(t.gameObject);
        }
    }




    /// <summary>
    /// 根據Index刪除Tab。
    /// </summary>
    public void DeleteTab(int index)
    {
        tabs[index].Delete();
        tabs.RemoveAt(index);
        Refresh();
    }

    /// <summary>
    /// 刪除底下所有的Tab。
    /// </summary>
    public override void DeleteAll()
    {
        foreach (GameObject w in widgetList)
        {
            DestroyImmediate(w);
        }
        widgetList = null;
        widgetList = new List<GameObject>();

        currentWidget = null;
    }

}
