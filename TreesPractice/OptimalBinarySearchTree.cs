// OptimalBinarySearchTree.cs
using System.Text;


namespace TreesPractice
{
    public class OptimalBinarySearchTree : BinarySearchTree
    {
        public override void Add(int data)
        {
            // В оптимальном дереве добавление без веса не имеет смысла, вызываем исключение
            throw new InvalidOperationException("Для оптимального дерева необходимо указывать вес узла.");
        }

        public void Add(int data, int weight)
        {
            Root = InsertWithPriority(Root, data, weight);
        }

        private TreeNode? InsertWithPriority(TreeNode? node, int data, int weight)
        {
            if (node == null)
            {
                return new TreeNode(data, weight);
            }

            if (data < node.Data)
            {
                node.Left = InsertWithPriority(node.Left, data, weight);
                if (node.Left != null && (!node.Weight.HasValue || node.Left.Weight > node.Weight))
                {
                    node = RotateRight(node);
                }
            }
            else if (data > node.Data)
            {
                node.Right = InsertWithPriority(node.Right, data, weight);
                if (node.Right != null && (!node.Weight.HasValue || node.Right.Weight > node.Weight))
                {
                    node = RotateLeft(node);
                }
            }

            return node;
        }

        private TreeNode? RotateRight(TreeNode? y)
        {
            TreeNode? x = y?.Left;
            TreeNode? t2 = x?.Right;
            x!.Right = y;
            y!.Left = t2;
            return x;
        }

        private TreeNode? RotateLeft(TreeNode? x)
        {
            TreeNode? y = x?.Right;
            TreeNode? t2 = y?.Left;
            y!.Left = x;
            x!.Right = t2;
            return y;
        }

        public double CalculateWeightedHeight()
        {
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

        public override string ToString()
        {
            if (Root == null)
            {
                return "(пустое дерево)";
            }
            var sb = new StringBuilder();
            PrintTree(Root, "", true, sb, true); // Показываем вес
            return sb.ToString();
        }
    }
}