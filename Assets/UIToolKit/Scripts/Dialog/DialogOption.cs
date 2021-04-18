/*
 * 彈跳視窗進階設定選項。
 */
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class DialogOption : UIOption
{
    public enum Type { ALERT_DIALOG, OK_OR_CANCEL_DIALOG, CHOICE_DIALOG, INFO_DIALOG};
    public Type type;

    /// <summary>
    /// 視窗內容。
    /// </summary>
    public string message;//欲呈現的內容

    /// <summary>
    /// 按鍵設定。此將清空原本Type所定義的按鍵。
    /// </summary>
    public List<ButtonOption> btnSettings { get; private set; }//客制按鍵設定

    /// <summary>
    /// 點擊確認後之動作。
    /// </summary>
    public UICallbackWithData onOk { get; protected set; }

    /// <summary>
    /// 取消或關閉視窗後之動作。
    /// </summary>
    public UICallbackWithData onCancel { get; protected set; }

    public DialogOption()
    {
        type = Type.ALERT_DIALOG;
    }

    /// <summary>
    /// 一般提醒視窗。
    /// </summary>
    /// <param name="msg"></param>
    public DialogOption(string msg)
    {
        type = Type.ALERT_DIALOG;
        message = msg;
    }

    public DialogOption(Type type)
    {
        this.type = type;
    }

    public DialogOption(Type type, string msg)
    {
        this.type = type;
        message = msg;
    }

    /// <summary>
    /// 根據按鍵做細部設定，設定buttons將清空原本Type所定義的按鍵。
    /// </summary>
    public DialogOption(Type type, string msg, List<ButtonOption> buttons)
    {
        this.type = type;
        message = msg;
        btnSettings = buttons;
    }

    /// <summary>
    /// 點擊確認後之委派動作。
    /// </summary>
    public void SetOkCallback(UICallbackWithData callback)
    {
        onOk = callback;
    }


    /// <summary>
    /// 點擊取消後之委派動作。
    /// </summary>
    public void SetCancelCallback(UICallbackWithData callback)
    {
        onOk = callback;
    }

}
