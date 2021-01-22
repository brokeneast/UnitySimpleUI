/*
 * 用來設計介面的選項集。
 */
using UnityEngine;

public abstract class Option
{
    public GameObject parent { get; private set; } //UI生成位置，若有特定指定將使用
    public void SetParent(GameObject p)
    {
        parent = p;
    }
}
