// TreeNode.cs


namespace TreesPractice
{
    public class TreeNode
    {
        public int Data { get; set; }
        public int? Weight { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(int data, int? weight = null)
        {
            Data = data;
            Weight = weight;
            Left = null;
            Right = null;
        }
    }
}