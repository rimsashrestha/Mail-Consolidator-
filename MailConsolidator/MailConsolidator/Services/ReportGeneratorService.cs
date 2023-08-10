using System;
using System.IO;

namespace MailConsolidator.Services
{
	public class ReportGeneratorService
	{
        string sourcePath = @"/Users/rimsashrestha/Desktop/CombinedLetters/Output/CombinedOutput";

        public void GenerateReport()
		{
			Console.WriteLine(DateTime.Today.ToShortDateString() + " Report");
			Console.WriteLine("----------------------------------\n");
			string[] dirFiles = Directory.GetFiles(sourcePath, "*.txt", SearchOption.TopDirectoryOnly);
			Console.WriteLine("Number of Combined Letters: " + dirFiles.Length);

			foreach (string file in dirFiles)
			{
				FileInfo fileInfo = new FileInfo(file);
				string fileName = fileInfo.Name;
				Console.WriteLine(fileName.Substring(fileName.Length - 12, 8));
			}
		}
	}
}

//Combined00129080.txt