using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
            // your code goes here
            var word = "crazy";
            var vowelIndex = -1; // Set it to assume there are no vowels

            if ( ( word.IndexOf('a') > -1 && word.IndexOf('a') < vowelIndex ) || vowelIndex == -1 ) {
            vowelIndex = word.IndexOf('a');
            }

            if ( ( word.IndexOf('e') > -1 && word.IndexOf('e') < vowelIndex ) || vowelIndex == -1 ) {
            vowelIndex = word.IndexOf('e');
            }

            if ( ( word.IndexOf('i') > -1 && word.IndexOf('i') < vowelIndex ) || vowelIndex == -1 ) {
            vowelIndex = word.IndexOf('i');
            }

            if ( ( word.IndexOf('o') > -1 && word.IndexOf('o') < vowelIndex ) || vowelIndex == -1 ) {
            vowelIndex = word.IndexOf('o');
            }

            if ( ( word.IndexOf('u') > -1 && word.IndexOf('u') < vowelIndex ) || vowelIndex == -1 ) {
            vowelIndex = word.IndexOf('u');
            }

            if ( ( word.IndexOf('y') > -1 && word.IndexOf('y') < vowelIndex ) || vowelIndex == -1 ) {
            vowelIndex = word.IndexOf('y');
            }

            string firstPart = word.Substring(0, vowelIndex);
            string restWord = word.Substring(vowelIndex);
            Console.WriteLine( firstPart + restWord + "ay");      
            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }


        
        public static string TranslateWord(string word)
        {


            return word;
        }
    }
}
