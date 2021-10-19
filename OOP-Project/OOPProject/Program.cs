using System;
using System.Collections.Generic;
using System.IO;

namespace OOPProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Library of Alexandria!\n");

            //creates list of books for the library object.
            List<Books> LibBooks = new List<Books>();
            //creates a variable for the file path. 
            string filePath = @"..\..\..\LibraryLog.txt";
            
            //Creates the file path if it does not exist
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Creating library text file");
                //Creates a default list of books to write to the text file.
                List<Books> DefaultBooks = new List<Books>
                {
                    new Books("Dracula", "Bram Stoker"),
                    new Books("Moby Dick", "Herman Melville"),
                    new Books("Frankenstein", "Mary Shelley"),
                    new Books("1984", "George Orwell"),
                    new Books("Lord of the Rings", "J.R.R. Tolkien"),
                    new Books("The Adventures of Huckleberry Finn", "Mark Twain"),
                    new Books("The Iliad", "Homer"),
                    new Books("Charlie and the Chocolate Factory", "Roald Dahl"),
                    new Books("The Count of Monte Cristo", "Alexandre Dumas"),
                    new Books("Tale of Two Cities", "Charles Dickens"),
                    new Books("Art of War", "Sun-Tzu"),
                    new Books("Heart of Darkness", "Joseph Conrad")
                };
                //sets the main bookList to the default book list.
                LibBooks = DefaultBooks;

                //writes each book to the txt file.
                StreamWriter SW = new StreamWriter(filePath);
                foreach (Books book in DefaultBooks)
                    SW.WriteLine($"{book.Title} ,{book.Author} ,{book.IsCheckedOut},{book.DueDate}");
                SW.Close();
            }

            //creates book list from reading the txt file.
            else {
                StreamReader reader = new StreamReader(filePath);
                while (true)
                {
                    string line = reader.ReadLine();
                    //Stops when we reach an empty line.
                    if (line == null)
                        break;
                    //runs for every line and creates an array of strings that holds every value then uses those values to construct and add new book object.
                    else
                    {
                        string[] values = line.Split(',');
                        string title = values[0];
                        string author = values[1];
                        bool isCheckedOut;
                        if (values[2] == "True")
                            isCheckedOut = true;
                        else
                            isCheckedOut = false;
                        string dueDate = values[3];
                        Books newBook = new Books(title, author, isCheckedOut, dueDate);
                        LibBooks.Add(newBook);
                    }
                }
                reader.Close();
            }

            //creates the library object
            Library MyLib = new Library(LibBooks);
            MyLib.LibraryMenu();
            
            //writes every book to the txt file when the user is finished checking out and returning books.
            StreamWriter LibSW = new StreamWriter(filePath);
            foreach (Books book in LibBooks)
                LibSW.WriteLine($"{book.Title} ,{book.Author} ,{book.IsCheckedOut},{book.DueDate}");
            LibSW.Close();

        }
    }
}
