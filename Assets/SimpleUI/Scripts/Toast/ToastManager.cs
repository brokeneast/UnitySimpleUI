using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToastManager : UIWidgetManager<Toast, ToastOption>
{
    #region Toast Prefab Settings
    private readonly string fadingToastPath = "Assets/SimpleUI/Prefabs/Toast/FadingToast.prefab";
    private readonly string textToastPath = "Assets/SimpleUI/Prefabs/Toast/TextToast.prefab";

    [SerializeField]
    [Tooltip("自動消逝型態的吐司提示。")]
    GameObject _fadingToastPrefab;

    private GameObject fadingToastPrefab
    {
        get { return _fadingToastPrefab; }
        set
        {
            if(value != null)
            {
                _fadingToastPrefab = value;
            }
        }
    }

    [SerializeField]
    [Tooltip("一般吐司提示，需自行刪除。")]
    GameObject _textToastPrefab;

    private GameObject textToastPrefab
    {
        get { return _textToastPrefab; }
        set
        {
            if (value != null)
            {
                _textToastPrefab = value;
            }
        }
    }
    #endregion


    /// <summary>
    /// 初始化。
    /// </summary>
    public override void Init()
    {
        //初始化
        _fadingToastPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(fadingToastPath, typeof(GameObject));
        _textToastPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(textToastPath, typeof(GameObject));
    }

    /// <summary>
    /// 一般創建。預設為FadingToast
    /// </summary>
    public void Create(string msg)
    {
        option = new ToastOption(ToastOption.Type.FADING_TOAST);
        option.message = msg;
        Create(option);
    }

    /// <summary>
    /// 進階創建。
    /// </summary>
    public override void Create(ToastOption option)
    {
        this.option = option;

        GameObject widget;
        defaultParent = option.parent != null ? option.parent : defaultParent;

        //物件生成
        if(option.type == ToastOption.Type.TEXT_TOAST)
        {
            widget = Instantiate(fadingToastPrefab, defaultParent.transform);
        }
        else
        {
            widget = Instantiate(fadingToastPrefab, defaultParent.transform);
        }

        WidgetInit(widget);
    }
}
