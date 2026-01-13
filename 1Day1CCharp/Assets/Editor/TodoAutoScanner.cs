using UnityEditor;
using UnityEditor.Compilation;

namespace TodoManager
{
    [InitializeOnLoad]
    public static class TodoAutoScanner
    {
        static TodoAutoScanner()
        {
            CompilationPipeline.compilationFinished += OnCompilationFinished;
        }

        static void OnCompilationFinished(object _)
        {
            // äJÇ¢ÇƒÇÈèÍçáÇÃÇ›çXêV
            var window = EditorWindow.GetWindow<TodoManagerWindow>(false);
            if (window != null)
            {
                window.Repaint();
            }
        }
    }
}
