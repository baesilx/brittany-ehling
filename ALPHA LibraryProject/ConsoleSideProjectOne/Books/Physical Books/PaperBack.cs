using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSideProjectOne.Physical_Books
{
    public class PaperBack : PhysicalBook
    {
        public PaperBack(string title, string author) : base(title, author)
        {

        }
        public string GetType()
        {
            return null;
        }
    }
}
