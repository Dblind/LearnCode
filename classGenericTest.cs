using System;
using System.Collections.Generic;

class Test
{
    class X1
    {
        public int y = 1;
        public virtual void Display1()
        {
            System.Console.WriteLine("X1");
        }
    }
    class X2 : X1
    {
        public override void Display1()
        {
            System.Console.WriteLine("X2");
        }
    }
    class X3 : X2
    {
        public override void Display1()
        {
            System.Console.WriteLine("X3");
        }
    }
    class X4 : X3
    {
        public X4()
        {
            y = 4;
        }
        public override void Display1()
        {
            base.Display1();
            System.Console.WriteLine("X4");
        }
        public void Display2()
        {
            System.Console.WriteLine("test");
        }
    }
    class Y<T, V>
    {
        public void Set(T t)
        {
            System.Console.WriteLine(t);
        }
        public void Set(V v)
        {
            System.Console.WriteLine(v);
        }
    }
    class T1
    {
        public static X1 V1(X1 t)
        {
            var cur = new X1();
            cur.y += 1;
            return cur;
        }
        public static X2 V2(X2 t)
        {
            var cur = new X2();
            cur.y += 1;
            return cur;
        }
    }
    public static void MainTest()
    {
        var x1 = new X1();
        var x2 = new X2();
        var x3 = new X3();
        var x4 = new X4();

        x4.Display2();
        x1 = x4;
        x1.Display1();
        System.Console.WriteLine(x1.y);
        //x1.Display2();
        System.Console.WriteLine();

        var tt = new Y<int, Double>();
        tt.Set(3);
        tt.Set(.3);

        x1 = new X1();
        var x11 = new X1();
        x2 = new X2();
        var x22 = new X2();

        x1 = T1.V1(x22);
        //x2 = T1.V2(x1);


    }
}

class Test2
{
    class Animal { }
    class Cat : Animal { }
    abstract class Engine { }
    class V8Engine : Engine { }
    interface ICar<out T> where T : Engine
    {
        T GetEngine();
    }
    class Lada : ICar<V8Engine>
    {
        public V8Engine GetEngine()
        {
            return new V8Engine();
        }
    }
    class Test3 : ICar<V8Engine>
    {
        public V8Engine GetEngine()
        {
            System.Console.WriteLine("Cat");
            return new V8Engine();
        }
        public int cat = 00;
    }
    public static void MainCat()
    {
        List<Cat> list = new List<Cat>();
        IEnumerable<Cat> cats = list;
        IEnumerable<Animal> animals = cats;

        object[] objects = new string[3];
        objects[0] = "aaa";
        //objects[1] = 1;
        //objects[2] = new Cat();

        Lada lada = new Lada();
        Test3 cat = new Test3();
        ICar<V8Engine> V8EngineCar = lada;
        ICar<Engine> engine = lada;

    }
}

class Test4
{
    public interface IMyCoVarGenIF<out T>
    {
        T GetObject();
    }
    public interface IMyCoVarGenIF_2<out T> : IMyCoVarGenIF<T> { }
    class MyClass<T> : IMyCoVarGenIF<T>
    {
        public T obj;
        public MyClass(T v) { obj = v; }
        public T GetObject() { return obj; }
    }
    class Alpha
    {
        string name;
        public Alpha(string n) { name = n; }
        public string GetName() { return name; }
    }
    class Beta : Alpha
    {
        public Beta(string n) : base(n) { }
    }
    public interface IMyContrVarGenIF<in T> { void Show(T ob); }
    class MyClass2<T> : IMyContrVarGenIF<T>
    {
        public void Show(T x)
        {
            System.Console.WriteLine(x);
        }
    }
    class Alpha2
    {
        public override string ToString()
        {
            return "This is object to class Alpha.";
        }
    }
    class Beta2 : Alpha2
    {
        public override string ToString()
        {
            return "This is object to class Beta.";
        }
    }
    public static void MainContrVar()
    {
        IMyContrVarGenIF<Alpha2> AlphaRef = new MyClass2<Alpha2>();
        IMyContrVarGenIF<Beta2> BetaRef = new MyClass2<Beta2>();
        IMyContrVarGenIF<Beta2> BetaRef2 = new MyClass2<Alpha2>();   // контвариантность
        BetaRef.Show(new Beta2());
        BetaRef = AlphaRef;             // контвариантность
        BetaRef2.Show(new Beta2());
        
    }

    public static void MainTest2()
    {
        IMyCoVarGenIF<Alpha> AlphaRef =
            new MyClass<Alpha>(new Alpha("Alpha #1"));

        System.Console.WriteLine("Name of object ref: " +
            AlphaRef.GetObject().GetName());
        AlphaRef = new MyClass<Beta>(new Beta("Beta #1"));
        System.Console.WriteLine("Name of object ref: " +
            AlphaRef.GetObject().GetName());
        // var v = new MyClass<Alpha>(new Alpha("a"));
        // System.Console.WriteLine(v.obj);
        // v =(MyClass<Alpha>) AlphaRef;
        // System.Console.WriteLine(v.obj);
    }
}