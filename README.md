# vs-qa-test
Repository for Veeam Software Junior Developer in QA test.
Все задачи были выполнены на языке *C#*. Платформа *Microsoft .Net Core* 5.0.
## First Task
### Краткое описание
В данном проекте была реализована программа, осуществляющая копирование файлов в соответствии с конфигурационным файлом. Конфигурационный файл имеет формат *xml*. Для каждого файла в конфигурационном файле указано его имя, исходный путь и путь, по которому файл требуется скопировать.  
Пример *xml*-файла:  
```xml
<?xml version="1.0" encoding="utf-8" ?>
<config>
  <file
    source_path ="C:\Windows\system32"
    destination_path="C:\Program files"
    file_name="kernel32.dll"
  />
  <file
  source_path ="/var/log"
  destination_path="/etc"
  file_name="server.log"
  />
</config>
```  
### Подготовка и запуск 
Для начала необходимо создать конфигурационный файл по примеру с названием <code>CopyConfig.xml</code>. Поиск производится по пути: <code>/QAAutomationTest/FirstTask/bin/Debug/net5.0/CopyConfig.xml</code>. Путь для поиска файла, а также его название, можно изменить в переменной path в методе Main.
```cs
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + @"\CopyConfig.xml";
            
            // изменение пути к файлу и его название
            path = "your path" + "your configuration file name"; 
            
            /*
            
            */            
        }
```
Далее необходимо запустить решение. Сообщения в консоли укажут на успешное копирование файла либо на ошибку.  
## Second Task
### Краткое описание
Дан файл, содержащий имена файлов, алгоритм хэширования (один из <code>MD5/SHA1/SHA256</code>) и соответствующие им хэш-суммы, вычисленные по соответствующему алгоритму и указанные в файле через пробел. В данном проекте реализована программа, читающая данный файл и проверяющая целостность файлов.  
Пример файла:
```
file_01.bin md5 aaeab83fcc93cd3ab003fa8bfd8d8906
file_02.bin md5 6dc2d05c8374293fe20bc4c22c236e2e
file_03.bin md5 6dc2d05c8374293fe20bc4c22c236e2e
file_04.txt sha1 da39a3ee5e6b4b0d3255bfef95601890afd80709
```
Вызов  осуществляется через командную строку с передачей двух аргументов: путь к файлу и путь к директории с файлами.
```
<program> <path to the input file> <path to the directory containing the files to check>
```
### Подготовка и запуск
