/*
 * 讀取圖示，不會遮蔽之下的其他UI。
 */

public class LoadingImage : Loading
{
    protected override void SpecificInit()
    {
        base.SpecificInit();

        if (option.parent != null)
        {
            transform.SetParent(option.parent.transform);
        }
    }
}
