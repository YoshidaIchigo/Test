using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace TodoManager
{
    public class TodoManagerWindow : EditorWindow
    {
        Vector2 scroll;
        List<TodoItem> items = new();

        [MenuItem("Tools/TODO Manager")]
        static void Open()
        {
            GetWindow<TodoManagerWindow>("TODO Manager");
        }

        void OnEnable()
        {
            Refresh();
        }

        void OnGUI()
        {
            DrawToolbar();
            DrawList();
        }

        void DrawToolbar()
        {
            GUILayout.BeginHorizontal(EditorStyles.toolbar);

            if (GUILayout.Button("Scan", EditorStyles.toolbarButton))
            {
                Refresh();
            }

            GUILayout.Label($"Count: {items.Count}", GUILayout.Width(100));

            GUILayout.EndHorizontal();
        }

        void DrawList()
        {
            scroll = GUILayout.BeginScrollView(scroll);

            foreach (var item in items)
            {
                DrawItem(item);
            }

            GUILayout.EndScrollView();
        }

        void DrawItem(TodoItem item)
        {
            GUI.color = GetColor(item.tag);

            GUILayout.BeginHorizontal("box");

            GUILayout.Label(item.tag.ToString(), GUILayout.Width(60));
            GUILayout.Label(item.message, GUILayout.ExpandWidth(true));
            GUILayout.Label(Path.GetFileName(item.filePath), GUILayout.Width(160));
            GUILayout.Label(item.lineNumber.ToString(), GUILayout.Width(40));

            if (GUILayout.Button("Go", GUILayout.Width(40)))
            {
                var asset = AssetDatabase.LoadAssetAtPath<Object>(item.filePath);
                AssetDatabase.OpenAsset(asset, item.lineNumber);
            }

            GUILayout.EndHorizontal();

            GUI.color = Color.white;
        }

        void Refresh()
        {
            items = TodoScanner.Scan();
            Repaint();
        }

        Color GetColor(TodoTag tag)
        {
            return tag switch
            {
                TodoTag.FIXME => Color.red,
                TodoTag.HACK => new Color(1f, 0.5f, 0f),
                TodoTag.NOTE => Color.cyan,
                _ => Color.white
            };
        }
    }
}
