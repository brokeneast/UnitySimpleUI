/*
 * 選擇視窗為多選一(最多為4，至少為1)，可客制化按鍵內容及操作。
 */
using UnityEngine;
using UnityEngine.UI;

public class ChoiceDialog : Dialog
{
    [Header("Settings")]
    [SerializeField] Text messageText = null;
    [SerializeField] GameObject buttonPrefab = null;//預設選擇按鍵
    [SerializeField] Transform buttonZone = null;//放置按鍵位置

    private const int maxAmount = 4;
    private const int minAmount = 1;

    protected override void SpecificInit()
    {
        if (option != null)//有設置
        {

            messageText.text = option.message;

            //按鍵設置
            if(option.btnSettings != null)
            {
                //清空按鍵
                foreach (Transform b in buttonZone)
                {
                    Destroy(b.gameObject);
                }

                int btnAmount = option.btnSettings.Count;
                if (btnAmount < minAmount && btnAmount > maxAmount)
                {
                    Debug.LogErrorFormat("按鍵數量錯誤，需於{0}~{1}之間", minAmount, maxAmount);
                }
                else
                {
                    //依序設置按鍵
                    for (int i = 0; i < btnAmount; i++)
                    {
                        GameObject btn = Instantiate(buttonPrefab);
                        btn.transform.SetParent(buttonZone.transform, false);
                        //顏色
                        btn.GetComponent<Image>().color = option.btnSettings[i].color;
                        //內容
                        btn.GetComponentInChildren<Text>().text = option.btnSettings[i].text;
                        //動作
                        if (option.btnSettings[i].onClick != null)
                        {
                            UIOption.UICallback callback = option.btnSettings[i].onClick;
                            btn.GetComponent<Button>().onClick.AddListener(()=> { callback.Invoke(UIResult.Memo("")); });
                        }
                        else
                        {
                            btn.GetComponent<Button>().onClick.AddListener(Cancel);
                        }
                    }
                }
            }
            else //無按鍵設置
            {
                DefaultBtnSettings();
            }
            
        }
        else
        {
            Debug.LogErrorFormat("需進行視窗設置。");//需要DialogOption
        }
    }

    protected override void DefaultBtnSettings()
    {
        
    }


    /// <summary>
    /// 確認。此處預設為選項1。
    /// </summary>
    public void Confirm()
    {
        option.onOk?.Invoke(UIResult.Ok());
        Destroy(gameObject);
    }

    /// <summary>
    /// 關閉視窗。此處預設為選項2。
    /// </summary>
    public override void Cancel()
    {
        option.onCancel?.Invoke(UIResult.Failed());
        Destroy(gameObject);
    }

    protected override void ResetDialog()
    {
        messageText.text = "";
        //清除按鍵
        foreach (Transform b in buttonZone)
        {
            Destroy(b.gameObject);
        }
    }
}
