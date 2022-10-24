using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Microsoft.VisualBasic;
using ProgAssign1.Model;
//using static ProgAssign1.Logger;

namespace ProgAssign1
{
    class CsvParser
    {
        public List<CsvWriteModel> readCsv(List<string> fileList)
        {
            try
            {
                List<CsvWriteModel> newRecords = new List<CsvWriteModel>();
                Logger logger = new Logger();
                Logger.logToFile("Csv Reading begins");
                int skippedRecords = 0;

                foreach(string file in fileList)
                {
                    string[] pathSplit = file.Split("\\");
                    string date = pathSplit[7] + "/" + pathSplit[8] + "/" + pathSplit[9];
                    string fileName = pathSplit[10];
                    Console.WriteLine(date + " "+ fileName);

                    var csvReaderConfiguration = new CsvHelper.Configuration.CsvConfiguration(cultureInfo: CultureInfo.InvariantCulture)
                    {
                        MissingFieldFound = null
                    };

                    using (var reader = new StreamReader(file))
                    using (var csv = new CsvReader(reader, csvReaderConfiguration))
                    {
                        var rows = csv.GetRecords<CsvReadModel>();
                        foreach(var row in rows)
                        {
                            if (row.firstName != "" && row.lastName != "" && row.streetNumber != "" && row.street != "" && row.city != "" &&
                               row.province != "" && row.postalCode != "" && row.country != "" && row.phoneNumber != "" &&
                               row.emailAddress != "")
                            {
                                CsvWriteModel writingRecord = new CsvWriteModel();
                                writingRecord.firstName = row.firstName;
                                writingRecord.lastName= row.lastName;
                                writingRecord.streetNumber = row.streetNumber;
                                writingRecord.street = row.street;
                                writingRecord.city = row.city;
                                writingRecord.province = row.province;
                                writingRecord.postalCode = row.postalCode;
                                writingRecord.country = row.country;
                                writingRecord.phoneNumber = row.phoneNumber;
                                writingRecord.emailAddress= row.emailAddress;
                                writingRecord.date = date;

                                newRecords.Add(writingRecord);
                            } else
                            {
                                skippedRecords++;
                            }
                        }
                    }
                }
                Logger.logToFile("skipped Records: " + skippedRecords);
                Logger.logToFile($"Valid Records: {newRecords.Count}");

                return newRecords;

            } catch
            {
                throw;
            }
        }
    }
}
