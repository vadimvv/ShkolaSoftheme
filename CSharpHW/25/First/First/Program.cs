using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Threading;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var newThread = new Thread(new ParameterizedThreadStart(Archive.ArchivateFolder));
            newThread.Start(path);
            

            Console.WriteLine("100%");
            Console.ReadLine();
        }

        static void GetDirectories(string path, string zipPath, int i)
        {
            var directories = Directory.GetDirectories(path);
            GetAllFilesFromDirectory(path, zipPath, i);

            foreach (var d in directories)
            {
                GetAllFilesFromDirectory(d, zipPath, i);

                GetDirectories(d, zipPath, i);
            }
        }


        static void GetAllFilesFromDirectory(string directory, string zipPath, int i)
        {
            string emptyFolder = @"C:\25_Test\EmptyFolder";
            Directory.CreateDirectory(emptyFolder);


            var files = Directory.GetFiles(directory);
            foreach (var f in files)
            {
                i++;
                FileInfo fi = new FileInfo(f);
                string extension = fi.Extension;
                string fileName = fi.Name.Remove(fi.Name.Length - extension.Length);


                string folderZip = zipPath;
                bool isExist = File.Exists(folderZip + @"\" + "(" + i + ")_" + fileName + ".zip");
                if (isExist)
                    while (File.Exists(folderZip + @"\" + "(" + i + ")_" + fileName + ".zip") == true)
                    {
                        i++;
                    }


                ZipFile.CreateFromDirectory(emptyFolder, folderZip + @"\" + "(" + i + ")_" + fileName + ".zip");

                using (ZipArchive archive = ZipFile.Open(zipPath + @"\" + "(" + i + ")_" + fileName + ".zip", ZipArchiveMode.Update))
                {
                    archive.CreateEntryFromFile(f, fileName + ".txt");
                }

            }
        }
    }
}


