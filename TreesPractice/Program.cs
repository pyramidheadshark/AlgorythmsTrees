// Program.cs
namespace TreesPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 2. Формирование деревьев A и B
            BinarySearchTree treeA = new BinarySearchTree();
            BinarySearchTree treeB = new BinarySearchTree();

            Random random = new Random();

            Console.WriteLine("Исходное дерево A:");
            foreach (var value in Enumerable.Range(0, 10).Select(_ => random.Next(1, 100)))
            {
                treeA.Add(value);
                Console.Write($"{value} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Дерево A:\n{treeA}");

            Console.WriteLine("\nИсходное дерево B:");
            foreach (var value in Enumerable.Range(0, 7).Select(_ => random.Next(1, 100)))
            {
                treeB.Add(value);
                Console.Write($"{value} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Дерево B:\n{treeB}");

            // 3. Операция A = A ∪пр B
            treeA.UnionWithPreorder(treeB);
            Console.WriteLine("\nДерево A после объединения с B:");
            Console.WriteLine(treeA);

            // Дополнительное условие: Оптимальное дерево с весами
            Console.WriteLine("\nОптимальное дерево (с весами):");
            OptimalBinarySearchTree optimalTree = new OptimalBinarySearchTree();
            optimalTree.Add(50, 8);
            optimalTree.Add(30, 6);
            optimalTree.Add(70, 7);
            optimalTree.Add(20, 2);
            optimalTree.Add(40, 9);
            optimalTree.Add(60, 5);
            optimalTree.Add(80, 1);

            Console.WriteLine($"Оптимальное дерево:\n{optimalTree}");

            double weightedHeight = optimalTree.CalculateWeightedHeight();
            int totalWeight = typeof(OptimalBinarySearchTree).GetMethod("GetTotalWeight", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?
                .Invoke(optimalTree, new object[] { optimalTree.Root }) as int? ?? 0;

            Console.WriteLine($"Средневзвешенная высота оптимального дерева: {(totalWeight > 0 ? weightedHeight / totalWeight : 0):F2}");

            Console.WriteLine("\nПеречисление узлов дерева A с помощью итератора (прямой обход):");
            foreach (var item in treeA)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}