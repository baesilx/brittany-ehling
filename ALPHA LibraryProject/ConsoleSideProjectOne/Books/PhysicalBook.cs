using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ConsoleSideProjectOne
{
    public abstract class PhysicalBook : IBook
    {
        public string Title { get; }
        public string Author { get; }
        public bool IsSigned { get; }
        public bool IsSpecial { get; }
        
        public PhysicalBook(string title, string author)
        {
            Title = title;
            Author = author;
        }
        public string GetType()
        {
            return null;
        }
        public string RemoveBook()
        {

            return $"{Title} {Author} removed";
        }
        public string AddBook()
        {
            return $"{Title} {Author} added";
        }


        //public string Paperback { get; }
        //public string Hardback { get; }
        //public string MassMarket { get; }
        //public PhysicalBook(string title, string author, string paperback, string hardback, string massMarket) : base(title, author)
        //{
        //    Paperback = paperback;
        //    Hardback = hardback;
        //    MassMarket = massMarket;
        //}

        //public override string GetType()
        //{
        //    string type = "Physical Book";
        //    string typeOfPhysical = "";
        //    return type + typeOfPhysical;
        //}
    }
}
