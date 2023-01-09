/*
 * 提醒視窗作為使用者動作確認或提示，最多為兩種選擇，通常為確認即取消，適合運用在系統提示、警告等。
 */
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AlertDialog : Dialog
{
    [Header("Settings")]
    //預設設置
    [SerializeField] Text messageText = null;
    [SerializeField] GameObject confirmBtn = null;//確認鍵
    [SerializeField] GameObject cancelBtn = null;//取消鍵

    //客制設置(可自訂義按鍵)
    [SerializeField] GameObject buttonPrefab = null;
    [SerializeField] Transform buttonZone = null;//放置按鍵位置

    /// <summary>
    /// 彈跳視窗初始化，使用進階設定。
    /// </summary>
    public override void Init(DialogOption option)
    {
        this.option = option;
        SpecificInit();
    }

    /// <summary>
    /// 彈跳視窗初始化。
    /// </summary>
    public void Init(string message)
    {
        DialogOption option = new DialogOption();
        option.message = message;
        SpecificInit();
    }

    /// <summary>
    /// 初始化。設定確認後動作。
    /// </summary>
    public void Init(string message, UIOption.UICallback onOk)
    {
        Init(message, onOk, null);
    }


    /// <summary>
    /// 初始化。設定關閉前動作，及確認後動作。
    /// </summary>
    public void Init(string message, UIOption.UICallback onOk, UIOption.UICallback onCancel)
    {
        option.message = message;
        option.SetOkCallback(onOk);
        option.SetCancelCallback(onCancel);
        SpecificInit();
    }

    /// <summary>
    /// 根據類型視窗進行初始化。
    /// </summary>
    protected override void SpecificInit()
    {
        //文字內容設置
        messageText.text = option.message;
        Debug.Log(option.type);
        //按鍵配置
        if (option.type == DialogOption.Type.ALERT_DIALOG)
        {
            confirmBtn.SetActive(true);
            cancelBtn.SetActive(false);
        }
        else if (option.type == DialogOption.Type.OK_OR_CANCEL_DIALOG)
        {
            confirmBtn.SetActive(true);
            cancelBtn.SetActive(true);
        }
        else//按鍵配置Custom
        {
            //有按鍵配置
            if (option.btnSettings != null)
            {
                //清除按鍵
                foreach (Transform b in buttonZone)
                {
                    Destroy(b.gameObject);
                }

                int btnAmount = option.btnSettings.Count;
                if (btnAmount > 2 || btnAmount == 0)
                {
                    Debug.LogError("按鍵數量錯誤: " + btnAmount);
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
                            btn.GetComponent<Button>().onClick.AddListener(() => { callback.Invoke(UIResult.Memo("")); Delete(); });
                            Delete();
                        }
                        else
                        {
                            btn.GetComponent<Button>().onClick.AddListener(Delete);
                        }
                    }
                }
            }
            else
            {
                DefaultBtnSettings();
            }
        }

    }

    

    /// <summary>
    /// 確認。
    /// </summary>
    public void Confirm()
    {
        option.onOk?.Invoke(UIResult.Ok());
        Destroy(gameObject);
    }

    /// <summary>
    /// 關閉視窗。
    /// </summary>
    public override void Delete()
    {
        option.onCancel?.Invoke(UIResult.Failed());
        Destroy(gameObject);
    }

    protected override void DefaultBtnSettings()
    {
        //預設為單一確認鍵
        //按鍵配置
        confirmBtn.SetActive(true);
    }

    protected override void ResetDialog()
    {
        messageText.text = "";
        option.SetOkCallback(null);
        option.SetCancelCallback(null);
        //清除按鍵
        foreach (Transform b in buttonZone)
        {
            Destroy(b.gameObject);
        }
    }
}
