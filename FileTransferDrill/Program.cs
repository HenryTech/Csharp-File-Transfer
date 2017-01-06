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

        static string[] getArrayOfFiles()
        {
            string[] files = null;
            List<string> listOfFiles = new List<string>;
            files = System.IO.Directory.GetFiles("C:\\A\\");
            foreach(string f in files)
            {
                DateTime fileCTime = File.GetCreationTime(f);
                DateTime fileMTime = File.GetLastWriteTime(f);
                if ((compareForNewness(fileCTime) > 1) || (compareForNewness(fileMTime) > 1))
                {
                    listOfFiles.Add(f);
                }
            }
        }

        static void transferFiles(String[] listOfFiles)
        {

        }
        
        static void Main(string[] args)
        {
            DateTime time = File.g("C:\\pyfund\\words.py");
            string[] files = null;
            files = Directory.GetFiles("C:\\A\\");
            foreach(string f in files)
            {
                DateTime time = File.GetCreationTime(f);
            }

        }
    }
}
