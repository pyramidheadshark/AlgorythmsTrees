// BinarySearchTree.cs
using System.Collections;
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

        public virtual void Add(int data)
        {
            Root = Insert(Root, data);
        }

        protected virtual TreeNode? Insert(TreeNode? node, int data)
        {
            if (node == null)
            {
                return new TreeNode(data);
            }

            if (data < node.Data)
            {
                node.Left = Insert(node.Left, data);
            }
            else if (data > node.Data)
            {
                node.Right = Insert(node.Right, data);
            }

            return node;
        }

        public void UnionWithPreorder(BinarySearchTree otherTree)
        {
            if (otherTree?.Root != null)
            {
                PreorderTraversalAction(otherTree.Root, data => Add(data));
            }
        }

        protected void PreorderTraversalAction(TreeNode? node, Action<int> action)
        {
            if (node != null)
            {
                action(node.Data);
                PreorderTraversalAction(node.Left, action);
                PreorderTraversalAction(node.Right, action);
            }
        }

        public override string ToString()
        {
            if (Root == null)
            {
                return "(пустое дерево)";
            }
            var sb = new StringBuilder();
            PrintTree(Root, "", true, sb, false);
            return sb.ToString();
        }

        protected void PrintTree(TreeNode? node, string indent, bool isLast, StringBuilder sb, bool showWeight)
        {
            if (node != null)
            {
                sb.Append(indent);
                sb.Append(isLast ? "└─" : "├─");
                sb.Append(node.Data);
                if (showWeight && node.Weight.HasValue)
                {
                    sb.Append($"({node.Weight})");
                }
                sb.AppendLine();

                string newIndent = indent + (isLast ? "  " : "│ ");
                PrintTree(node.Left, newIndent, node.Right == null, sb, showWeight);
                PrintTree(node.Right, newIndent, true, sb, showWeight);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new PreorderIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}