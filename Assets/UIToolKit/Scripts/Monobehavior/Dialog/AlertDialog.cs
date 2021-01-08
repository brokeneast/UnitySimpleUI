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

    protected string message = "";
    protected UnityAction afterConfirm = null;//確認後之動作
    protected UnityAction afterCancel = null;//取消後之動作

    /// <summary>
    /// 彈跳視窗初始化。
    /// </summary>
    public void Init(string message)
    {
        this.message = message;
        SpecificInit();
    }

    /// <summary>
    /// 初始化。設定確認後動作。
    /// </summary>
    public void Init(string message, UnityAction afterConfirm)
    {
        this.message = message;
        this.afterConfirm = afterConfirm;
        SpecificInit();
    }

    /// <summary>
    /// 初始化。設定關閉前動作，及確認後動作。
    /// </summary>
    public void Init(string message, UnityAction afterConfirm, UnityAction afterCancel)
    {
        this.message = message;
        this.afterConfirm = afterConfirm;
        this.afterCancel = afterCancel;
        SpecificInit();
    }

    /// <summary>
    /// 根據類型視窗進行初始化。
    /// </summary>
    protected override void SpecificInit()
    {
        if (dialogOption == null)//看是不是有特別設置
        {
            messageText.text = message;

            confirmBtn.SetActive(true);//不管如何確認鍵都是必要的存在

            if (afterCancel != null)
            {
                cancelBtn.SetActive(true);
            }
            else
            {
                cancelBtn.SetActive(false);
            }
        }
        else
        {
            ResetDialog();//清空顯示設置

            messageText.text = dialogOption.message;
            afterCancel = dialogOption.afterCancel;

            int btnAmount = dialogOption.btnSettings.Count;
            if (btnAmount > 2 || btnAmount == 0)
            {
                Debug.LogError("按鍵數量錯誤: " + btnAmount);
            }
            else
            {
                //依序設置按鍵
                for(int i=0;i< btnAmount; i++)
                {
                    GameObject btn = Instantiate(buttonPrefab);
                    btn.transform.SetParent(buttonZone.transform, false);
                    //顏色
                    btn.GetComponent<Image>().color = dialogOption.btnSettings[i].color;
                    //內容
                    btn.GetComponentInChildren<Text>().text = dialogOption.btnSettings[i].text;
                    //動作
                    btn.GetComponent<Button>().onClick.AddListener(dialogOption.btnSettings[i].afterClick);
                }
            }
        }
    }


    /// <summary>
    /// 確認。
    /// </summary>
    public void Confirm()
    {
        afterConfirm?.Invoke();
        Destroy(gameObject);
    }

    /// <summary>
    /// 關閉視窗。
    /// </summary>
    public override void Cancel()
    {
        afterCancel?.Invoke();
        Destroy(gameObject);
    }

    protected override void ResetDialog()
    {
        messageText.text = "";
        afterConfirm = null;
        afterCancel = null;
        //清除按鍵
        foreach (Transform b in buttonZone)
        {
            Destroy(b.gameObject);
        }
    }
}
