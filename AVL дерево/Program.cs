using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaB1C
{
    enum MenuItem { Insert = 1, Delete, Show,  Save, Clear, Quit };
    enum MenuInsert { Manually = 1, Random, FileWork };
    
    class Program
    {

        static async Task Main()
        {
            int userChoice = 0;
            int insertChoice = 0;
            int number = 0;
            int count = 0;
            bool check = false;
            bool correctRange = false;
            int minValue=0;
            int maxValue = 0;

            Interface menu = new Interface();
            Functions choice = new Functions();
            FileWork gr = new FileWork();
            menu.Hello();
            AVLnode tree=null;

            do {
                menu.Menu();
                userChoice = choice.GetInt();
                switch (userChoice)
                {
                    case ((int)MenuItem.Insert): {
                            menu.FirstPoint();
                            insertChoice = choice.GetInt();
                            switch (insertChoice)
                            {
                                case ((int)MenuInsert.Manually): {
                                        Console.WriteLine("Введите кол-во добавляемых элементов");
                                        count = choice.GetInt();
                                        while (count < 1)
                                        {
                                            menu.Mistake(401);
                                            count = choice.GetInt();
                                        }
                                        for (int i = 0; i < count; i++)
                                        {
                                            Console.WriteLine("Введите значение");
                                            number = choice.GetInt();
                                            while (number < 0)
                                            {
                                                menu.Mistake(401);
                                                Console.WriteLine("Введите значение");
                                                number = choice.GetInt();
                                            }
                                            if (tree != null)
                                            {
                                                check = tree.FindNode(tree, number);
                                                while (check == true)
                                                {
                                                    menu.Mistake(402);
                                                    number = choice.GetInt();
                                                   check = tree.FindNode(tree, number);
                                                }
                                                tree=tree.Insert(tree, number);
                                            }
                                            else tree = new AVLnode(number);
                                            Console.WriteLine("Узел успешно добавлен");
                                        }

                                    } break;
                                case ((int)MenuInsert.Random): {
                                        Console.WriteLine("Введите кол-во добавляемых элементов");
                                        count = choice.GetInt();
                                        while (count < 1)
                                        {
                                            menu.Mistake(401);
                                            count = choice.GetInt();
                                        }
                                        menu.InterfaceRange(201);
                                        menu.InterfaceRange(202);
                                        minValue = choice.GetInt();

                                        while ( minValue<0)
                                        {
                                            menu.Mistake(401);
                                            menu.InterfaceRange(202);
                                            minValue = choice.GetInt();
                                        }

                                        menu.InterfaceRange(203);
                                        maxValue = choice.GetInt();

                                        while (correctRange == false)
                                        {
                                            if ((maxValue < minValue)||((maxValue - minValue + 1) < count)) {
                                                if (maxValue < minValue) menu.Mistake(401);
                                                else menu.InterfaceRange(204);
                                                menu.InterfaceRange(201);
                                                menu.InterfaceRange(202);
                                                minValue = choice.GetInt();
                                                while (minValue < 0)
                                                {
                                                    menu.Mistake(401);
                                                    menu.InterfaceRange(202);
                                                    minValue = choice.GetInt();
                                                }
                                                menu.InterfaceRange(203);
                                                maxValue = choice.GetInt(); }
                                            else correctRange = true;
                                        }

                                        try
                                        {
                                            for (int i = 0; i < count; i++)
                                            {
                                                Random rnd = new Random();
                                                number = rnd.Next(minValue, maxValue);
                                                if (tree != null)
                                                {
                                                    check = tree.FindNode(tree, number);
                                                    if (check)
                                                    {
                                                        for (int j = minValue; j <= maxValue; j++)
                                                        {
                                                            check = tree.FindNode(tree, j);
                                                            if (check == false) { tree = tree.Insert(tree, j); break; }
                                                        }
                                                        if (check) { throw new Exception("Генераций невозможна т.к. в текущем диапазоне все значения уже добавлены"); }
                                                    }
                                                    else
                                                    {
                                                        tree = tree.Insert(tree, number);
                                                    }
                                                }
                                                else tree = new AVLnode(number);
                                            }
                                            Console.WriteLine("Узел(ы) успешно добавлен(ы)");
                                        }
                                        catch (Exception e) { Console.WriteLine($"Ошибка: {e.Message}"); }
                                        
                                        
                                        

                                }  break;
                                case ((int)MenuInsert.FileWork): {
                                        Console.WriteLine("Введите путь и имя файла");
                                        string fileName;
                                        fileName = gr.FileName();
                                        var data = await gr.ReadFile(fileName);
                                        if (data != null)
                                        {
                                            for (int i = 0; i < data.Count; i++) {
                                                if (tree != null)
                                                {
                                                    check = tree.FindNode(tree, data[i]);
                                                    if (check)
                                                    {
                                                        Console.WriteLine("Узел со значением {0} повторяется.", data[i]);
                                                        i++;
                                                    }
                                                    else 
                                                        tree = tree.Insert(tree, data[i]);
                                                }
                                                else tree = new AVLnode(data[i]);
                                            }
                                        }
                                    } break;
                                default: menu.Mistake(404); break;
                            }

                        }
                        break;
                    case ((int)MenuItem.Delete): {
                           Console.WriteLine("Введите значение");
                            number = choice.GetInt();
                            while (number < 0)
                            {
                                menu.Mistake(401);
                                number = choice.GetInt();
                            }
                            if (tree != null)
                            {
                                check = tree.FindNode(tree, number);
                                while (check == false)
                                {
                                    menu.Mistake(403);
                                    number = choice.GetInt();
                                    check = tree.FindNode(tree, number);
                                }
                                tree=tree.Remove(tree, number);
                                Console.WriteLine("Узел успешно удален");
                            }
                            else Console.WriteLine("Дерево пустое");
                        } break;
                    case ((int)MenuItem.Show): { 
                            if (tree==null)Console.WriteLine("Дерево пустое");
                            else tree.PrintToConsoleOriginal(tree);  } break;
                    case ((int)MenuItem.Save): {
                            gr.SaveData(tree);
                        } break;
                    case ((int)MenuItem.Clear): {
                            tree = null; 
                        } break;
                    case ((int)MenuItem.Quit): break;
                    default:menu.Mistake(404); break;
                }
            } while (userChoice != (int)MenuItem.Quit);
        }

    }

}
