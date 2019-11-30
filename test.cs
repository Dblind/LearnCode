using System;

class Test34
{
    interface IWriter
    {
        void Write(string text);
    }
    class TextWorker
    {
        public IWriter Writer {get;set;}
        public void WriteText(string text)
        {
            text += " some";
            Writer.Write(text);
        }
    }
    class StandartWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
    class BracesWriter : IWriter
    {
        public void Write(string text)
        {
            System.Console.WriteLine("{"+text+"}");
        }
    }
    class SquareWriter : IWriter
    {
        public void Write(string text)
        {
            System.Console.WriteLine("["+text+"]");
        }
    }

    public static void MaitInterface()
    {
        TextWorker textWorker = new TextWorker();

        textWorker.Writer = new StandartWriter();
        textWorker.WriteText("text");
        textWorker.Writer = new BracesWriter();
        textWorker.WriteText("text");
        textWorker.Writer = new SquareWriter();
        textWorker.WriteText("text");
    }
}