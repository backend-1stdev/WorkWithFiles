using System;
using System.Linq;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirName = @"c:/test/";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName ?? string.Empty);

            if (dirInfo.Exists)
            {
                long sizeOfDir = DirectorySize(dirInfo, true);
                Console.WriteLine("Directory size: {0} Bytes", sizeOfDir);
                Console.WriteLine("Delete size: {0} Bytes", sizeOfDir);
                
                long sizeOfDir1 = DirectorySize(dirInfo, true);
                Console.WriteLine("Final directory size: {0} Bytes", sizeOfDir1);
            }

            else
            {
                Console.WriteLine("Wrong way");
            }
        }

        static long DirectorySize(DirectoryInfo dirInfo, bool includeSubDir)
        {
            long totalSize = dirInfo.EnumerateFiles()
                .Sum(file => file.Length);
            if (includeSubDir)
            {
                totalSize += dirInfo.EnumerateDirectories()
                    .Sum(dir => DirectorySize(dir, true));

                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    file.Delete();
                }
                
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    dir.Delete();
                }
                
            }

            return totalSize;
        }

       
    }
}