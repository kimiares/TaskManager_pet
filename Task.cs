using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManager_pet
{
    class Task
    {

        public string NameOfTask { get; set; }
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
                var task = db.Tasks.Where(t => t.ID == idToChange).FirstOrDefault();
                task.Status = false;
                db.SaveChanges();
                Console.WriteLine("Задача помеченна как выполненная");
            }
        }



    }
}
