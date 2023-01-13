using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
public class UILayoutBase : MonoBehaviour
{
    protected RectTransform rectTransform;
    protected Vector2 initRtRect;
    protected Vector3 initRtScale;
    public enum Mode { WIDTH, HEIGHT };
    /// <summary>
    /// 依據的邊。
    /// </summary>
    public Mode mode;

    /// <summary>
    /// 參照版面，用於對照的容器。
    /// </summary>
    [Tooltip("參照版面，用於對照的上層容器。")]
    [SerializeField] protected RectTransform refRT = null;

    protected virtual void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initRtRect = rectTransform.rect.size;
        initRtScale = rectTransform.transform.localScale;
        CheckIsNotStrecth();
    }


    protected bool CheckIsNotStrecth()
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
}
