using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TaskManager_pet
{
    class WriteToFile
    {

        public string WritePath { get; set; }
        protected string NameOfTask { get; set; }
        protected string Description { get; set; }
        public static void FileWrite(string NameOfTask, string Description)
        {

            string WritePath = @"C:\Sharp\TMpet.txt";
            using (StreamWriter sw = new StreamWriter(WritePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(NameOfTask + " : " + Description);
            }
        }


    }
}
