using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace Lesson5Tasks.Models
{
    /*Dinamik Proqramlaşdırmadan istifadə edərək Traveling Salesman Problem (TSP)  həll edin.
Şəhərlər toplusunu və hər bir cüt şəhər arasındakı məsafələri nəzərə alaraq, hər bir şəhərə tam bir dəfə baş çəkən və başlangıç şəhərinə qayıdan mümkün olan ən qısa rotanı tapın.   */
    public static class Task4
    {
        static int[,] dp;
        static int n;
        static int[,] dist;
        public static void PrintMinDest()
        {
            n = ReadInteger("Şəhərlərin sayını daxil edin: ");
            while (n == 0)
            {
                Console.WriteLine("Sıfırdan böyük ədəd daxil edin!!!");
                n = ReadInteger("Şəhərlərin sayını daxil edin: ");
            }
            // Məsafə matrisini təyin edək
            dist = new int[n, n];
            Console.WriteLine("Məsafə matrisini təyin edin:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dist[i, j] = Task4.ReadInteger($"Məsafə ({i},{j}): ");
                }
            }
            // Dinamik proqramlaşdırma üçün tablo
            dp = new int[1 << n, n];

            // Tablonu əvvəlcədən dolduraq
            for (int i = 0; i < (1 << n); i++)
                for (int j = 0; j < n; j++)
                    dp[i, j] = -1;

            // Start nöqtəsi olaraq sıfırı seçək
            int result = TSP(1, 0);

            Console.WriteLine("Ən qısa yolun uzunluğu: " + result);
        }
        //Tsp alqoritmi
        static int TSP(int mask, int pos)
        {
            // Bütün şəhərlər ziyarət edilibsə və start nöqtəsinə qayıdarıqsa
            if (mask == (1 << n) - 1)
                return dist[pos, 0];

            // Əvvəlcədən hesablama olubsa, təkrar istifadə edək
            if (dp[mask, pos] != -1)
                return dp[mask, pos];

            int ans = int.MaxValue;

            // Bütün şəhərləri yoxlayaq
            for (int city = 0; city < n; city++)
            {
                // Şəhər ziyarət edilməmişsə
                if ((mask & (1 << city)) == 0)
                {
                    int newAns = dist[pos, city] + TSP(mask | (1 << city), city);
                    ans = Math.Min(ans, newAns);
                }
            }

            // Tablonu dolduraq
            return dp[mask, pos] = ans;
        }
        // İstifadəçidən tam ədədi oxuyaq və təsdiqləyək
        public static int ReadInteger(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                // Rəqəm olub-olmadığını yoxlayaq
                if (int.TryParse(input, out value) && value >= 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Xətalı giriş! Xahiş edirəm, düzgün bir rəqəm daxil edin.");
                }
            }
        }
    }
}