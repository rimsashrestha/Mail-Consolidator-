using System;
using MailConsolidator.Services;

namespace MailConsolidator
{
    class Program
    {
        static void Main(string[] args)
        {

            /*MailArchiveService mailArchive = new MailArchiveService();
            mailArchive.Archive(new DateTime(2023, 08, 08));*/

            LetterService letter = new LetterService();
            string path1 = @"/Users/rimsashrestha/Desktop/CombinedLetters/Input/Admission/20230808/admissions-00000002.txt";
            string path2 = @"/Users/rimsashrestha/Desktop/CombinedLetters/Input/Scholarship/20230808/scholarship-00000002.txt";
            letter.CombineTwoLetters(path1, path2);

            ReportGeneratorService report = new ReportGeneratorService();
            report.GenerateReport();
        }
    }
}

