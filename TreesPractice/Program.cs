// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace TreesPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 2. Формирование деревьев A и B путем добавления последовательности значений
            Console.WriteLine("Формирование деревьев A и B:");
            BinarySearchTree treeA = new BinarySearchTree();
            Console.Write("Дерево A (добавление): ");
            foreach (int val in new int[] { 5, 3, 8, 1, 4, 7, 9, 0, 2 }) // Примерно 10 узлов
            {
                treeA.Add(val);
                Console.Write($"{val} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Дерево A:\n{treeA}");

            BinarySearchTree treeB = new BinarySearchTree();
            Console.Write("Дерево B (добавление): ");
            foreach (int val in new int[] { 6, 10, 11, 12 }) // Несколько узлов
            {
                treeB.Add(val);
                Console.Write($"{val} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Дерево B:\n{treeB}");

            // 3. Операция A = A ∪пр B
            Console.WriteLine("\nВыполнение операции A = A ∪пр B:");
            treeA.UnionWithPreorder(treeB);
            Console.WriteLine($"Дерево A после объединения:\n{treeA}");

            // 4. Вывод исходных и результирующих данных (уже реализовано через ToString())

            // Дополнительное условие: оптимальное дерево двоичного поиска с весами
            Console.WriteLine("\nФормирование оптимального дерева с весами:");
            OptimalBinarySearchTree optimalTree = new OptimalBinarySearchTree();
            Console.WriteLine("Добавление узлов с весами:");
            optimalTree.Add(50, 8); Console.WriteLine("Добавлено: 50(8)");
            optimalTree.Add(30, 6); Console.WriteLine("Добавлено: 30(6)");
            optimalTree.Add(70, 7); Console.WriteLine("Добавлено: 70(7)");
            optimalTree.Add(20, 2); Console.WriteLine("Добавлено: 20(2)");
            optimalTree.Add(40, 9); Console.WriteLine("Добавлено: 40(9)");
            optimalTree.Add(60, 5); Console.WriteLine("Добавлено: 60(5)");
            optimalTree.Add(80, 1); Console.WriteLine("Добавлено: 80(1)");

            Console.WriteLine($"\nОптимальное дерево (с весами):\n{optimalTree}");

            // Вывод средневзвешенной высоты оптимального ДДП
            double weightedHeight = optimalTree.CalculateWeightedHeight();
            int totalWeight = typeof(OptimalBinarySearchTree).GetMethod("GetTotalWeight", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?
                .Invoke(optimalTree, new object[] { optimalTree.Root }) as int? ?? 0;
            // TODO: fix null reference exception in optimalTree

            Console.WriteLine($"\nСредневзвешенная высота оптимального дерева: {(totalWeight > 0 ? weightedHeight / totalWeight : 0):F2}");

            // Дополнительное условие: перечисление узлов дерева A с помощью итератора и цикла range-for (foreach)
            Console.WriteLine("\nПеречисление узлов дерева A с помощью итератора (прямой обход):");
            foreach (var item in treeA)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}