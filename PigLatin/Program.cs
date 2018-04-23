using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {    
            
            Console.WriteLine("enter a word");
            string input = Console.ReadLine();
            Console.WriteLine(TranslateWord(input.ToLower()));
            Console.WriteLine("enter a sentance");
            string input2 = Console.ReadLine();
            Console.WriteLine(Sentence(input2));



            // leave this command at the end so your program does not close automatically
            // Console.ReadLine();

        }

        static string TranslateWord(string word)
        {
            int vowelIndex = word.IndexOfAny(new char[] {'a', 'e', 'i', 'o', 'u'});
            string firstPart = word.Substring(0, vowelIndex);
            string restWord = word.Substring(vowelIndex);
            return restWord + firstPart + "ay";
        }

        
        static string Sentence(string word)
        {   
            
		    string[] words = word.Split(' ');
		    string[] upperCaseWords = new string[5];
		    for (int i = 0; i < words.Length; i++)
		    {
			upperCaseWords[i] = TranslateWord(words[i]).ToUpper();
		    }
		    string upperCaseString = String.Join(" ", upperCaseWords);
		    return upperCaseString;
        }
	
        
    }

}
