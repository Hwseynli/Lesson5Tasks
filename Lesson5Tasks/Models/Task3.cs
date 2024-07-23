using System;
using System.Text;

namespace Lesson5Tasks.Models
{
    /*Word1 və word2 iki sətri var, word1-i word2-ə çevirmək üçün tələb olunan minimum əməliyyat sayını tapın. Əməliyyatlara daxiletmə, silmə və əvəzetmə daxildir. */
    public static class Task3
    {
        public static void PrintResult()
        {
            // İstifadəçidən iki sətir daxil etməyi istəyirik
            Console.Write("Birinci sözü daxil edin: ");
            string word1 = Console.ReadLine().Capitalize();

            Console.Write("İkinci sözü daxil edin: ");
            string word2 = Console.ReadLine().Capitalize();

            int result = CalculateLevenshteinDistance(word1, word2);
            Console.WriteLine($"'{word1}' sözünü '{word2}' sözünə çevirmək üçün minimum əməliyyat sayı : {result}");
        }
        //Levenşteyn alqoritmidir
        static int CalculateLevenshteinDistance(string word1, string word2)
        {
            int length1 = word1.Length;
            int length2 = word2.Length;
            int[,] wordArr = new int[length1 + 1, length2 + 1];

            // wordArr matrisini dolduraq:
            for (int i = 0; i <= length1; i++)
            {
                for (int j = 0; j <= length2; j++)
                {
                    // word1 boşdursa, word2-nin bütün simvollarını daxil edək
                    if (i == 0)
                    {
                        wordArr[i, j] = j;
                    }
                    // word2 boşdursa, word1-in bütün simvollarını silək
                    else if (j == 0)
                    {
                        wordArr[i, j] = i;
                    }
                    // Əgər simvollar eynidirsə, heç bir əməliyyat lazım deyil
                    else if (word1[i - 1] == word2[j - 1])
                    {
                        wordArr[i, j] = wordArr[i - 1, j - 1];
                    }
                    else
                    {
                        wordArr[i, j] = 1 + Math.Min(wordArr[i - 1, j - 1], // Əvəz edir
                                                Math.Min(wordArr[i - 1, j], // Silir
                                                         wordArr[i, j - 1])); // Daxiledir
                    }
                }
            }
            return wordArr[length1, length2];
        }
        //String in boşluqlarını silir və ilk hərfi böyüdüb, digər hərfləri kiçildir.
        public static string Capitalize(this string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;

            text = text.Trim();
            string[] arr = text.Split(" ");
            StringBuilder newstr = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length > 0)
                {
                    string firstChar = arr[i][0].ToString().ToUpper();
                    string rest = arr[i].Substring(1).ToLower();
                    newstr.Append($"{firstChar}{rest} ");
                }
            }
            return newstr.ToString().Trim();
        }
    }
}

