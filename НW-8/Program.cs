using System;
class Program
{
    static void Main()
    {
        SquaringArray arr = new SquaringArray(5);

        arr[0] = 2;
        arr[1] = 3;
        arr[2] = 4;
        arr[3] = 5;
        arr[4] = 6;

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Элемент {i}: {arr[i]}");
        }
    }
}

public class SquaringArray
{
    private int[] array;

    public SquaringArray(int size)
    {
        array = new int[size];
    }

    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            return array[index];
        }
        set
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            array[index] = value * value;
        }
    }
}
