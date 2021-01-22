/*
 * 彈跳視窗進階設定選項。
 */
using System.Collections.Generic;
using UnityEngine.Events;

public class DialogOption : Option
{
    public enum Type { ALERT_DIALOG, CHOICE_DIALOG, INFO_DIALOG};
    public Type type { get; private set; }

    /// <summary>
    /// 視窗內容。
    /// </summary>
    public string message;//欲呈現的內容

    /// <summary>
    /// 按鍵設定。
    /// </summary>
    public List<ButtonOption> btnSettings { get; private set; }//客制按鍵設定

    /// <summary>
    /// 點擊確認後之動作。
    /// </summary>
    public UnityAction afterConfirm = null;
    /// <summary>
    /// 取消視窗後之動作。
    /// </summary>
    public UnityAction afterCancel = null;

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

    /// <summary>
    /// 根據按鍵做細部設定。
    /// </summary>
    public DialogOption(Type type, List<ButtonOption> buttons)
    {
        this.type = type;
        btnSettings = buttons;
    }
}