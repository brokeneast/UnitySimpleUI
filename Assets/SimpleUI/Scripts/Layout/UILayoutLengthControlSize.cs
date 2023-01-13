/*
 * 版面一側之長度去控制整體區域之等比縮放比例。
 * 選擇依據的邊(寬、高須擇一)後，
 * 定義之版面最大長度之下，將會自適應。
 *
 * 例如:
 * Ref寬度:Ref原Scale = 欲調整之Rt寬度:X(欲調整之Scale)
 * X(欲調整之Scale) = (Ref原Scale)*欲調整之Rt寬度)/Ref寬度
 */
using UnityEngine;

public class UILayoutLengthControlSize : UILayoutBase
{
    /// <summary>
    /// 最大Scale限度。
    /// </summary>
    [SerializeField] float maxScaleLimit = 1;

    private void LateUpdate()
    {
        if (!CheckIsNotStrecth())
        {
            return;
        }

        float newScale = 1;
        //大於長度設定，則設定為最大限制。
        if (mode == Mode.WIDTH)
        {
            newScale = (refRT.rect.width * initRtScale.x) / initRtRect.x;
        }
        else if (mode == Mode.HEIGHT)
        {
            newScale = (refRT.rect.height * initRtScale.y) / initRtRect.y;
        }

        newScale = newScale > maxScaleLimit ? maxScaleLimit : newScale;
        rectTransform.transform.localScale = new Vector3(newScale, newScale, newScale);
    }

}
