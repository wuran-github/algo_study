using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class FileNode:ITreeNode<string>
    {
        public FileNode()
        {
        }
        public FileNode(string name){
            Value = name;
        }

        public string Value { get ; set ; } = string.Empty;
        public ITreeNode<string> FirstChild { get ; set ; } = null;
        public ITreeNode<string> NextSibling { get ; set ; } = null;
        public bool IsFile { get; set; }
    }
}