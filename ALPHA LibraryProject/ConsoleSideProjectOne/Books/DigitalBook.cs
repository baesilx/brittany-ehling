using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSideProjectOne
{
    public class DigitalBook : IBook
    {
        public string Title { get; }
        public string Author { get; }
        public DigitalBook(string title, string author)
        {
            Title = title;
            Author = author;
        }


    }
}
