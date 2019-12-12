using System;
using System.Collections.Generic;
using System.Linq;

class LinqTest
{
    public static void LT_1()
    {
        int[] nums = { 1, -2, 3, 0, -4, 5 };
        // IEnumerable<int> posNums = from int n in nums;
        // from переменная_диапазона in источник_данных
        var posNums = from n in nums
                      where n > 0
                      where n < 10  // where n>0 ts n<0
                      select n;       // group
        System.Console.WriteLine("Positive value from array nums: ");
        foreach (int e in posNums) Console.Write(e + " ");
        System.Console.WriteLine();
        System.Console.WriteLine("\nSet value 99 for array element nums[1].");
        nums[1] = 99;
        Console.Write("Positive value from the array nums\nafter change to it: ");
        foreach (int e in posNums) Console.Write(e + " ");
        System.Console.WriteLine();
    }

    public static void LTString_2()
    {
        string[] strs = {".com", ".net", "hsNameA.com",
            "shNameB.net", "test", ".network",
            "hsNameC.net", "hsNameD.com" };
        IEnumerable<string> netAddrs = from addr in strs
                                       where addr.Length > 4 && addr.EndsWith(".net",
                                           StringComparison.Ordinal)
                                       select addr;
        foreach (var str in netAddrs) Console.WriteLine(str);
    }

