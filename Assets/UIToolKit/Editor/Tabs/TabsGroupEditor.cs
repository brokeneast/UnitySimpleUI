using System.Collections;
using System.Collections.Generic;
using System.Text;
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

        GUILayout.Space(10);
        GUILayout.Label("Edit", EditorStyles.boldLabel);
        EditorGUILayout.HelpBox
            ("頁籤(Tab)管理，可用於新增或刪除頁籤(Tab)元件\n" +
            "若未按照正常程序加入Tab，可用Refresh重新抓取底下的Tab元件並註冊。", MessageType.Info);

        //新增頁籤
        if (GUILayout.Button("Create New Tab"))
        {
            tabsGroup.CreateTab();
        }
        //重新抓取頁籤
        if (GUILayout.Button("Refresh")) //重新抓取底下的Tab並註冊。
        {
            tabsGroup.Refresh();
        }


        GUILayout.Space(10);

        //目前頁籤狀態及刪除
        GUILayout.Label("Current Tabs", EditorStyles.boldLabel);
        StringBuilder tabsList = new StringBuilder();

        for (int i = 0; i < tabsGroup.tabs.Count; i++)
        {
            GUILayout.BeginHorizontal();
            //標記為目前所選擇
            string isSelecetedMark = tabsGroup.tabs[i].isSelected ? "V" : " ";
            GUILayout.Label(isSelecetedMark, GUILayout.MaxWidth(10));

            //索引及頁籤
            GUILayout.Label(string.Format("{0}: {1}", i, tabsGroup.tabs[i].name));

            //個別刪除
            if (GUILayout.Button("Delete", GUILayout.MaxWidth(100)))
            {
                tabsGroup.DeleteTab(i);
            }
            GUILayout.EndHorizontal();
        }

        //全部Tab刪除
        if (GUILayout.Button("Delete All"))
        {
            tabsGroup.DeleteAll();
        }
        GUILayout.Space(20);

        base.OnInspectorGUI();

        //資料更動進行寫入
        serializedObject.ApplyModifiedProperties();


    }
}
