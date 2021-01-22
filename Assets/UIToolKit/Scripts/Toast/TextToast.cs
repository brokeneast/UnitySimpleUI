/*
 * 文字吐司提示。
 */
using UnityEngine;
using UnityEngine.UI;

public class TextToast : Toast
{
    [SerializeField] protected Text messageText = null;

    protected override void SpecificInit()
    {
        messageText.text = option.message;//設置內容
    }
}