    class Account
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string AccountNumber { get; private set; }
        public double Balance { get; private set; }
        public Account(string fn, string ln, string accnum, double b)
        {
            FirstName = fn;
            LastName = ln;
            AccountNumber = accnum;
            Balance = b;
        }
    }
    public static void LT_3_orderby()
    {
        Account[] accounts =
            { new Account("Tom", "Smith", "132CK", 100.23),
            new Account("Tom", "Smith", "132CD", 10000.00),
            new Account("Ralf", "Jons", "436CD", 1923.85),
            new Account("Ralf", "Jons", "454MM", 987.132),
            new Account("Ted", "Krammer", "897CD", 3223.19),
            new Account("Ralf", "Jons", "434CK", -123.32),
            new Account("Sara", "Smith", "561MM", 5017.40),
            new Account("Sara", "Smith", "547CD", 34955.79),
            new Account("Sara", "Smith", "843CK", 345.00),
            new Account("Albert", "Smith", " 445CK", -213.67),
            new Account("Betty", "Krammer", "968MM", 5146.67),
            new Account("Karl", "Smith", "079CD", 15345.99),
            new Account("Jenny","Jons", "108CK", 10.98)};
        var accInfo = from acc in accounts
                      orderby acc.LastName, acc.FirstName descending, acc.Balance
                      select acc;
        string str = default;
        foreach (Account acc in accInfo)
        {
            if (str != acc.FirstName)
            {
                Console.WriteLine();
                str = acc.FirstName;
            }
            System.Console.WriteLine("{0}, {1}\tNum order: {2}, {3,10:C}",
            acc.LastName, acc.FirstName,
            acc.AccountNumber, acc.Balance);
        }
        System.Console.WriteLine();
    }

    public static void LT_Select()
    {
        double[] nums =
            {-10.0, 16.4, 12.125, 100.85, -2.2, 25.25, -3.5 };
        var sqrRoots = from n in nums
                       where n > 0
                       select Math.Sqrt(n);
        System.Console.WriteLine("Квадратные корни округленные до сотых: ");
        foreach (double r in sqrRoots)
            Console.WriteLine("{0:#.##}", r);
    }

    class EmailAddress
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public EmailAddress(string n, string a)
        {
            Name = n; Address = a;
        }
    }
    public static void LT_4()
    {
        EmailAddress[] addrs = {
            new EmailAddress("Herbert", "Herb@HerbSchildt.com"),
            new EmailAddress("Tom", "Tom@HerbSchildt.com"),
            new EmailAddress("Sara", "Sara@HerbSchildt.com")
        };
        var eAddres = from entry in addrs
                      select entry.Address;
        System.Console.WriteLine("Адреса электронной почты: ");
        foreach (string s in eAddres)
            System.Console.WriteLine(" " + s);
    }
    class ContactInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ContactInfo(string n, string a, string p)
        {
            Name = n; Email = a; Phone = p;
        }
    }
    public static void LT_5()
    {
        ContactInfo[] contacts = {
            new ContactInfo("Herbert", "Herb@HerbSchildt.com", "555-1010"),
            new ContactInfo("Tom", "Tom@HerbSchildt.com", "555-1110"),
            new ContactInfo("Sara", "Sara@HerbSchildt.com", "555-0110")
        };
        var emailList = from entry in contacts
                        select new EmailAddress(entry.Name, entry.Email);
        System.Console.WriteLine("Список адресов электронной почты: ");
        foreach (EmailAddress e in emailList)
            System.Console.WriteLine(" {0}: {1}", e.Name, e.Address);
    }

    // вложенные операторы from
    class ChrPair
    {
        public char First;
        public char Second;
        public ChrPair(char c, char c2)
        {
            First = c; Second = c2;
        }
    }
    public static void LT_6()
    {
        char[] chrs = { 'A', 'B', 'C' };
        char[] chrs2 = { 'X', 'Y', 'Z' };
        var pairs = from ch1 in chrs
                    from ch2 in chrs2
                    select new ChrPair(ch1, ch2);
        System.Console.WriteLine("All pairs chars ABC and XYZ: ");
        foreach (var p in pairs)
            System.Console.WriteLine("{0} {1}", p.First, p.Second);
    }

    // group

    public static void LT_7()
    {
        string[] websites = { "hsNameA.com", "hsNameBcom", "hsNameC.net",
        "hsNameD.com", "hsNameE.org", "hsNameF.org",
        "hsNameG.tv", "hsNameH.net", "hsNameI.tv"};
        IEnumerable<IGrouping<string, string>> webAddrs = from addr in websites
                                                          where addr.LastIndexOf('.') != -1
                                                          group addr by addr.Substring(addr.LastIndexOf('.'));
        foreach (IGrouping<string, string> sites in webAddrs)
        {
            System.Console.WriteLine("Веб-сайты сгруппированные по имени домена "
                + sites.Key);
            foreach (string site in sites)
                System.Console.WriteLine(" " + site);
            System.Console.WriteLine();
        }
    }

    // into
    public static void LT_8()
    {
        string[] websites = { "hsNameA.com", "hsNameB.com", "hsNameC.net",
        "hsNameD.com", "hsNameE.org", "hsNameF.org",
        "hsNameG.tv", "hsNameH.net", "hsNameI.tv"};
        var webAddrs = from addr in websites
                       where addr.LastIndexOf('.') != -1
                       group addr by addr.Substring(addr.LastIndexOf('.'))
        into ws
                       where ws.Count() > 2
                       select ws;
        System.Console.WriteLine("Top-levels domeins with more two members.\n");
        foreach (var sites in webAddrs)
        {
            System.Console.WriteLine("Domein content: ", sites.Key);
            foreach (var site in sites)
                System.Console.WriteLine(" " + site);
            System.Console.WriteLine();
        }
    }

    // let + from
    public static void LT_9()
    {
        string[] strs = { "alpha", "beta", "gamma" };
        var chrs = from str in strs
                   let chrArray = str.ToCharArray()
                   from ch in chrArray
                   orderby ch
                   select ch;
        System.Console.WriteLine("Sorting symbols: ");
        foreach (char c in chrs) Console.Write(c + " ");
        System.Console.WriteLine();
    }

    // from переменная_диапазона_А in источник_данных_А
    // join переменная_диапазона_В in источник_данных_В
    // on переменная_диапазона_А.свойство equals переменная_диапазона_В.свойство
    class Item
    {
        public string Name { get; set; }
        public int ItemNumber { get; set; }
        public Item(string n, int inum)
        {
            Name = n; ItemNumber = inum;
        }
    }
    class InStockStatus
    {
        public int IemNumber { get; set; }
        public bool InStock { get; set; }
        public InStockStatus(int n, bool b)
        {
            IemNumber = n; InStock = b;
        }
    }
    class Temp
    {
        public string Name { get; set; }
        public bool InStock { get; set; }
        public Temp(string n, bool b)
        {
            Name = n; InStock = b;
        }
    }
    public static void LT_10()
    {
        Item[] items = {
            new Item("Кусачки", 1424),
            new Item("Тиски", 7892),
            new Item("Молоток", 8534),
            new Item("Пила", 6411)
        };
        InStockStatus[] statusList = {
            new InStockStatus(1424, true),
            new InStockStatus(7892, false),
            new InStockStatus(8534, true),
            new InStockStatus(6411, true)
        };
        var inStockList = from item in items
                          join entry in statusList
                          on item.ItemNumber equals entry.IemNumber
                          select new Temp(item.Name, entry.InStock);
        System.Console.WriteLine("Товар\tНаличие\n");
        foreach(Temp t in inStockList)
        System.Console.WriteLine("{0}\t{1}",t.Name, t.InStock);
    }

    // new { имя_А = значение_А, имя_В = значение_В, ... }
}