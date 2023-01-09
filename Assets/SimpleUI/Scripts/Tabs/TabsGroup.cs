using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TabsGroup : UIWidgetManager<Tab, TabOption>
{
    //物件路徑
    //TabsGroup
    private static readonly string horizontalTabsGroupPath = "Assets/SimpleUI/Prefabs/Tabs/HorizontalTabsGroup.prefab";
    private static readonly string verticalTabsGroupPath = "Assets/SimpleUI/Prefabs/Tabs/VerticalTabsGroup.prefab";

    #region Tab Prefab Settings
    private readonly string tabPath = "Assets/SimpleUI/Prefabs/Tabs/Tab.prefab";

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
    public List<Tab> tabs { get; protected set; }

    /// <summary>
    /// 目前選到頁籤之索引值。
    /// </summary>
    public int currentIndex { get; protected set; }
    public delegate void OnCurrentTabChanged(int index);
    /// <summary>
    /// 當目前選擇到的頁籤改變。
    /// </summary>
    public event OnCurrentTabChanged onCurrentTabChanged;

    private void Start()
    {
        Init();

        SetCurrentSelectTab(0);
    }

    #region Add TabsGroup
    /// <summary>
    /// 新增VerticalTabsGroup於Hierarchy。
    /// </summary>
    [MenuItem("GameObject/SimpleUI/Tabs/Vertical TabsGroup", false, 101)]
    public static void CreateVerticalTabsGroup()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)//為UI元件須於Canvas下
        {
            GameObject vtg = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath(verticalTabsGroupPath, typeof(GameObject)), canvas.transform);
            vtg.name = "VerticalTabsGroup";
        }
        else
        {
            Debug.LogError("TabsGroup為UI元件，請先建立UI Canvas(GameObject > UI > Canvas)以便生成。");
        }
    }
    /// <summary>
    /// 新增HorizontalTabsGroup於Hierarchy。
    /// </summary>
    [MenuItem("GameObject/SimpleUI/Tabs/Horizontal TabsGroup", false, 102)]
    public static void CreateHorizontalTabsGroup()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)//為UI元件須於Canvas下
        {
            GameObject htg = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath(horizontalTabsGroupPath, typeof(GameObject)), canvas.transform);
            htg.name = "HorizontalTabsGroup";
        }
        else
        {
            Debug.LogError("TabsGroup為UI元件，請先建立UI Canvas(GameObject > UI > Canvas)以便生成。");
        }
    }
    #endregion

    /// <summary>
    /// 初始化，並設定預設位置。
    /// </summary>
    public override void Init()
    {
        //初始化
        _tabPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(tabPath, typeof(GameObject));
        tabs = new List<Tab>();
        Refresh();
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
        //重新定義
        for (int i = 0; i < find.Length; i++)
        {
            option = new TabOption(this, tabs.Count);
            tabs.Add(find[i]);
            WidgetInit(find[i].gameObject);
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

    /// <summary>
    /// 設置目前選擇的頁籤。
    /// </summary>
    public void SetCurrentSelectTab(int index)
    {
        currentIndex = index;
        onCurrentTabChanged?.Invoke(currentIndex);
    }
}
