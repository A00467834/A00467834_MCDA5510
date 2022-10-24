using System;
using System.IO;
using System.Collections.Generic;

namespace ProgAssign1
{
  

    public class DirWalker
    {

        List<string> fileList = new List<string>();

        public List<string> walk(String path)
        {

            string[] list = Directory.GetDirectories(path);


            if (list == null) return null;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {
                if (filepath.Contains(".csv"))
                {
                    this.fileList.Add(filepath);
                }
            }
            return this.fileList;
        }

       /* public static void Main(String[] args)
        {
            DirWalker fw = new DirWalker();
            fw.walk(@"D:\SMU\Software-dev-5510\.net assignment 1\MCDA_5510_Assignment_directory\A00467834_MCDA5510\Sample Data");
        }*/

    }
}
