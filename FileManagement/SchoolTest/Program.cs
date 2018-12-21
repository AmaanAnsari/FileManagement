using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTest
{
    class Program
    {
        // Main
        static string filename;


        // WriteToAllDir
        static int writtenFilesCount = 0;
        static int foundFilesCount = 0;

        static void Main(string[] args)
        {

            Console.WriteLine("This Programm can find, write and delete files in a directory with his subdirectories");
            Console.WriteLine("");
            Start:
            Console.WriteLine("Please enter your file name (if your file name is incorrect the programm will crash): ");
            filename = Console.ReadLine();
            Console.WriteLine("Please enter your path: ");
            string pfad = Console.ReadLine();


            FalseOption:
            Console.WriteLine("What would you like to do ? Type s for search or w for write or d for delete");
            string input = Console.ReadLine();
            if (input == "s")
            {
                if (!Directory.Exists(pfad))
                {
                    Console.WriteLine("Path not exists");
                    goto Start;
                }

                FindAllFiles(pfad);
                Console.WriteLine(foundFilesCount + " files found.");

            }
            else if (input == "w")
            {
                WriteToAllDir(pfad);
                Console.WriteLine(writtenFilesCount + " are written.");
                writtenFilesCount = 0;

            }
            else if (input == "d")
            {
                DeleteAllFiles(pfad);
            }
            else { Console.WriteLine("Error: Option not avaible !!"); goto FalseOption; }

            Console.WriteLine("PROGRAMM END");
            Console.ReadKey();
            goto Start;

        }

        private static void WriteToAllDir(string inputPfad)
        {
            DirectoryInfo inputPfadInfo = new DirectoryInfo(inputPfad);

            foreach (System.IO.DirectoryInfo foundOrdner in inputPfadInfo.GetDirectories())
            {
                try
                {
                    string writeFilePath = inputPfadInfo + @"\" + foundOrdner + @"\" + filename;
                    File.WriteAllText(writeFilePath, "");
                    writtenFilesCount++;
                    Console.WriteLine("W:" + writeFilePath);

                    WriteToAllDir(inputPfad + @"\" + foundOrdner);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            
        }

        private static void FindAllFiles(string inputPfad)
        {
            DirectoryInfo inputPfadInfo = new DirectoryInfo(inputPfad);


            foreach (System.IO.DirectoryInfo foundOrdner in inputPfadInfo.GetDirectories())
            {
                try
                {
                    string foundFile = inputPfadInfo + @"\" + foundOrdner + @"\" + filename;
                    if (File.Exists(foundFile))
                    {
                        Console.WriteLine("F: " + foundFile);
                        foundFilesCount++;
                    }
                    FindAllFiles(inputPfad + @"\" + foundOrdner);

                }
                catch
                {

                }

            }

        }

        private static void DeleteAllFiles(string inputPfad)
        {
            DirectoryInfo inputPfadInfo = new DirectoryInfo(inputPfad);

            foreach (System.IO.DirectoryInfo foundOrdner in inputPfadInfo.GetDirectories())
            {
                try
                {
                    string foundFile = inputPfadInfo + @"\" + foundOrdner + @"\" + filename;
                    if (File.Exists(foundFile))
                    {
                        File.Delete(foundFile);
                    }
                    DeleteAllFiles(inputPfad + @"\" + foundOrdner);

                }
                catch
                {

                }

            }

        }

    }


}
