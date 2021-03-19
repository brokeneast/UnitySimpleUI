/*
 * 用以呈現Dialog操作之範例程式。
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSampleController : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager = null; //彈跳視窗管理員

    /// <summary>
    /// 警告視窗(兩按鍵)。
    /// </summary>
    public void AlertDialogTwoBtn()
    {
        string msg = "警告\n將開啟另一個彈跳視窗。";
        DialogOption option = new DialogOption(DialogOption.Type.OK_OR_CANCEL_DIALOG, msg);
        option.afterConfirm = AlertDialog;
        dialogManager.Create(option);
    }

    /// <summary>
    /// 警告視窗(一般提示用)。
    /// </summary>
    private void AlertDialog()
    {
        dialogManager.Create("我是一個提示視窗。");
    }
    
}
