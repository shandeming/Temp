using System.Reflection;

Cat cat=new Cat();
cat.Run((a,b)=>System.Console.WriteLine(b));
cat.Run((a,b)=>System.Console.WriteLine(b));
cat.Run((a,b)=>System.Console.WriteLine(b));
System.Console.WriteLine("feature1");

#region Sort
static void BubbleSort(int[] arr)
{
    if (arr.Length <= 1) return;
    for (int i = 0; i < arr.Length - 1; i++)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[j] < arr[i])
            {
                int temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }
        }
    }
}
static void QuickSort(int[] arr, int left, int right)
{
    if (arr.Length <= 1) return;
    if (left >= right) return;
    int p = left;
    int q = right;
    int pivot = arr[left];
    while (p < q)
    {
        while (arr[q] > pivot && p < q)
        {
            q--;
        }
        if (arr[q] < pivot)
        {
            arr[p] = arr[q];
        }
        while (arr[p] < pivot && p < q)
        {
            p++;
        }
        if (arr[p] > pivot)
        {
            arr[q] = arr[p];
        }
    }
    arr[p] = pivot;
    QuickSort(arr, left, p - 1);
    QuickSort(arr, p + 1, right);
}

static void MergeSort(int[] arr, int[] temp, int left, int right)
{
    if (left >= right) return;
    int p = left;
    int q = right;
    int mid = (left + right) / 2;
    MergeSort(arr, temp, p, mid);
    MergeSort(arr, temp, mid + 1, q);
    Merge(arr, temp, left, mid, right);
}
static void Merge(int[] arr, int[] temp, int left, int mid, int right)
{
    int index = left;
    int p = left;
    int q = mid + 1;
    for (int i = left; i <= right; i++)
    {
        if (p > mid)
        {
            temp[index++] = arr[q++];
            continue;
        }
        if (q > right)
        {
            temp[index++] = arr[p++];
            continue;
        }
        if (arr[p] < arr[q])
        {
            temp[index++] = arr[p++];
        }
        else
        {
            temp[index++] = arr[q++];
        }
    }
    for (int i = left; i <= right; i++)
    {
        arr[left] = temp[left];
        left++;
    }
}

#endregion

#region Tool
static void Print(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        System.Console.Write($"{arr[i]}|");
    }
}

static int[] GenerateRandomArray(int lenght, int minValue, int maxValue)
{
    Random random = new Random();
    int[] arr = new int[lenght];
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = random.Next(minValue, maxValue + 1);
    }
    return arr;
}
#endregion

public class Cat{
    public void Say(){
        System.Console.WriteLine("Meow");
    }
    public void Run(Action<int,int> a){
        a.Invoke(2,3);
    }
}
    