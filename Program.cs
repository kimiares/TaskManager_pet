using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace TaskManager_pet
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напоминайка бестолковая, консольная");


            
            using (ApplicationContext db = new ApplicationContext())
            {

                //db.GetService<ILoggerFactory>().AddProvider(new TMLoggerProvider());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите нужную функцию");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Show all - просмотр списка задач" +
                        "\nShow active - список актуальных задач"+
                        "\nShow comp(leted) - список выполненных задач" +
                        "\nAdd - добавить задачу " +
                        "\ndelete - удалить задачу " +
                        "\nDrop - удалить все задачи" + 
                        "\nEdit - изменить задачу" + 
                        "\nCheck - изменить статус задачи"+
                        "\nExit - выход из приложения");
                Console.ResetColor();
                    Console.WriteLine("(команды можно писать с маленькой буквы)");
                while (true)
                {
                    string type = Console.ReadLine();
                
                    if (type != null)
                    {

                    

                        switch (type)
                        {
                            case "show all":
                            case "all":
                                Console.WriteLine("Вы выбрали просмотр списка задач");
                                ApplicationContext.ShowAll();
                                break;

                            case "add":
                            case "a":
                                Console.WriteLine("Введите название задачи");
                                    string nameOftask = Console.ReadLine();
                                Console.WriteLine("Введите ее описание");
                                    string desc = Console.ReadLine();
                                Task.Add(nameOftask, desc);
                                WriteToFile.FileWrite(nameOftask, desc);
                                break;

                            case "exit":
                            case "ex":
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Вы выбрали выход из программы. Прощайте");
                                Console.ResetColor();
                                Environment.Exit(0);
                                break;

                            case "delete":
                            case "d":
                                Console.WriteLine("Введите ID задачи для удаления");
                                    var deleteId = Convert.ToInt32(Console.ReadLine());
                                Task.Delete(deleteId);
                                break;
                            case "edit":
                            case "e":
                                Console.WriteLine("Введите ID задачи для изменения");
                                    var idToChange = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите новое имя задачи: ");
                                    var NameOfTaskChanged = Console.ReadLine();
                                Console.WriteLine("Введите новое описание задачи: ");
                                    var DescriptionChanged = Console.ReadLine();
                                Task.Edit(idToChange, NameOfTaskChanged, DescriptionChanged);
                                break;
                            case "check":
                            case "c":
                                Console.WriteLine("Введите ID задачи, которая уже выполнена");
                                var idToCheck = Convert.ToInt32(Console.ReadLine());
                                Task.Check(idToCheck);
                                break;

                            case "drop":
                            case "dp":
                                Console.WriteLine("Вы удаляете все задачи");
                                ApplicationContext.Drop();
                                break;
                            case "show active":
                            case "active":
                                
                                ApplicationContext.ShowActive();
                                break;
                            case "show comp":
                            case "completed":
                                
                                ApplicationContext.ShowCompleted();
                                break;
                            default:
                                Console.WriteLine("Вы ввели неправильную команду");
                                break;

                        }
                    }
                }

            }
        }

       

    }
}
