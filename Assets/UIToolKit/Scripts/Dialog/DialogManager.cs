using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DialogManager : UIWidgetManager<Dialog, DialogOption>
{
    #region Dialog Prefab Settings
    private readonly string alertDialogPath = "Assets/UIToolkit/Prefabs/Dialog/AlertDialog.prefab";
    private readonly string choiceDialogPath = "Assets/UIToolkit/Prefabs/Dialog/ChoiceDialog.prefab";
    private readonly string infoDialogPath = "Assets/UIToolkit/Prefabs/Dialog/InfoDialog.prefab";

    [SerializeField]
    [Tooltip("提醒視窗，提供警告、提醒等一般用途之彈跳視窗。")]
    GameObject _alertDialogPrefab;

    private GameObject alertDialogPrefab
    {
        get { return _alertDialogPrefab; }
        set
        {
            if (value != null)
            {
                _alertDialogPrefab = value;
            }
        }
    }

    [SerializeField]
    [Tooltip("選擇視窗，可增添按鈕選項，供使用者選擇。")]
    GameObject _choiceDialogPrefab;

    private GameObject choiceDialogPrefab
    {
        get { return _choiceDialogPrefab; }
        set
        {
            if (value != null)
            {
                _choiceDialogPrefab = value;
            }
        }
    }

    [SerializeField]
    [Tooltip("資訊視窗，可增添按鈕選項，供使用者選擇。")]
    GameObject _infoDialogPrefab;

    private GameObject infoDialogPrefab
    {
        get { return _infoDialogPrefab; }
        set
        {
            if (value != null)
            {
                _infoDialogPrefab = value;
            }
        }
    }
    #endregion

    /// <summary>
    /// 初始化，並設定預設位置。
    /// </summary>
    public override void Init()
    {
        //初始化
        _alertDialogPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(alertDialogPath, typeof(GameObject));
        _choiceDialogPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(choiceDialogPath, typeof(GameObject));
        _infoDialogPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(infoDialogPath, typeof(GameObject));
    }

    /// <summary>
    /// 一般創建。預設為AlertDialog。
    /// </summary>
    public void Create(string msg)
    {
        DialogOption option = new DialogOption();
        option.message = msg;
        Create(option);
    }

    /// <summary>
    /// 進階創建。
    /// </summary>
    public override void Create(DialogOption option)
    {
        this.option = option;

        GameObject widget;
        defaultParent = option.parent != null ? option.parent : defaultParent;

        //物件生成
        if (option.type == DialogOption.Type.CHOICE_DIALOG)
        {
            widget = Instantiate(choiceDialogPrefab, defaultParent.transform);
        }
        else if (option.type == DialogOption.Type.INFO_DIALOG)
        {
            widget = Instantiate(infoDialogPrefab, defaultParent.transform);
        }
        else if (option.type == DialogOption.Type.OK_OR_CANCEL_DIALOG)
        {
            widget = Instantiate(alertDialogPrefab, defaultParent.transform);
        }
        else
        {
            widget = Instantiate(alertDialogPrefab, defaultParent.transform);
        }

        WidgetInit(widget);
    }
}
