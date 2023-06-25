using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaB1C
{
    public class AVLnode
    {
        private int height;
        private int bf;
        private int key;
        private AVLnode left;
        private AVLnode right;

        public AVLnode() { }
        public AVLnode(int k) { key = k; height = 1; left = right = null; }

        public int Height(AVLnode tree)
        {
            if (tree != null) return tree.height;
            else return 0;
        }
        
        void OverHeight(AVLnode tree) {
            int hleft = Height(tree.left);
            int hright = Height(tree.right);
            if (hleft > hright) tree.height=hleft+1;
            else tree.height=hright+1;
        }
        void BFactor(AVLnode tree)
        {
            tree.bf=Height(tree.right)-Height(tree.left);
        }

        AVLnode RightRotation(AVLnode tree)
        {
            AVLnode leftSubtree = tree.left;
            AVLnode leftSubtreeRightSubtree = leftSubtree.right;
            leftSubtree.right = tree;
            tree.left = leftSubtreeRightSubtree;
            tree = leftSubtree;
            OverHeight(tree.right);
            BFactor(tree.right);
            OverHeight(tree);
            BFactor(tree);
            return tree;
        }

        AVLnode LeftRotation(AVLnode tree)
        {
            AVLnode rightSubtree = tree.right;
            AVLnode rightSubtreeLeftSubtree = rightSubtree.left;
            rightSubtree.left = tree;
            tree.right = rightSubtreeLeftSubtree;
            tree = rightSubtree;
            OverHeight(tree.left);
            BFactor(tree.left);
            OverHeight(tree);
            BFactor(tree);
            return tree;
        }

        AVLnode Balance(AVLnode tree) 
        {
            OverHeight(tree);
            BFactor(tree);
            if (tree.bf == 2)
            {
                BFactor(tree.right);
                if (tree.right.bf < 0) tree.right = RightRotation(tree.right);
                return LeftRotation(tree);
            }
            if (tree.bf == -2)
            {
                BFactor(tree.left);
                if (tree.left.bf > 0) tree.left = LeftRotation(tree.left);
                return RightRotation(tree);
            }
            return tree;
        }

        public AVLnode Insert(AVLnode tree, int k)
        {
            if (tree == null) return new AVLnode(k);
            if (k < tree.key) tree.left = Insert(tree.left, k);
            else tree.right = Insert(tree.right, k);
            return Balance(tree);
        }

       
       public AVLnode FindMin(AVLnode p)
        {
            if (p.left != null)
                return FindMin(p.left);
            else
                return p;
        }

        AVLnode RemoveMin(AVLnode p)
        {
            if (p.left == null)
                return p.right;
            p.left = RemoveMin(p.left);
            return Balance(p);
        }

        public AVLnode Remove (AVLnode tree, int k)
        {
            if (tree == null) return null;
            if (k < tree.key)
                tree.left = Remove(tree.left, k);
            else if (k > tree.key)
                tree.right = Remove(tree.right, k);
            else
            { 
                    AVLnode rightP = tree.right;
                    AVLnode leftP = tree.left;
                    if (rightP == null) return leftP;
                    AVLnode min = FindMin(rightP);
                    min.right = RemoveMin(rightP);
                    min.left= leftP;
                    return Balance(min);
                
            }
            return Balance(tree);
        }

        public bool FindNode(AVLnode p, int k)
        {
            if (p != null)
            {
                if (FindNode(p.left, k)==true) return true;
                if (p.key == k) { return true; }
                if (FindNode(p.right, k)==true) return true;
            }
            return false;

        }
        public void output(AVLnode p)
        {
            if (p != null)
            {
                output(p.left);
                Console.Write(p.key+" ");
                output(p.right);
            }
        }


        public void PrintToConsoleOriginal(AVLnode p)
        {
            int heightTree = p.height;
            int maxLengthWord = 4;
            int maxWidth = (int)Math.Pow(2, (heightTree - 1)) *( maxLengthWord + 1 * 2);

            if (Console.WindowWidth < maxWidth + 2) 
               Console.WindowWidth = maxWidth + 2;


            PrintRowOriginal(new List<AVLnode>() { p }, maxLengthWord, maxWidth, heightTree);

            Console.WriteLine() ;
        }

        public void PrintRowOriginal(List<AVLnode> currenLst, int maxLengthWord, int maxWidth, int heightTree) {
            {
                // Отступ слева и справа между словами в текущей строке / высоте
                int space = (maxWidth - currenLst.Count * maxLengthWord) / (currenLst.Count * 2);
                Console.CursorLeft = 1;
                // Прорисовка узлов
                for (int i = 0; i < currenLst.Count; i++)
                {
                    Console.CursorLeft += space;
                    // Если данного узла нет, сдвигаем позицию
                    if (currenLst[i] == null)
                    {
                        Console.CursorLeft += maxLengthWord + space;
                        continue;
                    }

                    string value = currenLst[i].key.ToString();

                    // Если слово в левой половине - смещается левее, если в правой - правее
                    // Приведение к double - только для первой строки / высоты / корня
                    int half = i < (double)currenLst.Count / 2 ? 0 : 1;
                    // Позиция слова слева
                    int positionLeftValue =  ((maxLengthWord - value.Length + half) / 2);

                    int positionRightValue = (maxLengthWord - value.Length - positionLeftValue);
                    Console.CursorLeft += positionLeftValue;
                    Console.Write(value);
                    Console.CursorLeft += positionRightValue;
                    /*for (int j = 0, k = 0; j < maxLengthWord; j++)
                    {
                        if (Console.CursorLeft >= positionLeftValue && k < value.Length)
                            Console.Write(value[k++]);
                        else
                            Console.Write(' ');
                    }*/
                    Console.CursorLeft += space;
                }
                Console.WriteLine();
                // Если все дерево прорисовано - выходим из рекурсии
                if (Math.Pow(2, heightTree - 1) == currenLst.Count)
                    return;

                // Создание списка с узлами, которые идут ниже
                // Задаем Capacity в 2 раза больше, чем у текущего списка
                List<AVLnode> newLst = new List<AVLnode>(currenLst.Count * 2);
                foreach (var node in currenLst)
                {
                    newLst.Add(node == null ? null : node.left);//(node.left ?? null));
                    newLst.Add(node == null ? null : node.right);//(node.right ?? null));
                }
                PrintRowOriginal(newLst, maxLengthWord, maxWidth, heightTree);
            }
        }

        public void SaveTree(AVLnode tree, StreamWriter writer)
        {
            if (tree != null)
            {
                SaveTree(tree.left, writer);
                writer.Write(tree.key + " ");
                SaveTree(tree.right, writer);
            }
        }
    }
}
