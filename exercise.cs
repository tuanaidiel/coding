//1

int[] numbers = { 10, 20, 30, 40, 50 };

for (int i = 0; i < numbers.Length; i++)
{
    System.Console.WriteLine(numbers[i]);
}

//2

List<int> numbers = new List<int> { 20, 30, 10, 50, 40 };
int max = numbers.Max();
System.Console.WriteLine(max);

//3

int SumEvenNumbers (int[] numbers)
{
    int sum = 0;
    foreach (int num in numbers)
    {
        if (num % 2 == 0)
        {
            sum += num;
        }
    }
    return sum;
}

int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };
int result = SumEvenNumbers(array);
System.Console.WriteLine(result);

//4 reverse

List<string> fruits = new List<string> { "banana", "apple", "watermelon", "cherry" };
fruits.Reverse();
foreach (string fruit in fruits)
{
    System.Console.WriteLine(fruit);
}

//5 remove duplicate from list of integers

List<int> numbers = new List<int> { 1, 1, 2, 3, 3, 4, 5, 5 };
List<int> unique = new List<int>();
foreach (int num in numbers)
{
    if (!unique.Contains(num))
    {
        unique.Add(num);
    }
}

foreach (int num in unique)
{
    System.Console.WriteLine(num);
}


//6 sort array of integers in ascending order without using .Sort()
int[] number = { 30, 20, 40, 50, 10 };
int n = numbers.Length;
for (int i = 0; i < n - 1; i++)
{
    for (int j = 0; j < n - 1; j++)
    {
        if (numbers[j] > numbers[j + 1])
        {
            int temp = numbers[j];
            numbers[j] = numbers[j + 1];
            numbers[j + 1] = temp;
        }
    }
}

foreach (int num in numbers)
{
    System.Console.WriteLine(num);
}


//7 check if an array of integers contains number 7
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
bool containsSeven = false;
foreach (int num in numbers)
{
    if (num == 7)
    {
        containsSeven = true;
        break;
    }
}
System.Console.WriteLine(containsSeven);

//8 convert array integer to list
int[] arr = { 1, 2, 3 };
List<int> list = arr.ToList();
foreach (int num in list)
{
    System.Console.WriteLine(num);
}

//9 merge 2 arrays nto single list
int[] arr1 = { 1, 2, 3 };
int[] arr2 = { 4, 5, 6 };
List<int> mergedList = new List<int>();
mergedList.AddRange(arr1);
mergedList.AddRange(arr2);
foreach (int num in mergedList)
{
    System.Console.WriteLine(num);
}


//10 Find second smallest number in an array
int[] numbers = { 1, 2, 3, 4, 5 };
if (numbers.Length < 2)
{
    System.Console.WriteLine("Array too small to find second smallest number");
}

else
{
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < numbers.Length - i - 1; j++)
        {
            if (numbers[j] > numbers[j + 1])
            {
                int temp = numbers[j];
                numbers[j] = numbers[j + 1];
                numbers[j + 1] = temp;
            }
        }
    }
    System.Console.WriteLine(numbers[1]);
}