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
        
    }

}
