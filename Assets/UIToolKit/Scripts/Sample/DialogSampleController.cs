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
    /// 生成警告視窗(兩按鍵)。
    /// </summary>
    public void AlertDialogTwoBtn()
    {
        //設置視窗功能
        string msg = "警告\n將開啟另一個彈跳視窗。";
        DialogOption option = new DialogOption(DialogOption.Type.OK_OR_CANCEL_DIALOG, msg);
        option.SetOkCallback(AlertDialog);
        //創建視窗
        dialogManager.Create(option);
    }

    /// <summary>
    /// 生成警告視窗(一般提示用)。
    /// </summary>
    private void AlertDialog(UIResult result)
    {
        //預設為提示警告視窗。
        dialogManager.Create("我是一個提示視窗。");
    }

    /// <summary>
    /// 生成資訊視窗。
    /// </summary>
    public void InfoDialog()
    {
        //設置視窗功能
        string info = "大量資訊或公告。";
        DialogOption option = new DialogOption(DialogOption.Type.INFO_DIALOG, info);//設置視窗功能
        //創建視窗
        dialogManager.Create(option);
    }

    /// <summary>
    /// 生成選擇視窗。
    /// </summary>
    public void ChoiceDialog()
    {
        //設置視窗功能
        //內容設置
        string question = "你喜歡什麼顏色?";
        //按鍵客制設置
        List<ButtonOption> btnOptions = new List<ButtonOption>();

        ButtonOption o1 = new ButtonOption("Red", new Color32(255, 153, 153, 255), ChoiceResultAlertDialog);
        o1.color = new Color32(255,153,153,255);
        btnOptions.Add(o1);

        ButtonOption o2 = new ButtonOption("Blue", new Color32(153, 218, 255, 255), ChoiceResultAlertDialog);

        btnOptions.Add(o2);

        ButtonOption o3 = new ButtonOption("Green", new Color32(153, 255, 194, 255), ChoiceResultAlertDialog);
  
        btnOptions.Add(o3);


        DialogOption option = new DialogOption(DialogOption.Type.CHOICE_DIALOG, question, btnOptions);//設置視窗功能
        //創建視窗
        dialogManager.Create(option);
    }

    private void ChoiceResultAlertDialog(UIResult r)
    {
        //預設為提示警告視窗。
        dialogManager.Create("");
    }
}
