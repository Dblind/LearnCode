using System;

class ArrayFind
{
    public int[] arr;
    public int Counter { get; set; }
    public int amountOfNum { get; set; }
    public ArrayFind(int n)
    {
        arr = new int[n];
        amountOfNum = n;
    }
}
static class MethodsFind
{
    public static void arrOrderedGen(int[] n)
    {
        var rnd = new Random();
        int current = 0;
        for (int i = 0; i < n.Length; i++)
        {
            n[i] = current += rnd.Next(1, 3);
            Console.Write(n[i] + " ");
        }

    }
    public static void arrRandomGen(int[] n)
    {
        var rnd = new Random();
        for (int i = 0; i < n.Length; i++)
        {
            n[i] = rnd.Next(100);
            Console.Write(n[i] + " ");
        }
    }
    public static int LineFind(ArrayFind n, int f)
    {
        int k = -1;
        n.Counter = 0;
        for (int i = 0; i < n.arr.Length; i++)
        {
            n.Counter++;
            if (n.arr[i] == f)
            {
                k = i; break;
            }
        }
        return k;
    }
    public static int BinFind(ArrayFind n, int f)
    {
        int k;
        int left = 0;
        int right = n.arr.Length - 1;
        k = (right + left) / 2;
        n.Counter = 0;
        while (left < right - 1)
        {
            n.Counter++;
            k = (right + left) / 2;
            if (n.arr[k] == f) return k;
            n.Counter++;
            if (n.arr[k] < f) left = k;
            else right = k;
        }
        if (n.arr[k] != f)
        {
            if (n.arr[left] == f) k = right;
            else k = -1;
        }
        return k;
    }
    static void comparisonOfFinds()
    {

    }
}
static class EnterNum
{
    public static int enterNum(string str)
    {
        bool flag = true;
        int valueNum = 0;
        while (flag)
        {
            try
            {
                Console.Write(str);
                valueNum = Convert.ToInt32(Console.ReadLine());
                if (valueNum < 0) valueNum *= -1;
                flag = false;
            }
            catch (FormatException)
            {
                System.Console.WriteLine("Только цыфры!");
            }
        }
        return valueNum;
    }
}


class ProgramFind
{
    delegate int delFind(ArrayFind nn, int f);
    public static void FindMain()
    {
        int trash = default;
        delFind delFindFunc;
        while (true)
        {
            trash = EnterNum.enterNum("Количество элементов: ");
            ArrayFind arrF = new ArrayFind(trash);
            System.Console.WriteLine("\nПоиск в кпорядоченном по взрастанию массиве.");
            MethodsFind.arrOrderedGen(arrF.arr);
            delFindFunc = MethodsFind.LineFind;
            DisplayResultsFind(arrF, delFindFunc, 10);
            DisplayResultsFind(arrF, delFindFunc, 110);
            delFindFunc = MethodsFind.BinFind;
            DisplayResultsFind(arrF, delFindFunc, 110);
            System.Console.WriteLine();
            MethodsFind.arrRandomGen(arrF.arr);


            System.Console.WriteLine();
        }
    }
    static void DisplayResultsFind(ArrayFind n, delFind df, int f)
    {
        int t = df(n, f);
        System.Console.WriteLine("\nCount of iteration: {0}, result find: {1}.",
                n.Counter, t);
    }
}