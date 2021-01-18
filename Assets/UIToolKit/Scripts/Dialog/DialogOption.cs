/*
 * 彈跳視窗進階設定選項。
 */
using System.Collections.Generic;
using UnityEngine.Events;

public class DialogOption : Option
{
    public enum Type { ALERT_DIALOG, CHOICE_DIALOG, INFO_DIALOG};
    private Type type;

    /// <summary>
    /// 視窗內容。
    /// </summary>
    public string message { get; private set;}//欲呈現的內容

    /// <summary>
    /// 按鍵設定。
    /// </summary>
    public List<ButtonOption> btnSettings { get; private set; }//客制按鍵設定

    /// <summary>
    /// 取消視窗後之動作。
    /// </summary>
    public UnityAction afterCancel = null;

    public DialogOption(List<ButtonOption> buttons)
    {
        btnSettings = buttons;
    }
}