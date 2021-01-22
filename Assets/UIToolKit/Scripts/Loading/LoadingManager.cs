using UnityEditor;
using UnityEngine;

public class LoadingManager : UIWidgetManager<Loading, LoadingOption>
{
    #region Toast Prefab
    private readonly string loadingMaskPath = "Assets/UIToolkit/Prefabs/Loading/LoadingMask.prefab";
    private readonly string transparentPath = "Assets/UIToolkit/Prefabs/Loading/TransparentMask.prefab";
    private readonly string loadingPath = "Assets/UIToolkit/Prefabs/Loading/Loading.prefab";

    [SerializeField]
    [Tooltip("滿版讀取遮罩。")]
    GameObject _loadingMaskPrefab;

    public GameObject loadingMaskPrefab
    {
        get { return _loadingMaskPrefab; }
        set
        {
            if (value != null)
            {
                _loadingMaskPrefab = value;
            }
        }
    }

    [SerializeField]
    [Tooltip("透明遮罩。")]
    GameObject _transparentPrefab;

    public GameObject transparentPrefab
    {
        get { return _transparentPrefab; }
        set
        {
            if (value != null)
            {
                _transparentPrefab = value;
            }
        }
    }

    [SerializeField]
    [Tooltip("讀取小圖示，不進行遮蔽。")]
    GameObject _loadingPrefab;

    public GameObject loadingPrefab
    {
        get { return _loadingPrefab; }
        set
        {
            if (value != null)
            {
                _loadingPrefab = value;
            }
        }
    }
    #endregion

    /// <summary>
    /// 初始化。
    /// </summary>
    public override void Init(GameObject defaultParent)
    {
        //初始化
        _loadingMaskPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(loadingMaskPath, typeof(GameObject));
        _transparentPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(transparentPath, typeof(GameObject));
        _loadingPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(loadingPath, typeof(GameObject));

        //預設
        this.defaultParent = defaultParent;
    }

    /// <summary>
    /// 一般創建。預設為滿版讀取遮罩。
    /// </summary>
    public void Create()
    {
        option = new LoadingOption(LoadingOption.Type.LOADING_MASK);
        Create(option);
    }

    /// <summary>
    /// 進階創建。
    /// </summary>
    public override void Create(LoadingOption option)
    {
        this.option = option;
        GameObject widget;

        //物件生成
        if (option.type == LoadingOption.Type.TRANSPARENT_BLOCK_MASK)//讀取Mask
        {
            widget = Instantiate(transparentPrefab, defaultParent.transform);
        }
        else if (option.type == LoadingOption.Type.LOADING)
        {
            widget = Instantiate(transparentPrefab, defaultParent.transform);
        }
        else//預設Loading Mask
        {
            widget = Instantiate(loadingMaskPrefab, defaultParent.transform);
        }

        WidgetInit(widget);
    }

}
