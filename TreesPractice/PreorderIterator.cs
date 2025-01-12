// PreorderIterator.cs
using System.Collections;


namespace TreesPractice
{
    public class PreorderIterator : IEnumerator<int>
    {
        private Stack<TreeNode> stack;

        public PreorderIterator(BinarySearchTree tree)
        {
            stack = new Stack<TreeNode>();
            if (tree.Root != null)
            {
                stack.Push(tree.Root);
            }
        }

        public int Current
        {
            get
            {
                return stack.Peek().Data;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (stack.Count > 0)
            {
                TreeNode current = stack.Pop();
                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }
                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
}