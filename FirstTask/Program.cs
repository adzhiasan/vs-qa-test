using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + @"\CopyConfig.xml";

            try
            {
                foreach (FileToCopy file in GetFilesToCopy(path))
                {
                    file.Copy();
                    Console.WriteLine($"Файл {file.Name} был успешно скопирован из {file.SourcePath} в {file.DestinationPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Подготовка файлов для копирования в виде объектов класса <c>FilesToCopy</c>.
        /// </summary>
        /// <param name="path">Путь к xml-файлу.</param>
        /// <returns>Возвращает коллекцию объектов класса <c>FilesToCopy</c>.</returns>
        static List<FileToCopy> GetFilesToCopy(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            List<FileToCopy> filesToCopy = new List<FileToCopy>();

            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xNode in xRoot)
            {
                if (xNode.Attributes.Count > 0)
                {
                    filesToCopy.Add(new FileToCopy
                    {
                        Name = xNode.Attributes.GetNamedItem("file_name").Value,
                        SourcePath = xNode.Attributes.GetNamedItem("source_path").Value,
                        DestinationPath = xNode.Attributes.GetNamedItem("destination_path").Value,
                    });
                }
            }

            return filesToCopy;
        }
    }
}
