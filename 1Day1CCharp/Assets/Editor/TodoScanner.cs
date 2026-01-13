using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;

namespace TodoManager
{
    public static class TodoScanner
    {
        static readonly string[] TAGS =
        {
            "TODO",
            "FIXME",
            "HACK",
            "NOTE"
        };

        public static List<TodoItem> Scan()
        {
            var results = new List<TodoItem>();

            string[] guids = AssetDatabase.FindAssets("t:Script");

            foreach (var guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);

                // ”O‚Ì‚½‚ß Editor ŠO‚à’e‚¯‚é
                if (!path.EndsWith(".cs"))
                    continue;

                var lines = File.ReadAllLines(path, Encoding.UTF8);

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];

                    foreach (var tag in TAGS)
                    {
                        if (line.Contains($"// {tag}"))
                        {
                            results.Add(new TodoItem
                            {
                                tag = ParseTag(tag),
                                message = line.Trim(),
                                filePath = path,
                                lineNumber = i + 1
                            });

                            break;
                        }
                    }
                }
            }

            return results;
        }

        static TodoTag ParseTag(string tag)
        {
            return tag switch
            {
                "FIXME" => TodoTag.FIXME,
                "HACK" => TodoTag.HACK,
                "NOTE" => TodoTag.NOTE,
                _ => TodoTag.TODO
            };
        }
    }
}
