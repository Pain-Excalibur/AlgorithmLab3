using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab3
{
    internal class Task3_Tree
    {
        public static void Start()
        {
            DirectoryTree tree = new DirectoryTree();
            tree.AddFolder("A/B/D");
            tree.AddFolder("A/C");
            tree.AddFolder("E");
        }
    }

    // Класс, представляющий узел дерева
    public class TreeNode
    {
        public string Name { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode(string name)
        {
            Name = name;
            Children = new List<TreeNode>();
        }
    }
    // Класс, представляющий дерево каталогов
    public class DirectoryTree
    {
        public TreeNode Root { get; set; }

        public DirectoryTree()
        {
            Root = new TreeNode("Root");
        }

        // Метод для добавления новой папки в дерево
        public void AddFolder(string path)
        {
            string[] folders = path.Split('/');
            TreeNode currentNode = Root;

            foreach (string folder in folders)
            {
                TreeNode existingNode = currentNode.Children.FirstOrDefault(x => x.Name == folder);

                if (existingNode != null)
                {
                    currentNode = existingNode;
                }
                else
                {
                    TreeNode newNode = new TreeNode(folder);
                    currentNode.Children.Add(newNode);
                    currentNode = newNode;
                }
            }
        }
    }
}
