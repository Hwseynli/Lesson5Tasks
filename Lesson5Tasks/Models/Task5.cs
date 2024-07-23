using System;
namespace Lesson5Tasks.Models
{
    /*s sətirini və wordDict sətirlərinin lüğətini nəzərə alaraq, hər sözün etibarlı lüğət sözü olduğu bir cümlə qurmaq üçün s-də boşluqlar əlavə edin. Bütün mümkün cümlələri qaytarın.*/
    public static class Task5
    {
        public static void PrintSentances(string s,string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                words[i].Trim();
            }
            // Lüğəti siyahıya çevirək
            List<string> wordDict = new List<string>(words);

            // Mümkün cümlələri əldə edək
            List<string> sentences = WordBreak(s, wordDict);

            // Nəticələri ekrana çıxaraq
            Console.WriteLine("Mümkün cümlələr:");
            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }
        static List<string> WordBreak(string s, List<string> wordDict)
        {
            // Nəticə siyahısı
            List<string> result = new List<string>();

            // Rekursiya üçün köməkçi metod
            WordBreakHelper(s, wordDict, "", result);

            return result;
        }
        static void WordBreakHelper(string s, List<string> wordDict, string currentSentence, List<string> result)
        {
            // Əgər s boşdursa, yəni s-ın hamısını uğurla işlədibsə
            if (string.IsNullOrEmpty(s))
            {
                result.Add(currentSentence.Trim());
                return;
            }

            // sətiri yoxlayaraq, mümkün cümlələri tapaq
            foreach (string word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    // Əgər s sözlə başlayırsa, həmin sözü cümləyə əlavə edək və qalan s üçün rekursiya çağıraq
                    string newSentence = currentSentence + word + " ";
                    string remainingString = s.Substring(word.Length);
                    WordBreakHelper(remainingString, wordDict, newSentence, result);
                }
            }
        }
    }
}