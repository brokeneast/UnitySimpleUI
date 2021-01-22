using UnityEngine.Events;
public class LoadingOption : Option
{
    public enum Type { LOADING_MASK, LOADING , TRANSPARENT_BLOCK_MASK };
    public Type type { get; private set; }

    public UnityAction afterCancel = null;

    public LoadingOption(Type type)
    {
        this.type = type;
    }
}
