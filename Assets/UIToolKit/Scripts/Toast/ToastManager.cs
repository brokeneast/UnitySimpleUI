using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToastManager : UIWidgetManager<ToastOption>
{
    private static readonly string fadingToastPath = "Assets/UIToolkit/Prefabs/Toast/FadingToast.prefab";
    private static readonly string textToastPath = "Assets/UIToolkit/Prefabs/Toast/TextToast.prefab";

    #region Toast Prefab
    [SerializeField]
    [Tooltip("自動消逝型態的吐司提示。")]
    GameObject _fadingToastPrefab;

    public GameObject fadingToastPrefab
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

    public GameObject textToastPrefab
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
    public override void Init(GameObject parent)
    {
        option = new ToastOption(ToastOption.Type.FADING_TOAST);
        this.parent = parent;

        //預設
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
    }

    /// <summary>
    /// 進階創建。
    /// </summary>
    public override void Create(ToastOption option)
    {
        this.option = option;
        
        //物件生成
        if(option.type == ToastOption.Type.TEXT_TOAST)
        {
            currentWidget = Instantiate(fadingToastPrefab, parent.transform);
        }
        else
        {
            currentWidget = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath(fadingToastPath, typeof(GameObject)), parent.transform);
        }
    }

    /// <summary>
    /// 關閉全部。
    /// </summary>
    public override void Cancel()
    {
        Destroy(gameObject);
    }
}
