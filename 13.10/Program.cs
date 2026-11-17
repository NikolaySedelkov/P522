using System;
using System.Collections;
using System.IO;
using System.Text;

namespace _13._10
{
    internal class Program
    {
        static void Directories(DirectoryInfo currentDirectory)
        {
            Console.Clear();
            Console.WriteLine(currentDirectory.FullName);
            Console.WriteLine("---------------------------\n");

            DirectoryInfo[] subDirectories = currentDirectory.GetDirectories();

            for (int i = 0; i < subDirectories.Length; ++i)
            {
                DirectoryInfo directory = subDirectories[i];
                Console.WriteLine($"{i}.\t{directory.Name}");
            }
            Console.WriteLine($"-1.\tНазад");

            FileInfo[] files = currentDirectory.GetFiles();
            if(files.Length > 0)
            {
                Console.WriteLine("Файлы:");
                for(int i = 0; i < files.Length; ++i)
                {
                    FileInfo file = files[i];
                    Console.WriteLine($"{i + 1}.\t{file.Name}");
                }

                Console.Write("С чем хотите продолжить работать?(F(ile)/D(irectory)): ");
                char changeMode = Console.ReadLine()[0];

                if(changeMode == 'F')
                {
                    Console.Write("Выберите файл: ");
                    int changeFileIndex;
                    do
                    {
                        changeFileIndex = int.Parse(Console.ReadLine());
                    } while (changeFileIndex < -1 || changeFileIndex >= files.Length);

                    FileInfo changeFile = files[changeFileIndex];

                    FileStream fileReader = changeFile.OpenRead();

                    byte[] data = new byte[100];
                    while(
                        fileReader.Read(data, 0, data.Length) != 0
                        )
                    {
                        Console.WriteLine(Encoding.ASCII.GetString(data));
                    }
                }
            }

            Console.WriteLine("====================\n");

            Console.Write("Выберите папку: ");
            int changeDirectoryIndex;
            do
            {
                changeDirectoryIndex = int.Parse(Console.ReadLine());
            } while (changeDirectoryIndex < -1 || changeDirectoryIndex >= subDirectories.Length);

            if (changeDirectoryIndex != -1)
            {
                Directories(subDirectories[changeDirectoryIndex]);
            } else
            {
                Directories(currentDirectory.Parent);
            }

            
        }

        static void Main(string[] args)
        {
            const uint BYTE_IN_MBBYTE = 1_048_576;

            DriveInfo[] drivers = DriveInfo.GetDrives();

            for(int i = 0; i < drivers.Length; ++i)
            {
                DriveInfo driveInfo = drivers[i];
                Console.WriteLine($"#{i}\t{driveInfo.Name}({driveInfo.DriveFormat})");

                float totalVolumeMb = (float)driveInfo.TotalSize / BYTE_IN_MBBYTE;
                float freeVolumeMb = (float)driveInfo.TotalFreeSpace / BYTE_IN_MBBYTE;
                Console.WriteLine($"{freeVolumeMb}/{totalVolumeMb}");
                Console.WriteLine("=================\n");
            }

            Console.Write("Выберите диск: ");
            int changeDriveIndex = int.Parse(Console.ReadLine());

            DriveInfo changeDrive = drivers[changeDriveIndex];

            Directories(new DirectoryInfo(changeDrive.Name));
        }
    }
}
