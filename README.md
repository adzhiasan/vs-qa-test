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
Для начала необходимо создать конфигурационный файл по примеру с названием CopyConfig.xml. Поиск производится по пути: /QAAutomationTest/FirstTask/bin/Debug/net5.0/CopyConfig.xml. Путь для поиска файла, а также его название, можно изменить в переменной path в методе Main.
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
