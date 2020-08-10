using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace TaskManager_pet
{
    class Task
    {

        [StringLength(50, ErrorMessage = "Слишком длинное имя")]
        public string NameOfTask { get; set; }
        [StringLength(170, ErrorMessage = "Войну и мир писать не надо")]
        public string Decription { get; set; }
        public int ID { get; set; }

        public bool Status { get; set; }

        public Task(string nameOftask, string desc, int id, bool stat)
        {
            NameOfTask = nameOftask;
            Decription = desc;
            ID = id;
            Status = stat;
        }

        public Task()
        {
        }


        public static void Add(string nameOftask, string desc)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.GetService<ILoggerFactory>().AddProvider(new TMLoggerProvider());
                //var tasks = db.Tasks.Count();
                int taskID = 0;
                int ID = taskID++;
                db.Tasks.Add((new Task(nameOftask, desc, ID, true)));
                db.SaveChanges();
                Console.WriteLine("Задача добавлена");
            }

        }
        public static void Delete(int deleteId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.GetService<ILoggerFactory>().AddProvider(new TMLoggerProvider());

                var task = db.Tasks.Where(t => t.ID == deleteId).FirstOrDefault();

                //Task taskToDelete = (Task)task;

                db.Tasks.Remove(task);

                db.SaveChanges();
                Console.WriteLine("Задача удалена");
            }
        }
        public static void Edit(int idToChange, string NameOfTaskChanged, string DescriptionChanged)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                db.GetService<ILoggerFactory>().AddProvider(new TMLoggerProvider());
                var task = db.Tasks.Where(t => t.ID == idToChange).FirstOrDefault();


                task.NameOfTask = NameOfTaskChanged;
                task.Decription = DescriptionChanged;
                task.Status = true;

                db.SaveChanges();
            }
        }
        public static void Check(int idToChange)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.GetService<ILoggerFactory>().AddProvider(new TMLoggerProvider());
                var task = db.Tasks.Where(t => t.ID == idToChange).FirstOrDefault();
                task.Status = false;
                db.SaveChanges();
                Console.WriteLine("Задача помеченна как выполненная");
            }
        }



    }
}
