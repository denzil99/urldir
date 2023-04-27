using System;
using System.IO;

namespace urldir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке, которую желаете удалить: ");
            string pathTemp = Console.ReadLine();
            string path = @pathTemp;

            while (!Directory.Exists(path))
            {
                Console.WriteLine("Вы ввели путь неправильно");
                Console.Write("Введите путь еще раз - ");
                path = $"{Console.ReadLine()}";
            }
            long size = DirectorySize(path);
            Console.WriteLine(size);
            Console.ReadKey();

        }


        public static long DirectorySize(string path)
        {

            DirectoryInfo dir = new DirectoryInfo(path);
            long size = 0;
            try
            {
                FileInfo[] fis = dir.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            try
            {

                DirectoryInfo[] dis = dir.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirectorySize(di.Name);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return (size);

        }
    }
}
