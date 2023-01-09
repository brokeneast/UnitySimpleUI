/*
 * 版面最大長度，適用於在一定範圍內可至適應，但在超過一定長度後則保持版面。
 * 選擇依據的邊(寬、高須擇一)後，
 * 定義之版面最大長度之下，將會自適應。
 * 
 * 注意: RectTransform不可為Stretch(其中一項 anchorMin為0且anchorMax為1，為Stretch)。
 */
using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
public class UILayoutMaxLength : MonoBehaviour
{
    RectTransform rectTransform;
    Vector2 initRtRect;

    public enum Mode { WIDTH, HEIGHT };
    /// <summary>
    /// 依據的邊。
    /// </summary>
    public Mode mode;

    /// <summary>
    /// 版面希望的最大長度(在此長度下圍自適應，之上則保持該數值)。
    /// </summary>
    [Tooltip("版面希望的最大長度(在此長度下為自適應，之上則保持該數值)。")]
    [SerializeField] int maxLength = 720;

    //於最大限制之內
    /// <summary>
    /// 參照版面，用於對照的容器。
    /// </summary>
    [Tooltip("參照版面，用於對照的上層容器。")]
    [SerializeField] RectTransform refRT = null;

    /// <summary>
    /// 內縮，當小於最大長度(單側，實際為總長扣除該內縮乘2)。
    /// </summary>
    [Tooltip("內縮，當小於最大長度。")]
    [SerializeField] int marginIfUnderMaxLength = 0;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initRtRect = rectTransform.rect.size;
        CheckIsNotStrecth();
    }

    private bool CheckIsNotStrecth()
    {
        bool isNotStretch = true;
        //RectTransform不可為Stretch(其中一項 anchorMin為0且anchorMax為1，為Stretch)。
        if ((rectTransform.anchorMin.x == 0 && rectTransform.anchorMax.x == 1) ||
            (rectTransform.anchorMin.y == 0 && rectTransform.anchorMax.y == 1))
        {
            Debug.LogError("RectTransform不可為Stretch(其中一項 anchorMin為0且anchorMax為1，為Stretch)，請選擇為非Stretch排版");
            isNotStretch = false;
        }
        return isNotStretch;
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
