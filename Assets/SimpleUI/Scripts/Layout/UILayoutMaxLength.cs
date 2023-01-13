/*
 * 版面最大長度，適用於在一定範圍內可至適應，但在超過一定長度後則保持版面。
 * 選擇依據的邊(寬、高須擇一)後，
 * 定義之版面最大長度之下，將會自適應。
 * 
 * 注意: RectTransform不可為Stretch(其中一項 anchorMin為0且anchorMax為1，為Stretch)。
 */
using UnityEngine;

public class UILayoutMaxLength : UILayoutBase
{
    /// <summary>
    /// 版面希望的最大長度(在此長度下圍自適應，之上則保持該數值)。
    /// </summary>
    [Tooltip("版面希望的最大長度(在此長度下為自適應，之上則保持該數值)。")]
    [SerializeField] int maxLength = 720;

    /// <summary>
    /// 內縮，當小於最大長度(單側，實際為總長扣除該內縮乘2)。
    /// </summary>
    [Tooltip("內縮，當小於最大長度。")]
    [SerializeField] int marginIfUnderMaxLength = 0;

    protected override void Start()
    {
        base.Start();
    
    }

    private void LateUpdate()
    {
        if (!CheckIsNotStrecth())
        {
            return;
        }


        //大於長度設定，則設定為最大限制。
        if (mode == Mode.WIDTH)
        {
            if (refRT.rect.width > maxLength)
            {
                rectTransform.sizeDelta = new Vector2(maxLength, initRtRect.y);

            }
            else
            {
                rectTransform.sizeDelta = new Vector2(refRT.rect.width - marginIfUnderMaxLength * 2, initRtRect.y);
            }
        }
        else if (mode == Mode.HEIGHT)
        {
            if (refRT.rect.height > maxLength)
            {
                rectTransform.sizeDelta = new Vector2(initRtRect.x, maxLength);
            }
            else
            {
                rectTransform.sizeDelta = new Vector2(initRtRect.x, refRT.rect.height - marginIfUnderMaxLength * 2);
            }
        }


    }
}
