using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.IO;

public class EasySceneSelectWindow : EditorWindow
{
    [MenuItem("CustomWindow/SceneSelector")]
    public static void ShowMyEditor()
    {
        EditorWindow.GetWindow(typeof(EasySceneSelectWindow));
    }
    private void OnGUI()
    {
        EditorGUILayout.LabelField("àÍêÊÇ∏ç≈í·å¿");
    }
}