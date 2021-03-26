using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Week1
{
    public class GestioneEventi
    {

        public static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"{e.ChangeType.ToString()}: {e.FullPath}");

        }

        public static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"{e.ChangeType}: {e.FullPath}";
            Console.WriteLine(value);


            FileUtils.Read(e);
     


        }



    }
}
