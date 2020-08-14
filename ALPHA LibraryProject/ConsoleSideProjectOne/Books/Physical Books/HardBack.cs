using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSideProjectOne.Physical_Books
{
    public class HardBack : PhysicalBook
    {
        public HardBack(string title, string author) : base(title, author)
        {
   
        }
        public string GetType()
        {
            return null;
        }
    }
}
