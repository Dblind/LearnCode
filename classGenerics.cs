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

//------------------------------------------------------------
//------------------------------------------------------------


class Test1<T> where T : class { }
class Test2<T> where T : struct { }
class test
{
    class Gen4<T, V> where V : T { }
    class GenTwo<T, V> where T : class where V : struct { }
    class Test3<T>
    {
        T obj;
        public Test3()
        {
            obj = default(T);   // значение <T> по умолчанию
        }
    }

    delegate T SomeOp<T>(T v); // Delegate
    delegate bool SomeOp2<in Т>(Т obj);         // Контрваниантный
    delegate Т AnotherOp<out Т, V>(V obj);      // Ковариантный
    struct XY<T>                ///
    {
        public T x, y;
        public XY(T x, T y)
        {
            this.x = x; this.y = y;
        }
    }
    public interface IMyCoVarGenIF<out T> { T GetObg(); } // Ковариантрость с 'out'
    public interface IMyCoVarGenIF_2<out T> : IMyCoVarGenIF<T> { }
    public interface IMyContraVarGenIF<in T> { void Show(T ob); } // Контрвариантность с 'in'
    public interface IMyContraVarGenIF2<in T> : IMyContraVarGenIF<T> { }

    class A
    {
        public void Hello()
        {
            System.Console.WriteLine("Hello!");
        }
    }
    class B : A { }
    class C : B { }
    class D { }
    class Gen<T>
    {
        protected T ob;
        public Gen(T o)
        {
            ob = o;
        }
        public T GetObj()
        {
            return ob;
        }
    }
    class Gen2<T, V> : Gen<T>
    {
        V ob2;
        public Gen2(T o, V o2) : base(o)
        {
            ob2 = o2;
        }
        public V GetObj2()
        {
            return ob2;
        }
    }

    public static void Main31414()
    {
        A a = new A();
        B b = new B();
        C c = new C();
        D d = new D();
        GenericT<A> aGT = new GenericT<A>(a);
        GenericT<B> bGT = new GenericT<B>(b);
        GenericT<C> cGT = new GenericT<C>(c);
        //GenericT<D> dGT = new GenericT<D>(d);
    }

    class GenericT<T> where T : A, new()
    {
        T t;
        public GenericT()
        {
            t = new T();
        }
        public GenericT(T t)
        {
            this.t = t;
        }
        public void Display()
        {
            t.Hello();
        }
    }
    public static void TestMain()
    {
        Gen4<A, B> ab = new Gen4<A, B>();
        Gen4<A, A> aa = new Gen4<A, A>();

        XY<int> xy = new XY<int>(11, 22);
        XY<double> xyD = new XY<double>(3.4, 4.3);
        System.Console.WriteLine(xy.x + " " + xy.y);
        System.Console.WriteLine(xyD.x + " " + xyD.y);

        Gen2<string, int> gen2 = new Gen2<string, int>("New value: ", 99);
        System.Console.WriteLine(gen2.GetObj() + " " + gen2.GetObj2());
    }

}
