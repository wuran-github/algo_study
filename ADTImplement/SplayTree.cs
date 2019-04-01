using System;

namespace csharpDemo.ADTImplement
{
    public class SplayTree
    {
        SplayNode root;
        public SplayTree()
        {
            root = null;
        }
        public void Insert(int value)
        {
            root = Insert(value, root);
        }

        private SplayNode Insert(int value, SplayNode tree){
            if(tree == null){
                tree = new SplayNode();
                tree.Value = value;
            }
            else{
                if(value > tree.Value){
                    tree.Right = Insert(value,tree.Right);
                    tree.Right.Parent = tree;
                }
                else if(value < tree.Value){
                    tree.Left = Insert(value, tree.Left);
                    tree.Left.Parent = tree;
                }
            }
            return tree;
        }

        public void Find(int value)
        {
            root = Find(value, root);
        }
        SplayNode Find(int value, SplayNode tree)
        {
            //加上父节点后
            if (tree == null)
            {
                return null;
            }
            if (value > tree.Value)//往下遍历不改变节点
            {
                tree = Find(value, tree.Right);
            }
            else if (value < tree.Value)//往下遍历不改变节点
            {
                tree = Find(value, tree.Left);
            }
            else
            {
                //找到了节点
                var parent = tree.Parent;
                if (parent != null)
                {
                    var grandFather = parent.Parent;
                    if (grandFather == null)
                    {//父节点就是根
                        if (tree.Equals(parent.Left))
                        {//左
                            tree = SingleRotateRight(parent);
                        }
                        else if (tree.Equals(parent.Right))
                        {//右
                            tree = SingleRotateLeft(parent);
                        }
                    }
                    else
                    {
                        if (parent.Equals(grandFather.Left))//左
                        {
                            if (tree.Equals(parent.Left))
                            {//左 一字形

                                tree = TranslateLeftToRight(grandFather);
                            }
                            else if (tree.Equals(parent.Right))
                            {//右 z
                                tree = DoubleRotateLeft(grandFather);
                            }
                        }
                        else
                        {//右
                            if (tree.Equals(parent.Left))
                            {//左 z字形

                                tree = DoubleRotateRight(grandFather);
                            }
                            else if (tree.Equals(parent.Right))
                            {//右 一字形
                                tree = TranslateRightToLeft(grandFather);
                            }
                        }
                    }
                //往上遍历 改变节点
                tree = Find(value, tree);
                }
                else
                {//tree就是根节点

                }
            }
            
            return tree;
        }
        /// <summary>
        /// 向左转（逆时针），情形4，右儿子的右子树插入节点
        /// </summary>
        /// <param name="node">旋转中心的父节点</param>
        /// <returns>旋转中心</returns>
        SplayNode SingleRotateLeft(SplayNode node)
        {
            //存储node.parent的信息
            var parent = node.Parent;
            //旋转中心是父节点的右节点
            var center = node.Right;

            //父节点的右节点 设为中心的左节点
            node.Right = center.Left;
            // if (node.Right != null)
            // {
            //     node.Right.Parent = node;
            // }

            //父节点成为中心的左节点
            center.Left = node;

            center.Parent = parent;

            //中心节点成为根
            return center;
        }
        /// <summary>
        /// 向右转（顺时针），情形1，左儿子的左子树插入节点
        /// </summary>
        /// <param name="node">旋转中心的父节点</param>
        /// <returns>旋转中心</returns>
        SplayNode SingleRotateRight(SplayNode node)
        {
            //存储node.parent的信息
            var parent = node.Parent;

            //旋转中心是父节点的左节点
            var center = node.Left;

            //父节点的左节点设为中心的右节点
            node.Left = center.Right;

            
            // if (node.Left != null)
            // {
            //     node.Left.Parent = node;
            // }

            //父节点成为中心的右节点
            center.Right = node;

            // center.Parent = node.Parent;
            // node.Parent = center;

            center.Parent = parent;
            //旋转中心成为根
            return center;
        }
        /// <summary>
        /// 左右双旋转,情形2 左儿子的右子树插入
        /// </summary>
        /// <param name="node">不平衡的点</param>
        /// <returns>平衡后的点</returns>
        SplayNode DoubleRotateLeft(SplayNode node)
        {
            //先左旋转，旋转中心是左儿子的右儿子
            node.Left = SingleRotateLeft(node.Left);

            //然后右旋转
            node = SingleRotateRight(node);

            return node;
        }
        /// <summary>
        /// 右左旋转 情形3 右儿子的左子树插入
        /// </summary>
        /// <param name="node">不平衡的点</param>
        /// <returns>平衡后的店</returns>
        SplayNode DoubleRotateRight(SplayNode node)
        {
            //先右旋转
            node.Right = SingleRotateRight(node.Right);

            //左转
            node = SingleRotateLeft(node);
            return node;
        }

        SplayNode TranslateRightToLeft(SplayNode node)
        {
            //只需要存储g的parent的信息
            var top = node.Parent;
            var g = node;
            var p = g.Right;
            var x = p.Right;
            var temp = x.Left;
            x.Left = p;
            p.Right = temp;
            temp = p.Left;
            p.Left = g;
            g.Right = temp;
            
            //自动设置了父节点，只需要设置x的父节点
            x.Parent = top;

            // //父节点交换
            // x.Parent = g.Parent;
            // g.Parent = p;
            // p.Parent = x;
            return x;
        }
        SplayNode TranslateLeftToRight(SplayNode node)
        {
            //只需要存储g的parent的信息
            var top = node.Parent;

            var g = node;
            var p = g.Left;
            var x = p.Left;
            var temp = x.Right;
            x.Right = p;
            p.Left = temp;
            temp = p.Right;
            p.Right = g;
            g.Left = temp;

            //自动设置了父节点，只需要设置x的父节点
            x.Parent = top;

            // //父节点交换
            // //自动实现了parent设置的时候设置parent的left和right了
            // x.Parent = g.Parent;
            // g.Parent = p;
            // p.Parent = x;
            return x;
        }

    }
}