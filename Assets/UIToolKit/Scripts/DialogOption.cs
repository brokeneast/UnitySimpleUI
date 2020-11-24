/*
 * 彈跳視窗進階設定選項。
 */
using System.Collections.Generic;
using UnityEngine;

public class DialogOption
{
    public string message { get; private set;}//欲呈現的內容
    public List<ButtonOption> btnSettings { get; private set; }//按鍵設定

    public DialogOption(List<ButtonOption> buttons)
    {
        btnSettings = buttons;
    }
}