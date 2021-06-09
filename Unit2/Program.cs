using System;
using System.Linq;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:/test/");

            if (dirInfo.Exists)
            {
                long sizeOfDir = DirectorySize(dirInfo, true);
                Console.WriteLine("Directory size: {0} Bytes", sizeOfDir);
            }

            else
            {
                Console.WriteLine("Wrong way");
            }
        }

        static long DirectorySize(DirectoryInfo dInfo, bool includeSubDir)
        {
            long totalSize = dInfo.EnumerateFiles()
                .Sum(file => file.Length);
            if (includeSubDir)
            {
                totalSize += dInfo.EnumerateDirectories()
                    .Sum(dir => DirectorySize(dir, true));
            }

            return totalSize;
        }
    }
}