/*
 * 時間內會自動消逝吐司提示。
 */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadingToast : TextToast
{
    [Header("Settings")]
    [SerializeField] Image toastBg = null;
    protected float holdingTime = 2.5f;//提示保留時間，將自動消失並刪除。

    //淡出
    private float alpha = 1;//透明度
    private float fadeOutSpeed = 0.01f;//淡出速度 0.1f~0.5f

    private void Start()
    {
        alpha = toastBg.color.a;
    }

    /// <summary>
    /// 初始化提示介面，設置內容及保留時間。
    /// </summary>
    public void Init(string message, float time)
    {
        holdingTime = time;
        option.message = message;
        Init(option);
    }

    protected override void SpecificInit()
    {
        base.SpecificInit();
        StartCoroutine(HoldAndFadeOut());
    }

    /// <summary>
    /// 介面保留一段時間後淡出。
    /// </summary>
    private IEnumerator HoldAndFadeOut()
    {
        yield return new WaitForSeconds(holdingTime);
        yield return StartCoroutine(Fading());
    }

    private IEnumerator Fading()
    {
        yield return new WaitForSeconds(0.01f);

        if(alpha > 0)
        {
            alpha = alpha - fadeOutSpeed;
            toastBg.color = new Color(toastBg.color.r, toastBg.color.b, toastBg.color.g, alpha);
            messageText.color = new Color(messageText.color.r, messageText.color.b, messageText.color.g, alpha);
            yield return StartCoroutine(Fading());
        }
        else
        {
            alpha = 0;
            StopAllCoroutines();
            Cancel();
        }

    }
}
