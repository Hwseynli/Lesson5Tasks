namespace Lesson5Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using Lesson5Tasks.Models;


class Program
{
    
    static void Main()
    {
        #region Task1
        //         int[] myNum = { 15, 8, 4, 13, 10, 11, 7, 3 };
        //         Task1.PringMergeSortArray(myNum);
        #endregion
        #region Task2
        ////Array i təyin edək:
        //int[] arr = Task2.ReadArray();
        ////Massivdəki elementlərin cəmini hesablayaq:
        //int totalSum = arr.CalculateSum();
        ////Cəmin tək və ya cüt olmasını yoxlayaq:
        //if (totalSum % 2 != 0)
        //{
        //    Task2.PrintResult(false, null, null);
        //}
        ////Hər iki alt massivin cəmi bu targetSum a bərabər olmalıdır.
        //int targetSum = totalSum / 2;
        //var (canPartition, subset1, subset2) = arr.CanPartitionArray(targetSum);

        //// Nəticəni yoxlayırıq
        //canPartition.PrintResult(subset1, subset2);

        #endregion
        #region Task3
        //Task3.PrintResult();
        #endregion
        #region Task4
        //Task4.PrintMinDest();
        #endregion
        #region Task5
        // İstifadəçidən input alaq
        Console.Write("Sətiri daxil edin: ");
        string s = Console.ReadLine().Trim();

        Console.Write("Lüğət sözlərini boşluqla ayıraraq daxil edin: ");
        string[] words = Console.ReadLine().Split(' ');

        Task5.PrintSentances(s,words);
        #endregion
    }
    
}
