using System;
namespace Lesson5Tasks.Models
{
    /*int[] myNum = {15,8,4,13,10,11,7,3}; bu array-i Marge Sort alqoritmi ile 3,4,7,8,10,11,13,15 bu formaya getirin.*/
    public static class Task1
    {
        public static void PringMergeSortArray(int[] myNum)
        {
            Console.WriteLine("Sıralanmamış array: " + string.Join(", ", myNum));

            MergeSort(myNum, 0, myNum.Length - 1);

            Console.WriteLine("Sıralanmış array: " + string.Join(", ", myNum));
        }

        // MergeSort funksiyası array-i parçalayır və sıralayır
        public static void MergeSort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2; // Ortanı tapırıq

                MergeSort(array, leftIndex, middleIndex); // Sol yarını bölək və sıralayaq
                MergeSort(array, middleIndex + 1, rightIndex); // Sağ yarını bölək və sıralayaq

                Merge(array, leftIndex, middleIndex, rightIndex); // İki yarını birləşdirək və sıralayaq
            }
        }
        // Merge funksiyası iki hissəni birləşdirir və sıralayır
        public static void Merge(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            int leftArraySize = middleIndex - leftIndex + 1; // Sol yarının ölçüsü
            int rightArraySize = rightIndex - middleIndex; // Sağ yarının ölçüsü

            int[] leftArray = new int[leftArraySize]; // Sol yarı üçün müvəqqəti array
            int[] rightArray = new int[rightArraySize]; // Sağ yarı üçün müvəqqəti array

            // Sol array-i doldururuq
            for (int i = 0; i < leftArraySize; i++)
                leftArray[i] = array[leftIndex + i];

            // Sağ array-i doldururuq
            for (int i = 0; i < rightArraySize; i++)
                rightArray[i] = array[middleIndex + 1 + i];

            // Sol və sağ array-lərin indeksləri
            int iLeft = 0, iRight = 0;
            int k = leftIndex; // Əsas array-in indeksi

            // Sol və sağ array-lərin elementlərini müqayisə edirik və əsas array-ə yerləşdiririk
            while (iLeft < leftArraySize && iRight < rightArraySize)
            {
                if (leftArray[iLeft] <= rightArray[iRight])
                {
                    array[k] = leftArray[iLeft];
                    iLeft++;
                }
                else
                {
                    array[k] = rightArray[iRight];
                    iRight++;
                }
                k++;
            }

            // Sol array-də qalan elementləri əsas array-ə yerləşdiririk
            while (iLeft < leftArraySize)
            {
                array[k] = leftArray[iLeft];
                iLeft++;
                k++;
            }

            // Sağ array-də qalan elementləri əsas array-ə yerləşdiririk
            while (iRight < rightArraySize)
            {
                array[k] = rightArray[iRight];
                iRight++;
                k++;
            }
        }
    }
}