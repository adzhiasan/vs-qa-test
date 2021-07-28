using System;
using System.IO;

namespace FirstTask
{
    public class FileToCopy
    {
        public string Name { get; set; }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }

        public void Copy()
        {
            File.Copy(Path.Combine(SourcePath, Name), Path.Combine(DestinationPath, Name), true);
        }    
    }
}
