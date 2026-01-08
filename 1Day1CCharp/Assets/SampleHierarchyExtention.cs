using UnityEngine;
using UnityEditor;

public class SampleHierarchyExtention
{
    [InitializeOnLoadMethod]
    private static void Initialize()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }

    private static void HierarchyWindowItemOnGUI(int instanceId, Rect selectionRect)
    {
        // instanceIdからゲームオブジェクトを取得します
        GameObject gameObject = EditorUtility.InstanceIDToObject(instanceId) as GameObject;
        if (gameObject == null)
        {
            return;
        }

        // SampleComponentを持っているかの確認
        bool hasComponent = gameObject.GetComponent<SampleComponent>() != null;
        if (!hasComponent)
        {
            return;
        }

        // 「●」のサイズを設定
        Vector2 labelSize = new Vector2(12f, selectionRect.size.y);

        // 「●」を表示するための矩形情報を設定
        Rect labelRect = selectionRect;
        labelRect.x = labelRect.xMax - labelSize.x;
        labelRect.size = labelSize;

        // 「●」を表示
        EditorGUI.LabelField(labelRect, "●");
    }
}