// OptimalBinarySearchTree.cs
using System;
using System.Text;

namespace TreesPractice
{
    public class OptimalBinarySearchTree : BinarySearchTree
    {
        public override string ToString()
        {
            if (Root == null)
            {
                return "(пустое дерево)";
            }
            return GetTreeString(Root);
        }

        private string GetTreeString(TreeNode? node, string indent = "", bool isLeft = false, bool hasSibling = false)
        {
            if (node == null)
            {
                return "";
            }

            var sb = new StringBuilder();
            sb.Append(indent);
            sb.Append(isLeft ? "├── " : "└── ");
            sb.Append($"{node.Data}({node.Weight})");
            sb.AppendLine();

            string childIndent = indent + (hasSibling ? "│   " : "    ");
            sb.Append(GetTreeString(node.Left, childIndent, true, node.Right != null));
            sb.Append(GetTreeString(node.Right, childIndent, false, false));

            return sb.ToString();
        }

        public override void Add(int data, int? weight = null)
        {
            Root = InsertWithPriority(Root, data, weight);
        }

        protected override TreeNode? Insert(TreeNode? node, int data, int? weight)
        {
            throw new NotImplementedException();
        }

        protected TreeNode? InsertWithPriority(TreeNode? node, int data, int? weight)
        {
            if (node == null)
            {
                return new TreeNode(data, weight);
            }

            if (data < node.Data)
            {
                node.Left = InsertWithPriority(node.Left, data, weight);
                if (node.Left != null && (node.Weight == null || node.Left.Weight > node.Weight))
                {
                    node = RotateRight(node);
                }
            }
            else if (data > node.Data)
            {
                node.Right = InsertWithPriority(node.Right, data, weight);
                if (node.Right != null && (node.Weight == null || node.Right.Weight > node.Weight))
                {
                    node = RotateLeft(node);
                }
            }

            return node;
        }

        private TreeNode? RotateRight(TreeNode? y)
        {
            if (y?.Left == null) return y;
            TreeNode? x = y.Left;
            TreeNode? T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            return x;
        }

        private TreeNode? RotateLeft(TreeNode? x)
        {
            if (x?.Right == null) return x;
            TreeNode? y = x.Right;
            TreeNode? T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            return y;
        }

        public double CalculateWeightedHeight()
        {
            if (Root == null) return 0;
            return CalculateWeightedHeightRecursive(Root, 0);
        }

        private double CalculateWeightedHeightRecursive(TreeNode? node, int depth)
        {
            if (node == null) return 0;
            return (depth + 1) * (node.Weight ?? 1) +
                   CalculateWeightedHeightRecursive(node.Left, depth + 1) +
                   CalculateWeightedHeightRecursive(node.Right, depth + 1);
        }

        private int GetTotalWeight(TreeNode? node)
        {
            if (node == null) return 0;
            return (node.Weight ?? 1) + GetTotalWeight(node.Left) + GetTotalWeight(node.Right);
        }
    }
}