using System;

namespace TodoManager
{
    public enum TodoTag
    {
        TODO,
        FIXME,
        HACK,
        NOTE
    }

    [Serializable]
    public class TodoItem
    {
        public TodoTag tag;
        public string message;
        public string filePath;
        public int lineNumber;
    }
}
