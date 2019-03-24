using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class FileTree
    {
        FileNode root;
        public FileTree()
        {
            root = new FileNode();
            root.IsFile = false;
            root.Value = "root";

        }
        public void ListDir()
        {
            PreorderTraversal(root,0);
        }
        public void ListDirByPost(){
            PostorderTraversal(root,0);
        }
        public void test()
        {
            root.FirstChild = BuildChildNode(0);

        }
        FileNode BuildChildNode(int i)
        {
            if (i == 3)
            {
                return null;
            }
            FileNode node = new FileNode();
            if (i % 2 == 0)
            {
                node.Value = "folder" + i;
                node.IsFile = false;
                node.FirstChild = BuildChildNode(i + 1);
            }
            else
            {
                node.Value = "file" + i;
                node.IsFile = true;
            }
            node.NextSibling = BuidSiblingNode(i);
            return node;
        }
        FileNode BuidSiblingNode(int i)
        {
            if (i == 3)
            {
                return null;
            }
            FileNode node = new FileNode();
            if (i % 2 == 0)
            {
                node.Value = "folder" + i;
                node.IsFile = false;
            }
            else
            {
                node.Value = "file" + i;
                node.IsFile = true;
            }
            node.NextSibling = BuidSiblingNode(i + 1);
            return node;
        }
        /// <summary>
        /// 先序遍历
        /// </summary>
        void PreorderTraversal(FileNode node, int depth)
        {
            if (node == null)
            {
                return;
            }
            for (int i = 0; i < depth; i++)
            {
                System.Console.Write(" ");
            }
            if (node.IsFile)
            {
                System.Console.WriteLine(node.Value);
            }
            else
            {
                System.Console.WriteLine(node.Value);
                PreorderTraversal((FileNode)node.FirstChild, depth + 1);
                PreorderTraversal((FileNode)node.NextSibling, depth);
            }

        }
        void PostorderTraversal(FileNode node,int depth){
            if (node == null)
            {
                return;
            }
            PostorderTraversal((FileNode)node.NextSibling, depth);

            PostorderTraversal((FileNode)node.FirstChild, depth + 1);
            for (int i = 0; i < depth; i++)
            {
                System.Console.Write(" ");
            }
            if (node.IsFile)
            {
                System.Console.WriteLine(node.Value);
            }
            else
            {
                System.Console.WriteLine(node.Value);
            }
        }
    }
}