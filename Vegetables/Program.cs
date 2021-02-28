using System;
using System.IO;

namespace Vegetables
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Menu();
                Console.WriteLine("Для завершения работы программы нажмите Escape");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// вывод меню
        /// </summary>
        static void Menu()
        {
            int check = 0;
            Console.WriteLine("Выберите один из двух вариантoв:\n1.Консольный ввод.\n2.Ввод из файла.");
            while (!int.TryParse(Console.ReadLine(), out check) && (check != 1 || check != 2))
                Console.WriteLine("Некрректное значение! Попробуйте снова: ");
            switch (check)
            {
                case 1:
                    ConsoleInput();
                    break;
                case 2:
                    Console.WriteLine("Сори, ввод из файла не работает, так что придется ручками((");
                    ConsoleInput();
                    break;
            }
        }

        /// <summary>
        /// ввод данных из консоли
        /// </summary>
        static void ConsoleInput()
        {
            int count = 0;
            int price = 0;
            Console.Write("Введите вместимость хранилища: ");
            while (!int.TryParse(Console.ReadLine(), out count) && count <= 0)
                Console.WriteLine("Это должно быть положительное число! Попробуйте снова:");
            Console.WriteLine("Введите цену хранения: ");
            while (!int.TryParse(Console.ReadLine(), out price) && price <= 0)
                Console.WriteLine("Это должно быть положительное число! Попробуйте снова:");
            Store store = new Store(count, price);
            //завершение формирования склада
            do
            {
                ChooseCommand(store);
                Console.WriteLine("Для завершения формирования склада введите end.");
            } while (Console.ReadLine().ToLower() != "end");
            ConsoleOutput(store);
        }

        /// <summary>
        /// вывод данных в консоль
        /// </summary>
        /// <param name="store">объект класса склада</param>
        static void ConsoleOutput(Store store)
        {
            int check;
            Console.WriteLine("Выберите один из двух вариантов:\n1.Консольный вывод.\n2.Вывод в файл.");
            while (!int.TryParse(Console.ReadLine(), out check) && (check != 1 || check != 2))
                Console.WriteLine("Некрректное значение! Попробуйте снова: ");
            switch (check)
            {
                case 1:
                    Console.WriteLine(store.ToString());
                    break;
                case 2:
                    Console.Write("Введите полный путь к файлу: ");
                    string output_path = Console.ReadLine();
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(output_path))
                            sw.Write(store.ToString());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Некорректный путь к файлу!");
                    }
                    break;
            }
        }

        /// <summary>
        /// добавление или удаление объекта из контейнера
        /// </summary>
        /// <param name="store">объект класса склада</param>
        static void ChooseCommand(Store store)
        {
            int choose = 0;
            Console.WriteLine("Выберите один из двух вариантовв:\n1.Добавить контейнер.\n2.Удалить контейнер.");
            while (!int.TryParse(Console.ReadLine(), out choose) && (choose != 1 || choose != 2))
                Console.WriteLine("Некрректное значение! Попробуйте снова: ");
            switch (choose)
            {
                case 1:
                    store.AddContainer(CreateContainer());
                    break;
                case 2:
                    int i = 0;
                    Console.Write("Введите номер контейнера, который вы хотите удалить: ");
                    while (!int.TryParse(Console.ReadLine(), out i) && (i > store.Containers.Count || i <= 0))
                        Console.WriteLine($"Это должно быть положительное число, не превышающее {store.Containers.Count}! Попробуйте снова:");
                    try
                    {
                        store.DeleteContainer(store.Containers[i - 1]);
                    }
                    catch (Exception)
                    {
                        
                    }
                    break;
            }
        }

        /// <summary>
        /// создание нового контейнера 
        /// </summary>
        /// <returns>контейнер</returns>
        static Container CreateContainer()
        {
            int max_count = 0;
            Console.Write("Введите вместимость контейнера: ");
            while (!int.TryParse(Console.ReadLine(), out max_count) && max_count <= 0)
                Console.WriteLine("Это должно быть положительное число! Попробуйте снова:");
            Container container = new Container(max_count);
            for (int i = 0; i < max_count; i++)
            {
                try
                {
                    container.AddBox(CreateBox());
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return container;
        }

        /// <summary>
        /// создание новой коробки 
        /// </summary>
        /// <returns>коробку</returns>
        static Box CreateBox()
        {
            int weight = 0;
            int price = 0;
            Console.Write("Введите вес коробки: ");
            while (!int.TryParse(Console.ReadLine(), out weight) && weight <= 0)
                Console.WriteLine("Это должно быть положительное число! Попробуйте снова:");
            Console.Write("Введите стоимость коробки: ");
            while (!int.TryParse(Console.ReadLine(), out price) && price <= 0)
                Console.WriteLine("Это должно быть положительное число! Попробуйте снова:");
            return new Box(price, weight);
        }
    }
}
