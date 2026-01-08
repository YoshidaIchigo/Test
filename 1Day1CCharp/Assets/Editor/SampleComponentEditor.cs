using UnityEngine;
using UnityEditor;

// UnityEditor.Editorを継承する
// CustomEditor属性を使用してSampleComponentの拡張であることを指定する
[CustomEditor(typeof(SampleComponent))]
public class SampleComponentEditor : Editor
{
    // OnInspectorGUIをオーバーライドする
    public override void OnInspectorGUI()
    {
        // こちらを呼び出すことで、SampleComponentのプロパティを表示できます
        // base.OnInspectorGUI();

        // プロパティを最新の状態にする
        serializedObject.Update();

        // serializedObjectからSampleComponentのプロパティを取得
        SerializedProperty valueProperty = serializedObject.FindProperty("_value");
        SerializedProperty textProperty = serializedObject.FindProperty("_text");
        SerializedProperty tuikaProperty = serializedObject.FindProperty("_tuika");

        // ラベル表示と共にSampleComponent._valueのプロパティを表示
        EditorGUILayout.LabelField("数値を入力してください");
        EditorGUILayout.PropertyField(valueProperty);

        // スペースを空ける
        GUILayout.Space(EditorGUIUtility.singleLineHeight);

        // ラベル表示と共にSampleComponent._textのプロパティを表示
        EditorGUILayout.LabelField("テキストを入力してください");
        EditorGUILayout.PropertyField(textProperty);

        GUILayout.Space(EditorGUIUtility.singleLineHeight);

        EditorGUILayout.LabelField("追加してみたよ");
        EditorGUILayout.PropertyField(tuikaProperty);

        // プロパティへの変更があった場合、それを反映する
        serializedObject.ApplyModifiedProperties();
    }
}