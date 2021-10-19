using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Books
    {
        //properties.
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsCheckedOut { get; set; }
        public string DueDate { get; set; }
        
        //constructor with only title and author.
        public Books(string title, string author)
        {
            this.Title = title;
            this.Author = author;
            this.IsCheckedOut = false;
            this.DueDate = "";
        }
        
        //constructor with all properties.
        public Books(string title, string author, bool IsCheckedOut, string DueDate)
        {
            this.Title = title;
            this.Author = author;
            this.IsCheckedOut = IsCheckedOut;
            this.DueDate = DueDate;
        }
        
        //default constructor with no parameters.
        public Books()
        {
            this.Title ="";
            this.Author ="";
            this.IsCheckedOut = false;
            this.DueDate = "";
        }



    //overrides toString method with a custom class specific toString method.
    public override string ToString()
        {
            if (IsCheckedOut)
                return string.Format("{0,-40}\n Author: {1,-20} {2,-10} {3}\n", this.Title, this.Author, "Unavailable until",DueDate);
            return string.Format("{0,-40}\n Author: {1,-20} {2,-10}\n", this.Title, this.Author, "Available");
        }
    }

