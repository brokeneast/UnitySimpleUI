using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    //方向性
    public enum Orientation {NONE, PORTRAIT, LANDSCAPE};
    public Orientation orientation//該遊戲的方向性
    {
        get
        {
            return _orientation;
        }
        private set
        {
            if(value != _orientation)
            {
                _orientation = value;
                OnOrientationChanged(_orientation);//變換配置後設定
            }
        }
    }

    private Orientation _orientation;//temp
    private static readonly Vector2 portraitReferenceResolution = new Vector2(720, 1280);
    private static readonly Vector2 landscapeReferenceResolution = new Vector2(1280, 720);

    private GameObject canvas;
 

    /// <summary>
    /// 新增UIManager於Hierarchy。
    /// </summary>
    [MenuItem("GameObject/UIToolkit/UI Manager")]
    public static void CreateUIManager()
    {
        GameObject um = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath("Assets/UIToolkit/Prefabs/Manager/UIManager.prefab", typeof(GameObject)));
        um.name = "UIManager";
    }

    void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this;
            try
            {
                DontDestroyOnLoad(this);
            }
            catch
            {
                //Debug.LogWarning("非執行模式");
            }   

        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        try
        {
            canvas = GameObject.Find("Canvas");
        }
        catch
        {
            Debug.LogWarning("場景中無Canvas物件，請新增。");
        }
    }

    private void Update()
    {
        RefreshReferenceResolution();
    }

    /// <summary>
    /// 刷新方向判斷，附與合適的參考比例。
    /// </summary>
    private void RefreshReferenceResolution()
    {
        //判定橫向或直向
        //橫向
        if (Camera.main.aspect > 1)
        {
            orientation = Orientation.LANDSCAPE;
        }
        //縱向
        else
        {
            orientation = Orientation.PORTRAIT;
        }
    }

    /// <summary>
    /// 當方位設定變化時。
    /// </summary>
    private void OnOrientationChanged(Orientation o)
    {
        if (canvas != null)
        {
            CanvasScaler canvasScaler = canvas.GetComponent<CanvasScaler>();

            if (canvasScaler != null)
            {
                if (o == Orientation.LANDSCAPE)
                {
                    canvasScaler.referenceResolution = landscapeReferenceResolution;
                }
                else if (o == Orientation.PORTRAIT)
                {
                    canvasScaler.referenceResolution = portraitReferenceResolution;
                }
            }
            else
            {
                Debug.LogWarning("Canvas物件中無CanvasScaler元件，需新增。");
            }
        }
    }

}
