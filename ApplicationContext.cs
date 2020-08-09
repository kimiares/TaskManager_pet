using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TaskManager_pet
{
    class ApplicationContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public ApplicationContext()
        {
            
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1; UserId=root; password = kimiomio89; database=taskmanager;");
        }
        public static void Drop()
        {
            using (ApplicationContext db = new ApplicationContext())
            {


                db.Database.EnsureDeleted();


                Console.WriteLine("Таблица удалена");
            }
        }
        public static void View()
        {
            using (ApplicationContext db = new ApplicationContext())
            {


                var tasks = db.Tasks.ToList();
                Console.WriteLine("Список существующих задач:");

                foreach (Task t in tasks)
                {
                    Console.WriteLine($"{t.ID}.{t.NameOfTask}\n Описание : {t.Decription }\n Статус задачи {t.Status}\t");


                }
            }
        }

        public static void ViewActual()
        {
            using (ApplicationContext db = new ApplicationContext())
            {


                
                var tasks = db.Tasks.Where(t => t.Status == true);
                Console.WriteLine("Актитвные задачи:");

                foreach (Task t in tasks)
                {
                    Console.WriteLine($"{t.ID}.{t.NameOfTask}\n Описание: {t.Decription }");
                }
            }
        }
        public static void ViewINActual()
        {
            using (ApplicationContext db = new ApplicationContext())
            {



                var tasks = db.Tasks.Where(t => t.Status == false);
                Console.WriteLine("Неактивные задачи:");

                foreach (Task t in tasks)
                {
                    Console.WriteLine($"{t.ID}.{t.NameOfTask}\n Описание: {t.Decription }");
                }
            }
        }
    }
}
