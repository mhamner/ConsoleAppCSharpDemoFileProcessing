using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleAppCSharpDemoFileProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a simple list of lines to write to the output file
            List<string> linesList = new List<string>();
            linesList.Add("Line 1");
            linesList.Add("Line 2");
            linesList.Add("Line 3");
            linesList.Add("Line 4");
            linesList.Add("Line 5");

            ////************************************************************
            ///  Demo writing a file with StreamWriter
            ////************************************************************
            //Get the path to the Desktop folder using GetFolderPath
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //Use StreamWriter to write the list of lines to the output file
            using (StreamWriter sw = new StreamWriter(Path.Combine(filePath, "DemoFile1.txt")))
            {
                foreach(string line in linesList)
                {
                    sw.WriteLine(line);
                }
            }
            ////************************************************************
            ///  Demo writing a file with File.WriteAllText
            ////************************************************************
            string stuffToWrite = "This is my text!";
            File.WriteAllText(Path.Combine(filePath, "DemoFile2.txt"), stuffToWrite);

            ////************************************************************
            ///  Demo writing a file with File.AppendAllLines
            ////************************************************************
            //Write a List<> using AppendAllLines
            File.AppendAllLines(Path.Combine(filePath, "DemoFile3.txt"), linesList);

            //Create an array[] and write it with AppendAllLines
            string[] linesToWrite = { "Line 6", "Line 7", "Line 8" };
            File.AppendAllLines(Path.Combine(filePath, "DemoFile3.txt"), linesToWrite);

            ////************************************************************
            ///  Demo reading from a file with StreamReader
            ////************************************************************
            string lineFromFile;

            try
            {
                //Let's read from the file we just created - DemoFile1.txt
                using (StreamReader sr = new StreamReader(Path.Combine(filePath, "DemoFile1.txt")))
                {
                    //Loop through the file and read line by line, and write that line to the Console
                    while ((lineFromFile = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(lineFromFile);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured during reading the file.  The error was: {ex.Message}.");
            }

            Console.WriteLine("Press any key to end.");
            Console.ReadKey();

        }
    }
}
