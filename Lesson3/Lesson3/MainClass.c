#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <locale.h>
#include <time.h>

//Пинарин Олег
//1. Попробовать оптимизировать пузырьковую сортировку.Сравнить количество операций сравнения оптимизированной и не оптимизированной программы.Написать функции сортировки, которые возвращают количество операций.
//2. *Реализовать шейкерную сортировку.
//3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив.Функция возвращает индекс найденного элемента или - 1, если элемент не найден.
//4. *Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической сложностью алгоритма.
//Записывайте в начало программы условие и свою фамилию.Все решения создавайте в одной программе.Со звёздочками выполняйте в том случае, если вы решили задачи без звёздочек.

void menu();
void PrintArr(int*);
void initArray(int*, int);
int* BubleSort(int*, int);
int* ShakerSort(int*, int);
int* SelectSort(int*, int);
void BinarySearch(int*, int);
int arraySize;
time_t start, end;

int main()
{
	setlocale(LC_ALL, "Rus");
	int TaskNumber = 0;
	
	int myArr[10] = {1, 4, 3, 8, 2, 9, 6, 5, 7, 10};
	int myArr1[10];
	int myArr2[10];
	int myArr3[10];
	int myArr4[10];
	arraySize = 10;
	initArray(&myArr, arraySize);
	PrintArr(myArr);
	
	
	do
	{
		system("cls");
		PrintArr(myArr);
		menu();
		scanf("%i", &TaskNumber);
		int index = 0;
		switch (TaskNumber)
		{
		case 1:	
			myArr1[10] = &myArr;
			BubleSort(myArr1, arraySize);
			PrintArr(myArr1);
			system("pause");
			break;
		case 2:
			myArr2[10] = myArr;
			ShakerSort(myArr2, arraySize);
			PrintArr(myArr2);
			system("pause");
			break;
		case 3:
			myArr3[10] = myArr;
			SelectSort(myArr3, arraySize);
			PrintArr(myArr3);
			system("pause");
			break;
		case 4:
			myArr4[10] = myArr;
			BinarySearch(myArr3, arraySize);
			break;
		default:
			printf("Неверный ввод!!!\n");
		}
	} while (TaskNumber != 0);
	system("pause");
	return 0;
}

void menu()
{
	printf("Введите номер задачи\n");
}

void PrintArr(int *Arr)
{
	for (int i =0;i< arraySize;i++)
	{
		printf("%i ", Arr[i]);
	}
	printf("\n");
}

void initArray(int Array[], int len)
{	
	int i = 0;
	int count = 0;
	int temp = 0;
	srand(time(NULL));
	int j = 0;
	for (i=0;i<len;i++)
	{
		temp = 1 + rand() % len;
		j = 0;
		while(j<count)
		{
			if (Array[j]==temp)
			{
				temp = 1 + rand() % len;
				j = -1;				
			}
			j++;
		}
		/**Array = temp;
		Array++;*/
		Array[i] == temp;
		srand(time(NULL));
		count++;
	}	
}

int* BubleSort(int *Arr[], int len)
{		
	int SwapCount = 0;
	start = time(NULL);
	int temp;
	for (int i = 0; i < len; i++)
	{		
		for (int j = i+1; j < len - 1; j++)
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
	end = time(NULL);
	float dT = difftime(end, start);	
	printf("Время работы BubleSort: %f секунд.\n", difftime(end, start));
	printf("Количество операций: %i\n", SwapCount);
	return Arr;
}

int* ShakerSort(int *Arr, int len)
{
	int SwapCount = 0;
	start = time(NULL);
	int LeftMark = 0, RightMark = len - 1;
	int temp;
	while (LeftMark<=RightMark)
	{
		for (int i = RightMark; i >= LeftMark; i--)
		{
			if (Arr[i-1]>Arr[i]) 
			{
				SwapCount++;
				temp = Arr[i-1];
				Arr[i-1] = Arr[i];
				Arr[i] = temp;
			}
		}
		LeftMark++;
		for (int i = LeftMark; i <= RightMark; i++)
		{
			if (Arr[i - 1] > Arr[i])
			{
				SwapCount++;
				temp = Arr[i - 1];
				Arr[i - 1] = Arr[i];
				Arr[i] = temp;
			}
		}
		RightMark--;
	}
	end = time(NULL);
	float dT = difftime(end, start);
	printf("Время работы ShakerSort: %f секунд.\n", difftime(end, start));
	printf("Количество операций: %i\n", SwapCount);
}

int* SelectSort(int *Arr, int len)
{
	int SwapCount = 0;
	int j = 0;				//Индекс текущего элемента
	int temp = 0;
	start = time(NULL);
	for (int i=0; i<len; i++)
	{
		for (int k = i+1; k < len; k++)
		{
			if (Arr[i] > Arr[k])
			{
				SwapCount++;
				temp = Arr[i];
				Arr[i] = Arr[k];
				Arr[k] = temp;
			}
		}
	}

	end = time(NULL);
	float dT = difftime(end, start);
	printf("Время работы SelectSort: %f секунд.\n", difftime(end, start));
	printf("Количество операций: %i\n", SwapCount);
}

void BinarySearch(int Arr[], int len)
{	
	int searchValue;
	int ValueFinded = 0;
	printf("Введите число для поиска:\n");
	scanf("%i", &searchValue);
	int lowIndex = 0;
	int HighIndex = len - 1;
	int currentIndex = 0;

	while (lowIndex < HighIndex)
	{		
		currentIndex = (HighIndex - lowIndex) / 2;
		if (Arr[currentIndex] == searchValue)
		{
			ValueFinded = 1;
			break;
		}			
		if (Arr[currentIndex] > searchValue)
		{
			lowIndex = currentIndex + 1;
		}
		if (Arr[currentIndex] < searchValue)
		{
			HighIndex = currentIndex - 1;
		}
	}

	if (ValueFinded == 1)
	{
		printf("Значение найдено по индексу: %i\n", currentIndex);
	}
	return currentIndex;
}
