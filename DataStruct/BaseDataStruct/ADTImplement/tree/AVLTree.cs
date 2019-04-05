using System;
namespace csharpDemo.ADTImplement
{
    public class AVLTree
    {
        AVLNode root = null;
        public AVLTree(){
            
        }
        public AVLNode Insert(int value){
            root = Insert(value,root);
            return root;
        }
        /// <summary>
        /// 递归插入
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public AVLNode Insert(int value,AVLNode tree){
            //找到插入位置了
            if(tree == null){
                tree = new AVLNode();
                tree.Height = 0;
                tree.Value = value;
            }//没找到
            else{
                //往左子树插入
                if(tree.Value > value){
                    tree.Left = Insert(value,tree.Left);
                    //本来是平衡的，插入后变化的只可能是左子树，只判断左子树-右子树即可
                    if(GetHeight(tree.Left)-GetHeight(tree.Right) == 2 ){
                        //情形1 往左儿子的左子树插入
                        if(tree.Left.Value > value){
                            tree = SingleRotateRight(tree);
                        }else{//情形2 左儿子的右子树
                            tree = DoubleRotateLeft(tree);
                        }
                    }
                }
                else if(tree.Value < value){
                    //往右儿子插入
                    tree.Right = Insert(value,tree.Right);

                    if(GetHeight(tree.Right) - GetHeight(tree.Left) == 2){
                        //情形4 右儿子的右子树
                        if(tree.Right.Value < value){
                            tree = SingleRotateLeft(tree);
                        }
                        else{
                            //情形3
                            tree = DoubleRotateRight(tree);
                        }
                    }
                }
            }
            //计算高度
            //如果均为空返回-1 高度是0
            tree.Height = CalcHeight(tree);
            return tree;
        }
        /// <summary>
        /// 向左转（逆时针），情形4，右儿子的右子树插入节点
        /// </summary>
        /// <param name="node">旋转中心的父节点</param>
        /// <returns>旋转中心</returns>
        AVLNode SingleRotateLeft(AVLNode node){
            //旋转中心是父节点的右节点
            var center = node.Right;

            //父节点的右节点 设为中心的左节点
            node.Right = center.Left;
            //父节点成为中心的左节点
            center.Left = node;

            //需要重新计算高度 先算子树后算根
            node.Height = CalcHeight(node);
            center.Height = CalcHeight(center);
            //中心节点成为根
            return center;
        }
        /// <summary>
        /// 向右转（顺时针），情形1，左儿子的左子树插入节点
        /// </summary>
        /// <param name="node">旋转中心的父节点</param>
        /// <returns>旋转中心</returns>
        AVLNode SingleRotateRight(AVLNode node){
            //旋转中心是父节点的左节点
            var center = node.Left;

            //父节点的左节点设为中心的右节点
            node.Left = center.Right;

            //父节点成为中心的右节点
            center.Right = node;

            //需要重新计算高度 先算子树后算根
            node.Height = CalcHeight(node);
            center.Height = CalcHeight(center);
            //旋转中心成为根
            return center;
        }
        /// <summary>
        /// 左右双旋转,情形2 左儿子的右子树插入
        /// </summary>
        /// <param name="node">不平衡的点</param>
        /// <returns>平衡后的点</returns>
        AVLNode DoubleRotateLeft(AVLNode node){
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
        AVLNode DoubleRotateRight(AVLNode node){
            //先右旋转
            node.Right = SingleRotateRight(node.Right);

            //左转
            node = SingleRotateLeft(node);
            return node;
        }

        int GetHeight(AVLNode tree){
            if(tree == null){
                return -1;
            }
            else{
                return tree.Height;
            }
        }
        int CalcHeight(AVLNode tree){
           return GetMaxHeight(tree.Left, tree.Right) + 1;
        }
        int GetMaxHeight(AVLNode left, AVLNode right){
            return Math.Max(GetHeight(left), GetHeight(right));
        }

    }
}
