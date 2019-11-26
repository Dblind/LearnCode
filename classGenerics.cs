using System;

public interface IPhoneNumber
{
    string Number
    {
        get;
        set;
    }
    string Name
    {
        get;
        set;
    }
}
class Friends : IPhoneNumber
{
    public Friends(string n, string num, bool wk)
    {
        Name = n;
        Number = num;
        IsWorkNumber = wk;
    }
    public bool IsWorkNumber
    {
        get;
        private set;
    }
    public string Name { get; set; }
    public string Number { get; set; }
}
class Supplier : IPhoneNumber
{
    public Supplier(string n, string num)
    {
        Name = n;
        Number = num;
    }
    public string Name { get; set; }
    public string Number { get; set; }
}
// class PhoneNumber
// {
//     public PhoneNumber(string n, string num)
//     {
//         Name = n;
//         Number = num;
//     }
//     public string Name { get; set; }
//     public string Number { get; set; }
// }
// class Friends : PhoneNumber
// {
//     public Friends(string n, string num, bool wk) :
//         base(n, num)
//     {
//         isWorkNumber = wk;
//     }
//     public bool isWorkNumber { get; private set; }
// }
// class Supplier : PhoneNumber
// {
//     public Supplier(string n, string num) : base(n, num) { }
// }
class EmailFriend { }
class PhoneList<T> where T : IPhoneNumber   //PhoneNumber
{
    T[] phList;
    int end;
    public PhoneList()
    {
        phList = new T[10];
        end = 0;
    }
    public bool Add(T newEntry)
    {
        if (end == 10) return false;
        phList[end] = newEntry;
        end++;
        return true;
    }
    public T FindByName(string name)
    {
        for (int i = 0; i < end; i++)
        {
            if (phList[i].Name == name) return phList[i];
        }
        throw new NotFoundException();
    }
    public T FindByNumber(string number)
    {
        for (int i = 0; i < end; i++)
        {
            if (phList[i].Number == number) return phList[i];
        }
        throw new NotFiniteNumberException();
    }
}
class NotFoundException : Exception
{
    public NotFoundException() : base() { }
    public NotFoundException(string str) : base(str) { }
    public NotFoundException(string str, Exception inner) :
        base(str, inner)
    { }
    protected NotFoundException(System.Runtime.Serialization.SerializationInfo si,
        System.Runtime.Serialization.StreamingContext sc) :
        base(si, sc)
    { }
}

class Run
{
    public static void Main1()
    {
        PhoneList<Friends> plist = new PhoneList<Friends>();
        plist.Add(new Friends("Tom", "555-1234", true));
        plist.Add(new Friends("Garry", "555-6756", true));
        plist.Add(new Friends("Matt", "555-9254", false));

        try
        {
            Friends frnd = plist.FindByName("Garry");
            System.Console.Write(frnd.Name + " " + frnd.Number);
            if (frnd.IsWorkNumber)
                Console.WriteLine(" (рабочий)");
            else
                System.Console.WriteLine();
        }
        catch (NotFoundException)
        {
            System.Console.WriteLine("Не найдено.");
        }
        System.Console.WriteLine();
        PhoneList<Supplier> plist2 = new PhoneList<Supplier>();
        plist2.Add(new Supplier("Company Global Hardware", "555-8834"));
        plist2.Add(new Supplier("Agency Computer Warehouse", "555-9256"));
        plist2.Add(new Supplier("Company NetworkCity", "555-2564"));
        try
        {
            Supplier sp = plist2.FindByNumber("555-2564");
            System.Console.WriteLine(sp.Name + " " + sp.Number);
        }
        catch (NotFoundException)
        {
            System.Console.WriteLine("Не найдено.");
        }
    }
}