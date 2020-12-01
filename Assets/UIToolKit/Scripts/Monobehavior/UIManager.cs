using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 遊戲主要方向。
    /// </summary>
    public enum GameOrientation { NONE, LANDSCAPE, PORTRAIT };
    public GameOrientation orientation
    {
        get { return orientation; }
        set
        {
            SetCanvas(value);
        }
    }

    private Canvas canvas;
    private CanvasScaler canvasScaler;

    private const int gameWidth = 1280;
    private const int gameHeight = 720;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        try
        {
            canvas = FindObjectOfType<Canvas>();
        }
        catch
        {
            Debug.LogError("找不到Canvas，請新增Canvas。");
        }

        try
        {
            canvasScaler = canvas.GetComponent<CanvasScaler>();
        }
        catch
        {
            canvasScaler = canvas.gameObject.AddComponent<CanvasScaler>();
        }

    }


    /// <summary>
    /// 設定 UI Canvas。
    /// </summary>
    /// <param name="orientation"></param>
    private void SetCanvas(GameOrientation orientation)
    {
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        if (orientation == GameOrientation.LANDSCAPE)
        {
            canvasScaler.referenceResolution = new Vector2(gameWidth, gameHeight);
            canvasScaler.matchWidthOrHeight = 1;//以高為主
        }
        else if (orientation == GameOrientation.PORTRAIT)
        {
            canvasScaler.referenceResolution = new Vector2(gameHeight, gameWidth);
            canvasScaler.matchWidthOrHeight = 0;//以寬為主
        }
        else
        {
            Debug.LogWarning("未設定遊戲方向，請至UI Manager設定orientation。");
        }
    }
}
