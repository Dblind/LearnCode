using System;
using System.Collections;
using System.Collections.Generic;
class Test23
{
    //abcdefghijklmnopqrstuvwxyz
    public static void TMain()
    {
        int[] nums = { -22, 33, 4, 6, -11, 22, -1, 10 };
        CheckArr(nums);
        //     int[] nums2 = { 22, 3, 4, 1 };
        //     System.Console.WriteLine(CheckArr(nums2));
        //     int[] nums3 = { 3, 22, 14, 5 };
        //     System.Console.WriteLine(CheckArr(nums3));
    }
    static void CheckArr(int[] t)
    {
        foreach (var e in t)
        {
            if (e < -10 || e > 10) System.Console.Write("+");
            else System.Console.Write("-");
        }
    }
}