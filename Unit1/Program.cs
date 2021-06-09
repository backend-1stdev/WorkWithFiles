using System;
using System.IO;

namespace WorkWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            DeleteFilesAndFolders();
        }

        static void DeleteFilesAndFolders()
        {
            Console.WriteLine("Date now: {0}", DateTime.Now);

            try
            {
                Console.WriteLine("Type directory");
                string dirName = @"c:\test\";
                /*dirName = Console.ReadLine();*/

                DirectoryInfo dirInfo = new DirectoryInfo(dirName ?? string.Empty);

                if (dirInfo.Exists)
                {
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        var lastAccess = DateTime.Now - file.LastAccessTime;

                        if (lastAccess > TimeSpan.FromMinutes(1))
                        {
                            file.Delete();
                        }
                        else
                        {
                            Console.WriteLine("Files: {0} LastAccessTime: {1} Interval: {2}", file, file.LastAccessTime,
                                lastAccess);
                        }
                    }

                    foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                    {
                        var lastAccess = DateTime.Now - dir.CreationTime;

                        if (lastAccess > TimeSpan.FromMinutes(1))
                        {
                            dir.Delete();
                        }
                        else
                        {
                            Console.WriteLine("Folder: {0} LastAccessTime: {1} Interval: {2}", dir, dir.LastAccessTime,
                                lastAccess);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong way");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception");
                throw;
            }
        }
    }
}