/*
 * 按鍵進階設定選項。
 */
using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonOption : Option
{
    public UnityAction afterClick;//點擊事件
    public string text { get; private set; }//文字內容
    public Color color = Color.white; //按鍵底色

    public ButtonOption(string text, UnityAction afterClick)
    {
        this.afterClick = afterClick;
        this.text = text;
    }

    public ButtonOption(string text, UnityAction afterClick, Color color)
    {
        this.afterClick = afterClick;
        this.text = text;
        this.color = color;
    }
}
