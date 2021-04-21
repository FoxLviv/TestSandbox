using System;

namespace LearnBasics.Sandbox.SOLID
{
    class DependencyInversionPrinciple
    {
        public void Example()
        {
            var book = new Book(new ConsolePrinter());
            book.Print();
            book.Printer = new HtmlPrinter();
            book.Print();
        }
    }

    interface IPrinter
    {
        void Print(string text);
    }

    class Book
    {
        public string Text { get; set; }
        public IPrinter Printer { get; set; }

        public Book(IPrinter printer)
        {
            this.Printer = printer;
        }

        public void Print()
        {
            Printer.Print(Text);
        }
    }

    class ConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Output in Console");
        }
    }

    class HtmlPrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Output in HTML");
        }
    }
}
