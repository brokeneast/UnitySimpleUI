/*
 * 提醒視窗版型。
 */
public class AlertDialogTemplate : UITemplate
{
    /// <summary>
    /// 提醒視窗按鍵類型。確認型(單一按鍵)，是否型(雙按鍵，包含確定及取消)，客制(將依照父類別之btnSettings為主)
    /// </summary>
    public enum BtnType {CONFIRM, CONFIRM_OR_CANCEL, CUSTOM};
    public BtnType btnType;

    public AlertDialogTemplate()
    {
        btnType = BtnType.CONFIRM;
    }
}
