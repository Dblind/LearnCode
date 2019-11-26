using System;

class test
{
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

    class GenericT<T> where T : A
    {
        T t;
        public GenericT(T t)
        {
            this.t = t;
        }
        public void Display()
        {
            t.Hello();
        }
    }

}