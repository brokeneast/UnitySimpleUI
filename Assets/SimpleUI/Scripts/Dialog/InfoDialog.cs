/*
 * 資訊視窗適合運用於大量文字資訊，其內容將附有滾動條。例如:隱私權聲明視窗等。
 */

using UnityEngine;

public class InfoDialog : AlertDialog
{
    [SerializeField] RectTransform messageContentPanel = null; //文字位置區域

    /// <summary>
    /// 回滾至頂端。
    /// </summary>
    public void ScrollToTheTop()
    {
        messageContentPanel.anchoredPosition = Vector2.up;
    }
}
