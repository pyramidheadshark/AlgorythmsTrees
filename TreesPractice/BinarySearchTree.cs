// BinarySearchTree.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TreesPractice
{
    public class BinarySearchTree : IEnumerable<int>
    {
        public TreeNode? Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public virtual void Add(int data, int? weight = null)
        {
            Root = Insert(Root, data, weight);
        }

        protected virtual TreeNode? Insert(TreeNode? node, int data, int? weight)
        {
            if (node == null)
            {
                return new TreeNode(data, weight);
            }

            if (data < node.Data)
            {
                node.Left = Insert(node.Left, data, weight);
            }
            else if (data > node.Data)
            {
                node.Right = Insert(node.Right, data, weight);
            }

            return node;
        }

        public void UnionWithPreorder(BinarySearchTree otherTree)
        {
            if (otherTree.Root != null)
            {
                using (var iterator = otherTree.GetPreorderIterator())
                {
                    while (iterator.MoveNext())
                    {
                        Add(iterator.Current);
                    }
                }
            }
        }

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
            sb.Append(node.Data);
            if (node.Weight.HasValue)
            {
                sb.Append($"({node.Weight})");
            }
            sb.AppendLine();

            string childIndent = indent + (hasSibling ? "│   " : "    ");
            sb.Append(GetTreeString(node.Left, childIndent, true, node.Right != null));
            sb.Append(GetTreeString(node.Right, childIndent, false, false));

            return sb.ToString();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new PreorderIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public PreorderIterator GetPreorderIterator()
        {
            return new PreorderIterator(this);
        }
    }
}