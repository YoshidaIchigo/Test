using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class SampleEditorWindow : EditorWindow
{
    // フィルター
    private string _searchFilter = string.Empty;

    // 検索結果
    private readonly List<string> _searchResult = new List<string>();

    // スクロール位置
    private Vector2 _scrollPosition = Vector2.zero;

    [MenuItem("Tools/SampleWindow")]
    private static void OpenWindow()
    {
        SampleEditorWindow window = GetWindow<SampleEditorWindow>();
        window.Show();
    }

    // GUIを実装します
    private void OnGUI()
    {
        // ボタンの幅の指定
        GUILayoutOption[] buttonOption = new GUILayoutOption[]
        {
            GUILayout.Height(40)
        };

        // 検索用フィルターを入力するフィールドを作成
        _searchFilter = EditorGUILayout.TextField("検索フィルター", _searchFilter);

        // スペース
        GUILayout.Space(EditorGUIUtility.singleLineHeight);

        // 検索用ボタンを配置
        if (GUILayout.Button("検索", buttonOption))
        {
            // アセットの検索を実行
            string[] guids = AssetDatabase.FindAssets(_searchFilter, new[] { "Assets" });

            // 検索結果としてアセットのパスを取得する
            _searchResult.Clear();
            foreach (string guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                if (File.Exists(assetPath))
                {
                    _searchResult.Add(assetPath);
                }
            }
        }

        // スペース
        GUILayout.Space(EditorGUIUtility.singleLineHeight * 2f);

        // ラベル表示
        GUILayout.Label("検索結果");

        // スペース
        GUILayout.Space(EditorGUIUtility.singleLineHeight);

        if (_searchResult.Count != 0)
        {
            // スクロールビューの開始
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

            // 検索結果を表示
            foreach (string resule in _searchResult)
            {
                GUILayout.Label(resule);
            }

            // スクロールビューの終了
            EditorGUILayout.EndScrollView();
        }
    }
}