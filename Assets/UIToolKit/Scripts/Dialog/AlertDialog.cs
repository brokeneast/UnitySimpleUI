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
    /// 彈跳視窗初始化。
    /// </summary>
    public void Init(string message)
    {
        option.message = message;
        SpecificInit();
    }

    /// <summary>
    /// 初始化。設定確認後動作。
    /// </summary>
    public void Init(string message, UnityAction afterConfirm)
    {
        option.message = message;
        option.afterConfirm = afterConfirm;
        SpecificInit();
    }

    /// <summary>
    /// 初始化。設定關閉前動作，及確認後動作。
    /// </summary>
    public void Init(string message, UnityAction afterConfirm, UnityAction afterCancel)
    {
        option.message = message;
        option.afterConfirm = afterConfirm;
        option.afterCancel = afterCancel;
        SpecificInit();
    }

    /// <summary>
    /// 根據類型視窗進行初始化。
    /// </summary>
    protected override void SpecificInit()
    {
        if (option == null)//看是不是有特別設置
        {
            messageText.text = option.message;

            confirmBtn.SetActive(true);//不管如何確認鍵都是必要的存在

            if (option.afterCancel != null)
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

            messageText.text = option.message;

            int btnAmount = option.btnSettings.Count;
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
                    btn.GetComponent<Image>().color = option.btnSettings[i].color;
                    //內容
                    btn.GetComponentInChildren<Text>().text = option.btnSettings[i].text;
                    //動作
                    btn.GetComponent<Button>().onClick.AddListener(option.btnSettings[i].afterClick);
                }
            }
        }
    }


    /// <summary>
    /// 確認。
    /// </summary>
    public void Confirm()
    {
        option.afterConfirm?.Invoke();
        Destroy(gameObject);
    }

    /// <summary>
    /// 關閉視窗。
    /// </summary>
    public override void Cancel()
    {
        option.afterCancel?.Invoke();
        Destroy(gameObject);
    }

    protected override void ResetDialog()
    {
        messageText.text = "";
        option.afterConfirm = null;
        option.afterCancel = null;
        //清除按鍵
        foreach (Transform b in buttonZone)
        {
            Destroy(b.gameObject);
        }
    }
}
