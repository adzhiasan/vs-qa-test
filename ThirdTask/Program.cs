using System;
using System.IO;
using System.Management;

namespace ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCase testCase1 = new()
            {
                tc_id = 1,
                Name = "Список файлов",
                prep = TimeCheck,
                run = DisplayListOfFiles
            };

            TestCase testCase2 = new()
            {
                tc_id = 2,
                Name = "Случайный файл",
                prep = RamVolumeCheck,
                run = CreateRandomFile,
                clean_up = CleanUpRandomFile
            };

            testCase1.execute();
            testCase2.execute();
        }

        /// <summary>
        /// Проверка текущего системного времени, заданного как целое количество секунд от начала эпохи Unix, на кратность двум.
        /// </summary>
        public static void TimeCheck()
        {
            if (ConvertToUnixTimestamp(DateTime.Now) % 2 != 0)
                throw new Exception("Preparation failed.");
        }

        /// <summary>
        /// Вывод списка файлов из домашней директории.
        /// </summary>
        public static void DisplayListOfFiles()
        {
            string[] fileEntries = Array.Empty<string>();
            string path = @"C:\Users\UserName";

            if (Directory.Exists(path))
                fileEntries = Directory.GetFiles(path);

            foreach (var item in fileEntries)
                Console.WriteLine(item);
        }

        /// <summary>
        /// Проверка объёма оперативной памяти машины.
        /// </summary>
        public static void RamVolumeCheck()
        {
            if (GetRamVolulmeInfo() < 1)
                throw new Exception("Preparation failed.");
        }

        /// <summary>
        /// Создание файла test размером 1024 КБ.
        /// </summary>
        public static void CreateRandomFile()
        {
            string path = @"D:\test.txt";
            ulong size = 1024000;

            try
            {
                using (FileStream fileStream = File.Create(path))
                {
                    byte[] info = new byte[size];
                    fileStream.Write(info, 0, info.Length);
                }
            }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Удаление файла test.
        /// </summary>
        public static void CleanUpRandomFile()
        {
            string path = @"D:\test.txt";

            try
            {
                File.Delete(path);
        }

            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Получение объёма оперативной памяти машины. 
        /// </summary>
        /// <returns>Возвращает объём оперативной памяти в ГБ.</returns>
        public static ulong GetRamVolulmeInfo()
        {
            var query = "SELECT Capacity FROM Win32_PhysicalMemory";
            var searcher = new ManagementObjectSearcher(query);
            ulong summary = 0;
            foreach (var WniPART in searcher.Get())
            {
                var capacity = Convert.ToUInt64(WniPART.Properties["Capacity"].Value);
                var capacityKB = capacity / 1024;
                var capacityMB = capacityKB / 1024;
                var capacityGB = capacityMB / 1024;
                summary += capacityGB;
            }
            return summary;
        }

        /// <summary>
        /// Полцчение целого количества секунд от начала эпохи Unix до заданного времени.
        /// </summary>
        /// <param name="date">Заданное время.</param>
        /// <returns>Возвращает целое количество секунд от начала эпохи Unix до заданного времени.</returns>
        public static int ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return (int)Math.Floor(diff.TotalSeconds);
        }
    }
}
