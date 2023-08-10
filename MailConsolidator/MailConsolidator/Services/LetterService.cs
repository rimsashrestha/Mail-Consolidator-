using System;
using System.IO;
using MailConsolidator.Interfaces;

namespace MailConsolidator.Services
{
	public class LetterService : ILetterService
	{
        string destPath = @"/Users/rimsashrestha/Desktop/CombinedLetters/Output/CombinedOutput";

     	//Combines two letters if the student IDs match
        public void CombineTwoLetters(string inputFile1, string inputFile2)
        {
            string file1StudentID = inputFile1.Substring(inputFile1.Length - 12);
            string file2StudentID = inputFile2.Substring(inputFile2.Length - 12);

            if (file1StudentID == file2StudentID){
                string resultFile = destPath + $"/Combined{file1StudentID}";
                CombineTwoLetters(inputFile1, inputFile2, resultFile);
            }
        }

        public void CombineTwoLetters(string inputFile1, string inputFile2, string resultFile)
        {
            using (var stream = new FileStream(resultFile, FileMode.CreateNew))
            {
                File.WriteAllText(resultFile, File.ReadAllText(inputFile1) + File.ReadAllText(inputFile2));

            }
        }
    }
}

