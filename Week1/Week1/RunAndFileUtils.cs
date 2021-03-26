using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Week1.Handlers;

namespace Week1
{
    class FileUtils
    {
        public static List<Spesa> speseDaFile { get; set; }



        public static void Create(List<Spesa> spese, string fileNamee)
        {
            string path = Path.Combine(@"C:\Users\elena.zazzetti\Desktop\ElenaZazzetti", fileNamee + ".txt");
            Console.WriteLine($"Saving to {fileNamee} ... ");

            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {

                    foreach (var spesa in spese)
                    {
                        if(spesa.Approvata==true)
                        writer.WriteLine(spesa.Data.ToShortDateString() + ";" + spesa.Categoria + ";" + "APPROVATA"+ ";" +spesa.LivelloApprovazione+ ";"+ spesa.GetRimborso());
                        else writer.WriteLine(spesa.Data.ToShortDateString() + ";" + spesa.Categoria + ";" + "RESPINTA" + ";-;-");
                    }

                  

                    writer.Close();

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"ERRORE IO:  {ex.Message}");

            }
            catch (Exception e)
            {
                Console.WriteLine($"ERRORE :  {e.Message}");

            }
        }




        public static void Run()
        {
            List<Spesa> spese = speseDaFile;
            if (spese != null)
            {

                var manager = new Manager();
                var opManager = new OperationalManager();
                var ceo = new CEO();
                manager.SetNext(opManager).SetNext(ceo);

                foreach (var spesa in spese)
                {
                    var result = manager.Handle(spesa);
                }



                FileUtils.Create(spese, "spese_elaborate");
            }

        }



        public static void Read( FileSystemEventArgs efile)
        {
            string path = Path.Combine(@"C:\Users\elena.zazzetti\Desktop\ElenaZazzetti", efile.Name + ".txt");

            try
            {
                using (StreamReader reader = File.OpenText(efile.FullPath))
                {
                    Console.WriteLine($"### {efile.Name} Content Read ###");

                    List<Spesa> spese = new List<Spesa>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] args = line.Split(";");
                        if (args.Length != 4 || ! DateTime.TryParse(args[0], out DateTime data)|| !double.TryParse(args[3], out double importo))
                        {
                            Console.WriteLine("Format not as expected");
                            return;
                        }
                        
                        Console.WriteLine("Data: {0} Categoria: {1} Descrizione: {2} Importo: {3}", data.ToShortDateString(), args[1], args[2], importo);

                        spese.Add(Factory.FactorySpesaPerCategoria(data, args[1], args[2], importo));
                                               

                    }
                    Console.WriteLine("### End Content ###");
                    Console.WriteLine();
                    reader.Close();
                    speseDaFile = spese;
                    Run();
                    

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"ERRORE IO:  {ex.Message}");
                return ;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRORE :  {ex.Message}");
                return ;
            }

        }
    }
}
