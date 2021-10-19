using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OOPProject
{
    class Library
    {
        //creates book list for the library object.
        List<Books> LibBooks = new List<Books>();

        //constructor that takes a Books list as a parameter.
        public Library(List<Books> LibBooks)
        {
            this.LibBooks = LibBooks;
        }
        

        //displays books and their index in order.
        public void displayBooks(List<Books> selectedBooks) {
            for (int i = 0; i < selectedBooks.Count; i++)
                Console.WriteLine(String.Format("{0,-3} {1,-3 }", i+1+".", selectedBooks[i].ToString()));
        }

        //returns a new list matching author search criteria.
        public List<Books> ListByAuthor(string input) {
            List<Books> SelectedList = new List<Books>();
            List<string> keyWords = input.Split(' ').ToList();
            foreach (Books book in LibBooks)
            {
                foreach (string word in keyWords)
                {
                    if (book.Author.ToLower().Contains(word))
                    {
                        SelectedList.Add(book);
                        break;
                    }
                }
            }
            return SelectedList;
        }

        //returns a new list matching title search criteria.
        public List<Books> ListByTitle(string input)
        {
            List<Books> SelectedList = new List<Books>();
            List<string> keyWords = input.Split(' ').ToList();      
            foreach (Books book in LibBooks)
            {
                foreach (string word in keyWords)
                {
                    if (book.Title.ToLower().Contains(word)) 
                    {
                        SelectedList.Add(book);
                        break;
                    }
                }    
            }
            return SelectedList;
        }



        //changes IsCheckedOut to true.
        public void checkOutBook() {
        int selection = Validator.ValidateSelectBy();
            
            //calls search by title method.
            if (selection == 1) {
                Console.WriteLine("Enter Title: ");
                string searchTitle = Console.ReadLine().ToLower();
                List<Books> SelectedList = ListByTitle(searchTitle);
                
                //tells the user if there are no books matching search criteria.
                if (SelectedList.Count == 0)
                {
                    Console.WriteLine("No books matching search criteria.");
                    return;
                }
                
                //displays books matching search criteria.
                displayBooks(SelectedList);
                int BookIndex = Validator.ValidateIndex(SelectedList.Count);
                
                //returns to main menu
                if (BookIndex==-1)
                    return;
                
                //finds the book selected from the temporary search list then changes the IsCheckedOut and DueDate variables of the main list book object.
                foreach (Books book in LibBooks)
                {
                    if (SelectedList[BookIndex].Equals(book)) 
                    {
                        
                        if (!book.IsCheckedOut) 
                        {
                            book.IsCheckedOut = true;
                            book.DueDate = DateTime.Now.AddDays(14).ToString();
                            Console.WriteLine($"You have checked out {book.ToString()} Your due date is {book.DueDate}");
                            return;
                        }
                        
                        //tells the user if they already checked out book.
                        else
                        {
                            Console.WriteLine("Book Already Checked out");
                            return;
                        }
                    }
                }
            }

            //calls search by author method.
            if (selection==2) 
            {
                Console.WriteLine("Enter Author: ");
                string searchTitle = Console.ReadLine().ToLower();
                List<Books> SelectedList = ListByAuthor(searchTitle);
                
                //tells the user if there are no books matching search criteria.
                if (SelectedList.Count == 0) 
                {
                    Console.WriteLine("No books matching search criteria.");
                    return;
                }
                
                //displays books matching search criteria.
                displayBooks(SelectedList);
                int BookIndex = Validator.ValidateIndex(SelectedList.Count);
                
                //finds the book in the main Books list then checks it out.
                foreach (Books book in LibBooks)
                {
                    if (SelectedList[BookIndex].Equals(book))
                    {
                        if (!book.IsCheckedOut)
                        {
                            book.IsCheckedOut = true;
                            book.DueDate = DateTime.Now.AddDays(14).ToString();
                            Console.WriteLine($"You have checked out {book.ToString()} Your due date is {book.DueDate}");
                            break;
                        }
                        Console.WriteLine("Book already Checked Out");
                        return;
                    }
                }
            }
        }

        //changes IsCheckedOut to true.
        public void returnBook() {
            int selection = Validator.ValidateSelectBy();
            
            //calls search by title method.
            if (selection == 1)
            {
                Console.WriteLine("Enter Title: ");
                string searchTitle = Console.ReadLine().ToLower();
                List<Books> SelectedList = ListByTitle(searchTitle);
                
                //tells the user if there are no books matching search criteria.
                if (SelectedList.Count == 0)
                {
                    Console.WriteLine("No books matching search criteria.");
                    return;
                }

                //displays books matching search criteria.
                displayBooks(SelectedList);
                int BookIndex = Validator.ValidateIndex(SelectedList.Count);
                
                //returns to main menu
                if (BookIndex==-1)
                    return;
                
                //finds the book in the main Books list then returns it.
                foreach (Books book in LibBooks)
                {
                    if (SelectedList[BookIndex].Equals(book))
                    {
                        if (book.IsCheckedOut)
                        {
                            book.IsCheckedOut = false;
                            book.DueDate = DateTime.Now.AddDays(14).ToString();
                            Console.WriteLine($"You have returned {book.Title} ");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Book Already Checked out");
                            break;
                        }
                    }
                }
            }
            if (selection == 2)
            {
                Console.WriteLine("Enter Author: ");
                string searchTitle = Console.ReadLine().ToLower();
                List<Books> SelectedList = ListByAuthor(searchTitle);
                
                //tells the user if there are no books matching search criteria.
                if (SelectedList.Count == 0)
                {
                    Console.WriteLine("No books matching search criteria.");
                    return;
                }

                //displays books matching search criteria.
                displayBooks(SelectedList);
                int BookIndex = Validator.ValidateIndex(SelectedList.Count);
                
                //returns to main menu
                if (BookIndex == -1)
                    return;
                
                //finds the book in the main Books list then returns it.
                foreach (Books book in LibBooks)
                {
                    if (SelectedList[BookIndex].Equals(book))
                    {
                        if (book.IsCheckedOut)
                        {
                            book.IsCheckedOut = false;
                            book.DueDate = DateTime.Now.AddDays(14).ToString();
                            Console.WriteLine($"You have returned {book.Title} Your due date is {book.DueDate}");
                            break;
                        }
                        Console.WriteLine("Book not Checked Out");
                        return;
                    }
                }
            }
        }
        //Option to burn down the Library - Process for it
        public static void BurnLibrary()
        {
            Console.Clear();
            Console.WriteLine("Burn down library? Why?");

            Console.WriteLine("Are you sure? (y/n)");
            string input = Console.ReadLine().ToLower().Trim(); ;
            if (input == "y" || input == "yes")
            {
                for (int i = 0; i <= 30; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("*Fire*");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("BURNING BOOKS");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*Fire*");
                }
                Console.WriteLine("Burning Complete...");
                Console.ReadLine().ToLower().Trim();
                Console.Clear();
            }
            else if (input == "n" || input == "no")
            {
                Console.WriteLine("Right, you wouldn't want to turn into Julius Caesar.\n");
            }
            else
            {
                BurnLibrary();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("There is nothing but Ash and Rubble");
            }
            Console.ForegroundColor = ConsoleColor.White;
            System.Environment.Exit(0);
        }

        //Method for using the library object.
        public void LibraryMenu() {
            int option=0;
            
            //displays options to the user.
            do {
                Console.WriteLine("1. Display all books");
                Console.WriteLine("2. Checkout a book");
                Console.WriteLine("3. Return a book");
                Console.WriteLine("4. Burn down the Library?");
                Console.WriteLine("5. Exit Library");
                option = int.Parse(Console.ReadLine());

                //checks for which options the user selected.
                if (option == 1)
                    displayBooks(LibBooks);
                else if (option == 2)
                    checkOutBook();
                else if (option == 3)
                    returnBook();
                else if (option == 4)
                    BurnLibrary();
            } while (option != 5 );

            //Tells the user good bye.
            Console.WriteLine("Come Back Again, Good Bye");
        }
    }
}


