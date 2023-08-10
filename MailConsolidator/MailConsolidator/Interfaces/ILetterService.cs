using System;
namespace MailConsolidator.Interfaces
{
	public interface ILetterService
	{
        void CombineTwoLetters(string inputFile1, string inputFile2, string resultFile);
    }
}

