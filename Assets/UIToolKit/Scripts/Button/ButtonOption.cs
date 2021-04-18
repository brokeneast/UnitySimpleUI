/*
 * 按鍵進階設定選項。
 */
using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonOption : UIOption
{
    public string text { get; private set; }
    /// <summary>
    /// 按鍵底色。
    /// </summary>
    public Color color = Color.white;

    /// <summary>
    /// 點擊後挾帶資訊。
    /// </summary>
    public UICallbackWithData onClickAndSend { get; protected set; }

    public ButtonOption(string text)
    {
        this.text = text;
    }

    
    public ButtonOption(string text, UICallback callback)
    {
        this.text = text;
        onClick = callback;
    }

    public ButtonOption(string text, Color color, UICallback callback)
    {
        this.text = text;
        this.color = color;
        onClick = callback;
    }

    public ButtonOption(string text, UICallbackWithData callback)
    {
        this.text = text;
        onClickAndSend = callback;
    }

    public ButtonOption(string text, Color color, UICallbackWithData callback)
    {
        this.text = text;
        this.color = color;
        onClickAndSend = callback;
    }
}
