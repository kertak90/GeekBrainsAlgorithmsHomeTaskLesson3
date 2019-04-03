using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_2
{
    class Program
    {
        static int arraySize;
        static DateTime start, end;

        static void Main(string[] args)
        {
            arraySize = 100000;
            int TaskNumber = 0;
            int[] myArr = new int[arraySize];// = { 1, 4, 3, 8, 2, 9, 6, 5, 7, 10 };
            int[] myArr1;
            int[] myArr2;
            int[] myArr3;
            int[] myArr4;
           
            initArray(myArr, arraySize);            

            do
            {
                Console.Clear();
                //PrintArr(myArr);
                menu();
                TaskNumber = Convert.ToInt16(Console.ReadLine());
                int index = 0;
                Console.Beep();
                switch (TaskNumber)
                {
                    case 1:
                        myArr1 = (int[])myArr.Clone();
                        BubleSort(myArr1, arraySize);
                        //PrintArr(myArr1);
                        Console.ReadLine();
                        break;
                    case 2:
                        myArr2 = (int[])myArr.Clone();
                        ShakerSort(myArr2, arraySize);                        
                        Console.ReadLine();
                        break;
                    case 3:
                        myArr3 = (int[])myArr.Clone();
                        SelectSort(myArr3, arraySize);
                        //PrintArr(myArr3);
                        Console.ReadLine();
                        break;
                    case 4:
                        myArr3 = (int[])myArr.Clone();
                        SelectSort(myArr3, arraySize);
                        BinarySearch(myArr3, arraySize);
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!!!\n");
                        break;
                }
            } while (TaskNumber != 0);
            Console.ReadLine();        

        }

        static void menu()
        {
            Console.WriteLine("Введите номер задачи!!");
            Console.WriteLine("1 - BubleSort!!");
            Console.WriteLine("2 - ShakerSort!!");
            Console.WriteLine("3 - SelectionSort!!");
            Console.WriteLine("4 - SelectionSort с Бинарным поиском!!");
        }

        static void PrintArr(int[] Arr)
        {
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write(Arr[i] + " ");                
            }
            Console.WriteLine();
        }

        static void initArray(int[] Array, int len)
        {
            Random myRand = new Random();
            int i = 0;
            int count = 0;
            int temp = 0;
            
            int j = 0;
            for (i = 0; i < len; i++)
            {
                temp = myRand.Next(1, len+1);
                j = 0;
                while (j < count)
                {
                    if (Array[j] == temp)
                    {
                        temp = myRand.Next(1, len + 1);
                        j = -1;
                    }
                    j++;
                }                
                Array[i] = temp;                
                count++;
            }
        }

        static void BubleSort(int[] Arr, int len)
        {            
            long SwapCount = 0;
            start = DateTime.Now;
            int temp;
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (Arr[j] < Arr[i])
                    {
                        SwapCount++;
                        temp = Arr[i];
                        Arr[i] = Arr[j];
                        Arr[j] = temp;
                    }
                }
            }
            end = DateTime.Now;
            TimeSpan dT = end-start;
            Console.WriteLine("Время работы SelectSort: {0:f10} секунд", (float)dT.Ticks/10000000);   
            Console.WriteLine("Количество операций: {0}", SwapCount);
        }

        static void ShakerSort(int[] Arr, int len)
        {
            long SwapCount = 0;
            int swapFlag = 0;
            start = DateTime.Now;
            int LeftMark = 0, RightMark = len - 1;
            int temp;
            while (LeftMark <= RightMark)
            {
                swapFlag = 0;
                for (int i = RightMark; i > LeftMark; i--)
                {
                    if (Arr[i - 1] > Arr[i])
                    {
                        swapFlag = 1;
                        SwapCount++;
                        temp = Arr[i - 1];
                        Arr[i - 1] = Arr[i];
                        Arr[i] = temp;
                    }
                }
                LeftMark++;
                for (int i = LeftMark; i <= RightMark; i++)
                {
                    if (Arr[i - 1] > Arr[i])
                    {
                        swapFlag = 1;
                        SwapCount++;
                        temp = Arr[i - 1];
                        Arr[i - 1] = Arr[i];
                        Arr[i] = temp;
                    }
                }
                RightMark--;
                if (swapFlag == 0) break;
            }
            //PrintArr(Arr);
            end = DateTime.Now;
            TimeSpan dT = end - start;
            Console.WriteLine("Время работы SelectSort: {0:f10} секунд", (float)dT.Ticks / 10000000);
            Console.WriteLine("Количество операций: {0}", SwapCount);
        }

        static void SelectSort(int[] Arr, int len)
        {
            long SwapCount = 0;
            int j = 0;              
            int temp = 0;
            int minIndex = 0;
            start = DateTime.Now;
            for (int i = 0; i < len; i++)
            {
                minIndex = i;
                for (int k = i + 1; k < len; k++)
                {
                    if (Arr[k]< Arr[minIndex])
                    {
                        SwapCount++;
                        minIndex = k;
                    }
                }
                
                temp = Arr[i];
                Arr[i] = Arr[minIndex];
                Arr[minIndex] = temp;
            }
            end = DateTime.Now;
            TimeSpan dT = end - start;
            Console.WriteLine("Время работы SelectSort: {0:f10} секунд", (float)dT.Ticks / 10000000);
            Console.WriteLine("Количество операций: {0}", SwapCount);
        }

        static void BinarySearch(int[] Arr, int len)
        {
            int count = 0;
            int searchValue;
            int ValueFinded = 0;
            Console.WriteLine("Введите число для поиска:\n");
            searchValue = Convert.ToInt16(Console.ReadLine());
            int lowIndex = 0;
            int HighIndex = len - 1;
            int currentIndex = 0;

            while (lowIndex < HighIndex)
            {
                count++;
                currentIndex = (HighIndex + lowIndex) / 2;
                if (Arr[currentIndex] == searchValue)
                {
                    ValueFinded = 1;
                    break;
                }
                if (Arr[currentIndex] > searchValue)
                {
                    HighIndex = currentIndex - 1;
                }
                if (Arr[currentIndex] < searchValue)
                {                   
                    lowIndex = currentIndex + 1;
                }
            }

            if (ValueFinded == 1)
            {
                Console.WriteLine("Значение найдено по индексу: {0}", currentIndex);
                Console.WriteLine("Значение найдено за {0} операции(й).", count);
            }   
            if(ValueFinded == 0)
            {
                Console.WriteLine("Значение Не найдено в массиве!!!");
            }
        }
    }
}
