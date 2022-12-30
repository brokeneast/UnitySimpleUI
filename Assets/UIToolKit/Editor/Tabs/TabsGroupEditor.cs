using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TabsGroup))]
public class TabsGroupEditor : Editor
{
    TabsGroup tabsGroup;

    void OnEnable()
    {
        //連結至欲控制之類
        tabsGroup = (TabsGroup)target;
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUILayout.Label("Current Tabs:");

        string tabsList = "";
        for (int i = 0; i < tabsGroup.tabs.Count; i++)
        {
            tabsList = tabsList + "index"+i.ToString() + ": " + tabsGroup.tabs[i].gameObject.name +"\n";
        }

        GUILayout.TextArea(tabsList);
        GUILayout.Label("Edit");

        if (GUILayout.Button("Create Tab"))
        {
            tabsGroup.CreateTab();
        }

        EditorGUILayout.HelpBox("若未按照正常程序加入Tab，可用Refresh重新抓取底下的Tab元件並註冊。", MessageType.Info);
        if (GUILayout.Button("Refresh")) //重新抓取底下的Tab並註冊。
        {
            tabsGroup.Refresh();
        }

        base.OnInspectorGUI();

        //資料更動進行寫入
        serializedObject.ApplyModifiedProperties();
    }
}
