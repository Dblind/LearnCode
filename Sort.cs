using System;

static class Sort<T> where T : IComparable
{
    public static void SortMin(T[] t)
    {
        T current = default;
        for (int i = 0; i < t.Length; i++)
        {
            for (int j = 1+i; j < t.Length; j++)
            {
                if (t[j].CompareTo(t[i]) < 0)
                {
                    current = t[j];
                    t[j] = t[i];
                    t[i] = current;
                }
            }
        }
    }
}