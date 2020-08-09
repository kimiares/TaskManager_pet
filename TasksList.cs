using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManager_pet
{
    class TasksList : List<Task>
    {

        public TasksList() { }

        public void Add(string nameOftask, string desc)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                int taskID = this.Count();
                int ID = taskID++;
                db.Tasks.Add((new Task(nameOftask, desc, ID, true)));
                db.SaveChanges();
            }


              
        }


        public void Edit(int idToChange, string NameOfTaskChanged, string DescriptionChanged, bool StatusChanged)
        {
            using (ApplicationContext db = new ApplicationContext())
            {


                var task = db.Tasks.Where(t => t.ID == idToChange);

                Task taskTochange = (Task)task;

                taskTochange.NameOfTask = NameOfTaskChanged;
                taskTochange.Decription = DescriptionChanged;
                taskTochange.Status = StatusChanged;

                db.SaveChanges();
            }
        }
        public void Delete(int deleteId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                
                var task = db.Tasks.Where(t => t.ID == deleteId);

                Task taskToDelete = (Task)task;

                db.Tasks.Remove(taskToDelete);

                db.SaveChanges();
            }
        }

        //public void View()
        //{
        //    using (ApplicationContext db = new ApplicationContext())
        //    {

        //        Console.WriteLine("Список существующих задач");
        //        var tasks = db.Tasks.ToList();
        //        foreach(var t in tasks)
        //            Console.WriteLine($"{t.ID}.{t.NameOfTask}\n Описание : {t.NameOfTask }\n Статус задачи {t.Status}");
        //    }
        //}






    }
}
