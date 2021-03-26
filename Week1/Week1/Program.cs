using System;
using System.Collections.Generic;
using System.IO;
using Week1.Handlers;

namespace Week1
{
    class Program
    {
        static void Main(string[] args)
        {

            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = @"C:\Users\elena.zazzetti\Desktop\ElenaZazzetti";

            watcher.Filter = "spese.txt";



            watcher.NotifyFilter = NotifyFilters.Attributes
                     | NotifyFilters.CreationTime
                     | NotifyFilters.DirectoryName
                     | NotifyFilters.FileName
                     | NotifyFilters.LastAccess
                     | NotifyFilters.LastWrite
                     | NotifyFilters.Security
                     | NotifyFilters.Size;

            watcher.EnableRaisingEvents = true;

            //watcher.Changed += GestioneEventi.OnChanged;

            watcher.Created += GestioneEventi.OnCreated;


           

            Console.WriteLine("Premi un tasto");

            Console.ReadKey();
        }
    }
}
