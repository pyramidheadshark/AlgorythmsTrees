// PreorderIterator.cs
using System.Collections;
using System.Collections.Generic;



namespace TreesPractice
{
    public class PreorderIterator : IEnumerator<int>
    {
        private Stack<TreeNode> stack;
        private int _current;
        private bool _canReturnCurrent; // Флаг, показывающий, можно ли возвращать Current

        public PreorderIterator(BinarySearchTree tree)
        {
            stack = new Stack<TreeNode>();
            if (tree.Root != null)
            {
                stack.Push(tree.Root);
            }
            _canReturnCurrent = false;
        }

        public int Current
        {
            get
            {
                if (!_canReturnCurrent)
                {
                    throw new InvalidOperationException("Итератор находится вне последовательности.");
                }
                return _current;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (stack.Count > 0)
            {
                TreeNode currentNode = stack.Pop();
                _current = currentNode.Data;
                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }
                _canReturnCurrent = true; // Теперь можно возвращать Current
                return true;
            }
            _canReturnCurrent = false; // Больше нет элементов
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
}