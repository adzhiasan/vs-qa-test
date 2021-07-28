using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath=String.Empty;
            string pathDirectory=String.Empty;
            string[] fileEntries = Array.Empty<string>();

            ProcessArgs(args, ref inputFilePath, ref pathDirectory, ref fileEntries);

            CheckIntegrity(inputFilePath, pathDirectory, fileEntries);
        }

        /// <summary>
        /// Проверка целостности файлов.
        /// </summary>
        /// <param name="inputFilePath">Путь к файлу с именами файлов, алгоритмом хэширования и соответствующие им хэш-суммы.</param>
        /// <param name="pathDirectory">Путь к директориии, содержащей файлы для проверки.</param>
        /// <param name="fileEntries">Файлы, находящиеся в директории pathDirectory.</param>
        public static void CheckIntegrity(string inputFilePath, string pathDirectory, IList fileEntries)
        {
            using (StreamReader sr = new StreamReader(inputFilePath))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    string[] lineInfo = line.Split(" ");

                    Console.Write(lineInfo[0] + " ");

                    if (fileEntries.Contains(pathDirectory + "\\" + lineInfo[0]))
                    {
                        if (lineInfo[2] == GetHashSum(pathDirectory + "\\" + lineInfo[0], DefineHashAlgorithm(lineInfo[1])))
                            Console.WriteLine("OK");
                        else
                            Console.WriteLine("FAIL");
                    }
                    else
                    {
                        Console.WriteLine("NOT FOUND");
                    }
                    line = sr.ReadLine();
                }
            }
        }

        /// <summary>
        /// Инициализация объекта алгоритма хэширования исходя из его названия.
        /// </summary>
        /// <param name="algorithmName">Название алгоритма хэширования.</param>
        /// <returns>Возвращает объект алгоритма хэширования.</returns>
        public static HashAlgorithm DefineHashAlgorithm(string algorithmName)
        {
            switch (algorithmName)
            {
                case "md5":
                    return new MD5CryptoServiceProvider();

                case "sha256":
                    return SHA256.Create();

                case "sha1":
                    return SHA1.Create();

                default:
                    return null;
            }
        }

        /// <summary>
        /// Вычисление хэш-суммы указанного файла.
        /// </summary>
        /// <param name="inputFilePath">Путь к файлу.</param>
        /// <param name="hashAlgorithm">Алгоритм хэширования.</param>
        /// <returns>Возвращает хэш-сумму файла, находящегося по указанному пути.</returns>
        public static string GetHashSum(string inputFilePath, HashAlgorithm hashAlgorithm)
        {
            string result;
            using (FileStream fs = File.OpenRead(inputFilePath))
            {
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSum = hashAlgorithm.ComputeHash(fileData);
                result = BitConverter.ToString(checkSum).Replace("-", String.Empty).ToLower();
            }
            return result;
        }

        /// <summary>
        /// Обработка входных параметров и запись их в соответствующие переменные.
        /// </summary>
        /// <param name="args">Входные параметры.</param>
        /// <param name="inputFilePath">Путь к файлу с именами файлов, алгоритмом хэширования и соответствующие им хэш-суммы.</param>
        /// <param name="pathDirectory">Путь к директориии, содержащей файлы для проверки.</param>
        /// <param name="fileEntries">Файлы, находящиеся в директории pathDirectory.</param>
        public static void ProcessArgs(string[] args, ref string inputFilePath, ref string pathDirectory, ref string[] fileEntries)
        {
            foreach (string path in args)
            {
                if (File.Exists(path))
                    inputFilePath = path;

                else if (Directory.Exists(path))
                {
                    fileEntries = Directory.GetFiles(path);
                    pathDirectory = path;
                }

                else
                {
                    Console.WriteLine($"{path} is not a valid file or directory.");
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
    }
}
