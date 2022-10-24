using System;
using System.Collections.Generic;
using CsvHelper;
using System.Globalization;
using System.IO;


namespace ProgAssign1
{
    class CsvCreator
    {

       public void createCsv(string path, List<Model.CsvWriteModel> resultData)
        {
            try
            {
                Logger.logToFile("Writing to output Csv begins");
                using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(resultData);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in 'path' is invalid.");
            }
        }

        public static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Logger.logToFile("Start execution of program");
            DirWalker fileWalk = new DirWalker();
            CsvParser csvParser = new CsvParser();
            CsvCreator csvCreator = new CsvCreator();
            
            List<string> fileList = new List<string>();

            string writePath = @"D:\SMU\Software-dev-5510\.net assignment 1\MCDA_5510_Assignment_directory\A00467834_MCDA5510\Assignment1\ProgAssign1\output\output.csv";

            fileList = fileWalk.walk(@"D:\SMU\Software-dev-5510\.net assignment 1\MCDA_5510_Assignment_directory\A00467834_MCDA5510\Sample Data");

             var recordsWithDate =  csvParser.readCsv(fileList);

            csvCreator.createCsv(writePath, recordsWithDate);
            watch.Stop();
            Logger.logToFile($"{watch.ElapsedMilliseconds} ms");
        }
    }
}
