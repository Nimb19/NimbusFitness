using System;
using NimbusFitness.BL;
using NimbusFitness.BL.Controller;
using NimbusFitness.BL.Model;

namespace NimbusFitness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение NimbusFitness!");

            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine().Trim();

            UserController userController = new UserController(name);
            EatingController eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                SignUp(userController, name);
            }

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести приём пищи");

            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                Console.WriteLine("Суммарная порция: ");
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static void SignUp(UserController userController, string name)
        {
            Console.WriteLine("Введите Ваш гендер: ");
            var gender = Console.ReadLine().Trim();

            DateTime birthDate = TakeBirthDate();

            var weight = TakeWeight();

            var height = TakeHeight();

            userController.SetNewUserData(name, gender, birthDate, weight, height);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var foodName = Console.ReadLine();

            Console.Write("Введите калорийность порции (на 100 грамм): ");
            double foodCalories = ParseDouble();

            Console.Write("Введите кол-во углеводов в порции (на 100 грамм): ");
            double foodCarbohydrates = ParseDouble();

            Console.Write("Введите кол-во жиров в порции (на 100 грамм): ");
            double foodFats = ParseDouble();

            Console.Write("Введите кол-во белков в порции (на 100 грамм): ");
            double foodProteins = ParseDouble();

            // Никому не нужный вес
            Console.Write("Введите вес порции (в граммах): ");
            double foodWeight = ParseDouble();

            return (new Food(foodName, foodCalories, foodCarbohydrates, foodFats, foodProteins), foodWeight);
        }

        private static double ParseDouble()
        {
            double doub;
            while (!double.TryParse(Console.ReadLine(), out doub))
            {
                Console.Write("Вы ввели некорректное число. Попробуйте ввести снова: ");
            }
            return doub;
        }

        private static DateTime TakeBirthDate()
        {
            Console.WriteLine("Введите дату рождения (dd.mm.yyyy):");

            DateTime birthDate = default;
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine().Trim(), out birthDate)) //TODO: Починить проверку
                {
                    DateTime checker;
                    DateTime.TryParse("00.00.1900", out checker);

                    if (birthDate.Year < checker.Year ||
                        birthDate.Year > DateTime.Today.Year)
                    {
                        Console.WriteLine("Дата рождения не может быть раньше 1900 года," +
                            " и не может быть больше или равна текущему году." +
                            "\nПожалуйста, введите повторно: ");
                    }
                    else
                    {
                        return birthDate;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения.\n" +
                        "Пожалуйста, введите повторно: ");
                }
            }
        }

        private static double TakeWeight()
        {
            Console.WriteLine("Введите свой вес:");

            double weight = default;
            while (true)
            {
                if (double.TryParse(Console.ReadLine().Trim(), out weight))
                {
                    if (weight < 1 || weight > 350)
                    {
                        Console.WriteLine("Вес не может быть меньше 1 кг и больше чем 350 кг." +
                            "\nПожалуйста, введите повторно: ");
                    }
                    else
                    {
                        return weight;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат веса.\n" +
                        "Пожалуйста, введите повторно: ");
                }
            }
        }

        private static double TakeHeight()
        {
            Console.WriteLine("Введите свой рост:");

            double height = default;
            while (true)
            {
                if (double.TryParse(Console.ReadLine().Trim(), out height))
                {
                    if (height < 1 || height > 350)
                    {
                        Console.WriteLine("Рост не может быть меньше 1 см и больше чем 260 см." +
                            "\nПожалуйста, введите повторно: ");
                    }
                    else
                    {
                        return height;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат роста.\n" +
                        "Пожалуйста, введите повторно: ");
                }
            }
        }
    }
}
