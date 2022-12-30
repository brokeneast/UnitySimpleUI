using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Tab))]
public class TabEditor : Editor
{
    Tab tab;

    void OnEnable()
    {
        //連結至欲控制之類
        tab = (Tab)target;
    }

    public override void OnInspectorGUI()
    {
        //刷新
        serializedObject.Update();

        if (GUILayout.Button("Delete this Tab"))
        {
            //本體MonoBehavior class方法
            tab.Cancel();
        }

        base.OnInspectorGUI();

        //資料更動進行寫入
        serializedObject.ApplyModifiedProperties();
    }
}
