using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransferDrill
{
    class Program
    {
        static int compareForNewness(DateTime fileTime)
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            int result = DateTime.Compare(fileTime, yesterday);
            return result;
        }

        static void getArrayOfFiles()
        {
            List<string> listOfFiles = new List<string>();
            string[] files = Directory.GetFiles("C:\\A\\");
            foreach(string f in files)
            {
                DateTime fileCTime = File.GetCreationTime(f);
                DateTime fileMTime = File.GetLastWriteTime(f);
                if ((compareForNewness(fileCTime) > 0) || (compareForNewness(fileMTime) > 0))
                {
                    listOfFiles.Add(f);
                }
            }
            transferFiles(listOfFiles);

        }

        static void transferFiles(List<string> listOfFiles)
        {
            foreach (string f in listOfFiles)
            {
                File.Copy(f, "C:\\B\\" + Path.GetFileName(f), true);
            }
            return;
        }
        
        static void Main(string[] args)
        {
            getArrayOfFiles();
            Console.WriteLine("All files created or modified in the past 24 hours in C:\\A\nhave been copied to C:\\B");
            

        }
    }
}
