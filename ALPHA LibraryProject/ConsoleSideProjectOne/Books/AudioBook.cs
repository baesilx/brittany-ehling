using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSideProjectOne
{
    public class AudioBook : IBook
    {
        public string Title { get; }
        public string Author { get; }
        public AudioBook(string title, string author) 
        {
            Title = title;
            Author = author;
        }

    }

}
