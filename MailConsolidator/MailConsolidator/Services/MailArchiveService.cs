using System;
using System.IO;
using System.IO.Compression;

namespace MailConsolidator.Services
{
    public class MailArchiveService
    {
        string sourcePath = @"/Users/rimsashrestha/Desktop/CombinedLetters/Input";
        string destPath = @"/Users/rimsashrestha/Desktop/CombinedLetters/Archive";
      
        public void Archive(DateTime date)
        {
            string formattedDate = date.Date.ToString("yyyyMMdd");

            //read files and archives from input to archive folder
            using (StreamWriter streamWriter = File.CreateText("ArchivedFile" + formattedDate + ".txt"))
            {
                string[] directories = Directory.GetDirectories(sourcePath, formattedDate, SearchOption.AllDirectories);

                List<FileInfo> files = new List<FileInfo>();

                foreach (string directory in directories)
                {

                    string[] dirFiles = Directory.GetFiles(directory, "*.txt", SearchOption.TopDirectoryOnly);
                    foreach (string file in dirFiles)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        files.Add(fileInfo);
                    }

                }
                   CreateZipFile(files, destPath + $"/{formattedDate}.zip");

            }
        }

        //Creates a Zip file in Archive Folder
        private static void CreateZipFile(IEnumerable<FileInfo> files, string archiveName)
        {
            using (var stream = new FileStream(archiveName ,FileMode.CreateNew))
            {
                using (ZipArchive archive = new ZipArchive(stream, System.IO.Compression.ZipArchiveMode.Create))
                {
                    foreach (var item in files)
                    {
                        archive.CreateEntryFromFile(item.FullName, item.Name, CompressionLevel.Optimal);
                    }
                }
            }
            
        }

    }
}

