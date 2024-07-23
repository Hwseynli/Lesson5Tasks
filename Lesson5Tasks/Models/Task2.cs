using System;
namespace Lesson5Tasks.Models
{
    /*Tam ədədlər massivini cəmləri bərabər olan iki alt massivə bölmək mümkün olub-olmadığını yoxlayın. Mümkünsə, bu alt massivləri qaytarın. Məsələn: [6,13,8,1] array var əgər nəticə true olarsa o zaman -> [6,8] ve [1,13] cıxmaılıdır.*/
    public static class Task2
    {
        public static void PrintResult(this bool canPartition, List<int> subset1, List<int> subset2)
        {
            // Nəticəni yoxlayırıq
            if (canPartition)
            {
                Console.WriteLine("Bölmək mümkündür:");
                Console.WriteLine("Alt massiv 1: [" + string.Join(", ", subset1) + "]");
                Console.WriteLine("Alt massiv 2: [" + string.Join(", ", subset2) + "]");
            }
            else
            {
                Console.WriteLine("Bölmək mümkün deyil.");
            }
        }
        public static (bool, List<int>, List<int>) CanPartitionArray(this int[] arr, int targetSum)
        {
            //Array i 2 alt massivə bölək:
            List<int> subset1 = new List<int>();
            List<int> subset2 = new List<int>(arr);
            // Uyğun gələn elementləri əlavə edək:
            int currentSum = 0;
            foreach (int num in arr)
            {
                if (currentSum + num <= targetSum)
                {
                    currentSum += num;
                    subset1.Add(num);
                    subset2.Remove(num);

                    if (currentSum == targetSum)
                        break;
                }
            }
            // Nəticəni yoxlayırıq
            if (currentSum == targetSum)
                return (true, subset1, subset2);
            else
                return (false, null, null);
        }

        //Massivdəki elementlərin cəmini hesablayaq:
        public static int CalculateSum(this int[] arr)
        {
            int totalSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                totalSum += arr[i];
            }
            return totalSum;
        }
        //Arrayi istifadəçidən alaq:
        public static int[] ReadArray()
        {
            while (true)
            {
                Console.Write("Massivin elementlərini boşluq ilə ayıraraq daxil edin: ");
                var input = Console.ReadLine();
                var result = TryParseArray(input);

                if (result.Item1)
                    return result.Item2;

                Console.WriteLine("Xəta: Düzgün formatda ədədlər daxil edin.");
            }
            //Console.Write("Massivin elementlərini boşluq ilə ayıraraq daxil edin: ");
            //string input = Console.ReadLine();
            //return input.Split(' ').Select(int.Parse).ToArray();
        }
        private static (bool, int[]) TryParseArray(string input)
        {
            var parts = input.Split(' ');
            var numbers = new List<int>();
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int num))
                {
                    numbers.Add(num);
                }
                else
                {
                    return (false, null);
                }
            }
            return (true, numbers.ToArray());
        }
    }
}