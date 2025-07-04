﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Net;
using System.Text.RegularExpressions;
using System.Transactions;

namespace E_Book_Store_File_Handling_APP
{
    public class IsNullExpection : Exception
    {
        public IsNullExpection(string message) : base(message) { }
    }

    public class IsValidStringExpection : Exception
    {
        public IsValidStringExpection(string message) : base(message) { }
    }
    public class Program
    {
        public static void DisplayAllBooks(string FilePath)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine(
                $"{"Book ID",-10}{"Book Name",-28}{"Book Author",-25}{"Genre",-25}{"Stock",-10}"
            );

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            foreach (string i in File.ReadAllLines(FilePath))
            {
                string[] lines = i.Split(',');

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{lines[0],-10}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{lines[1],-28}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{lines[2],-25}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{lines[3],-25}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{lines[5],-10}");
                Console.ResetColor();

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine();
        }

        public static void DisplayParticularBook(string Bookid, string FilePath)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine(
                $"{"Book ID",-10}{"Book Name",-28}{"Book Author",-25}{"Genre",-25}{"Stock",-10}"
            );

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            foreach (string i in File.ReadAllLines(FilePath))
            {
                string[] lines = i.Split(',');
                if (lines[0] == Bookid)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{lines[0],-10}");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{lines[1],-28}");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{lines[2],-25}");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{lines[3],-25}");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{lines[5],-10}");
                    Console.ResetColor();

                    Console.WriteLine();

                    break;
                }
                else
                {
                    continue;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }

        public static void isNullString(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IsNullExpection("Name cannot be Empty");
            }
        }

        public static void isValidString(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z .]+$"))
            {
                throw new IsValidStringExpection("Name must contains alphabets only not number and special characters");
            }
        }

        //public static int BookId = 105;

        //static string bookContentFolder = "Description_File";

        public static string ContentFileDirectory = @"D:\FileHandling\E_Book_App\Description_File";

        static void Main(string[] args)
        {
            string FileDirectory = @"D:\FileHandling\E_Book_App";
            string FilePath = Path.Combine(FileDirectory, "Book_Details.txt");

            while (true)
            {
                Console.WriteLine();    
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("----------------------------------------- E - Book Store -----------------------------------------");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("                                        1. Add the Books                                          ");
                Console.WriteLine("                                        2. View All Books                                         ");
                Console.WriteLine("                                        3. View Particular Book Detials                           ");
                Console.WriteLine("                                        4. Update the Book                                        ");
                Console.WriteLine("                                        5. Delete the Book                                        ");
                Console.WriteLine("                                        6. Exit                                                   ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine();

                int Choice = 0;
                int BookId = 1;
                try
                {
                    Choice:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Enter the Choice : ");
                    Console.ResetColor();
                    int choice = int.Parse(Console.ReadLine());

                    if(choice  == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice! Choice cannot be zero. Please re-enter the choice.");
                        Console.ResetColor();
                        goto Choice;
                    }
                    if(choice > 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 7");
                        Console.ResetColor();
                        goto Choice;
                    }

                    Choice = choice;
                    Console.WriteLine();
                }
                catch(FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice! Please enter the choice using digits only—no characters, symbols, or whitespace.");
                    Console.ResetColor();
                }
                catch(OverflowException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("nvalid choice! Please enter the correct choice as shown in the header");
                    Console.ResetColor();
                }

                String BookName = "None";
                String BookAuthor = "None";
                String Genre = "None";
                String Stock = "None";
                switch (Choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                                You Enter '1' for Adding the New Books                            ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("--------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        BookName:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Book Name    : ");
                            Console.ResetColor();
                            string bookName = Console.ReadLine().ToLower();

                            isNullString(BookName);
                            isValidString(BookName);

                            BookName = bookName;    

                        }
                        catch (IsNullExpection e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();
                            goto BookName;
                        }
                        catch(IsValidStringExpection e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; 
                            Console.WriteLine(e.Message);   
                            Console.ResetColor();   
                            goto BookName;
                        }

                        BookAuthor:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Author of the Book : ");
                            Console.ResetColor();
                            String bookAuthor = Console.ReadLine().ToLower();

                            isNullString(BookAuthor);
                            isValidString(BookAuthor);

                            BookAuthor = bookAuthor;    
                        }
                        catch (IsNullExpection e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();
                            goto BookAuthor;
                        }
                        catch (IsValidStringExpection e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();
                            goto BookAuthor;
                        }

                        Genre:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Genre of Book : ");
                            Console.ResetColor();
                            String genre = Console.ReadLine().ToLower();
                            isNullString(genre);
                            isValidString(genre);

                            Genre = genre;
                        }
                        catch (IsNullExpection e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();
                            goto Genre;
                        }
                        catch (IsValidStringExpection e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();
                            goto Genre;
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"Enter the Stock of {BookName} : ");
                        Console.ResetColor();
                        Stock = Console.ReadLine();

                        var line = File.ReadLines(FilePath);

                        BookId = line.Select(l => int.Parse(l.Split(',')[0])).Max() + 1;

                        string contentFileName = $"{BookId}.txt";
                        string contentFilePath = Path.Combine(ContentFileDirectory, contentFileName);

                        if (!Directory.Exists(ContentFileDirectory))
                        {
                            Directory.CreateDirectory(ContentFileDirectory);
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("----------------------- Enter the Book Descrption -----------------------");
                        Console.ResetColor();
                        Console.WriteLine();
                        string desciption = Console.ReadLine(); 

                        File.WriteAllText(contentFilePath, desciption);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("-------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        foreach (string i in File.ReadAllLines(FilePath))
                        {
                            string[] lines = i.Split(',');

                            if (lines[1] == BookName && lines[2] == BookAuthor)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("This book already exists. Please re-enter the book name and details.");
                                Console.ResetColor();
                                Console.WriteLine();    
                                goto BookName;
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{contentFilePath} has been created with Description");
                        Console.ResetColor();
                        Console.WriteLine();
                        

                        string BookDetails = $"{BookId},{BookName},{BookAuthor},{Genre},{contentFileName},{Stock}";

                        File.AppendAllText(FilePath, BookDetails+Environment.NewLine);
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                          ---------- Registed Book Details ----------                             ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("                               Book ID          :");
                        Console.ResetColor();
                        Console.WriteLine(BookId);

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("                               Book Name        :");
                        Console.ResetColor();
                        Console.WriteLine(BookName);

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("                               Book Author      :");
                        Console.ResetColor();
                        Console.WriteLine(BookAuthor);

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("                               Genre            :");
                        Console.ResetColor();
                        Console.WriteLine(Genre);

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("                               Stock            :");
                        Console.ResetColor();
                        Console.WriteLine(Stock);
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                          -------------------------------------------                             ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("New Book has been added Successfully");
                        Console.ResetColor();
                        Console.WriteLine();

                        break;


                    case 2:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                                You Enter '2' for View the all Books                             ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("--------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                                 Here are all the book details                                    ");
                        Console.ResetColor();
                        Console.WriteLine();

                        DisplayAllBooks(FilePath);

                        break;


                    case 3:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                               You Enter '3' for View Particular Books                            ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("--------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                    ViewBook:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Book ID : ");
                        Console.ResetColor();
                        string Bookid = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"                          Here are the book details for Book ID - {Bookid}                              ");
                        Console.ResetColor();
                        Console.WriteLine();

                        DisplayParticularBook(Bookid, FilePath);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"If you want to view the description of Book ID - {Bookid} (Y/N) : ");
                        Console.ResetColor();
                        char ch = char.Parse(Console.ReadLine());
                        Console.WriteLine();
                        if (ch == 'y' || ch == 'Y')
                        {
                            foreach (string i in File.ReadAllLines(FilePath))
                            {
                                string[] lines = i.Split(',');
                                if (Bookid == lines[0])
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine($"                   -------- Here the Description of Book Id - {Bookid} ---------                 ");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    string ContentFileName = $"{lines[4]}";
                                    string ContentFilePath = Path.Combine(ContentFileDirectory, ContentFileName);

                                    if (File.Exists(ContentFilePath))
                                    {
                                        string[] content = File.ReadAllLines(ContentFilePath);
                                        foreach (string l in content)
                                        {
                                            Console.WriteLine(l);
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Description file not found: {ContentFilePath}");
                                        Console.ResetColor();
                                        goto ViewBook;
                                    }
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine($"                   -------------------------------------------------------------                 ");
                                    Console.ResetColor();
                                }
                               
                            }
                        }
                        else if (ch == 'n' || ch == 'N')
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Okay....");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Decision! Enter the proper Decision.");
                            Console.ResetColor();
                            Console.WriteLine();
                            goto ViewBook;
                        }
                            break;

                    case 4:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                               You Enter '4' for Update Particular Books                            ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("--------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                    Updating:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Book ID for Updating : ");
                        Console.ResetColor();
                        string bookId = Console.ReadLine();

                        bool Flag = false;
                        foreach (string i in File.ReadAllLines(FilePath))
                        {
                            string[] lines = i.Split(',');
                            if (lines[0] == bookId)
                            {
                                Flag = true;
                                break;
                            }
                        }

                        if (Flag)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"                          Here are the book details for Book ID - {bookId}                              ");
                            Console.ResetColor();
                            Console.WriteLine();

                            DisplayParticularBook(bookId, FilePath);
                            Console.WriteLine();

                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("                         ----------  Choose an option to update ----------                        ");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.WriteLine("                                        1. Update the Book Name                                   ");
                                Console.WriteLine("                                        2. Update the Book Author                                 ");
                                Console.WriteLine("                                        3. Update the Book Genre                                  ");
                                Console.WriteLine("                                        4. Update the Stock                                       ");
                                Console.WriteLine("                                        5. Exit                                                   ");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("                        --------------------------------------------------                        ");
                                Console.ResetColor();
                                Console.WriteLine();    
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Enter the Choice for Update :  ");
                                Console.ResetColor();

                                int choice = int.Parse(Console.ReadLine());
                                List<string> lines = new List<string>(File.ReadAllLines(FilePath));

                                for (int i = 0; i < lines.Count; i++)
                                {
                                    string[] list = lines[i].Split(',');
                                    if (list[0].Trim() == bookId)
                                    {
                                        switch (choice)
                                        {
                                            case 1:
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("Enter the Updated Book Name : ");
                                                Console.ResetColor();
                                                string updatedName = Console.ReadLine();
                                                isNullString(updatedName);
                                                isValidString(updatedName);
                                                list[1] = updatedName;

                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.WriteLine("Book name has been successfully updated");
                                                Console.ResetColor();
                                                Console.WriteLine();
                                                break;

                                            case 2:
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("Enter the Updated Book Author : ");
                                                Console.ResetColor();
                                                string updatedAuthor = Console.ReadLine();
                                                isNullString(updatedAuthor);
                                                isValidString(updatedAuthor);
                                                list[2] = updatedAuthor;

                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.WriteLine("Book Author has been successfully updated");
                                                Console.ResetColor();
                                                Console.WriteLine();
                                                break;

                                            case 3:
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("Enter the Updated Book Genre : ");
                                                Console.ResetColor();
                                                string updatedGenre = Console.ReadLine();
                                                isNullString(updatedGenre);
                                                isValidString(updatedGenre);
                                                list[3] = updatedGenre;

                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.WriteLine("Genre has been successfully updated");
                                                Console.ResetColor();
                                                Console.WriteLine();
                                                break;

                                            case 4:
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("Enter the Updated Book Stock : ");
                                                Console.ResetColor();
                                                string updatedStock = Console.ReadLine();
                                                
                                                list[4] = updatedStock;

                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.WriteLine("Book Stock has been successfully updated");
                                                Console.ResetColor();
                                                Console.WriteLine();
                                                break;

                                            case 5:
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                Console.WriteLine("Thank you!");
                                                Console.ResetColor();
                                                Console.WriteLine();
                                                break;

                                            default:
                                                Console.WriteLine("Invalid Choice!");
                                                break;
                                        }

                                        if(choice == 5)
                                        {
                                            break;
                                        }

                                        lines[i] = string.Join(",", list);
                                        File.WriteAllLines(FilePath, lines); 
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Book Not Found :( , Re-Enter the Book ID");
                            Console.ResetColor();
                            Console.WriteLine();
                            goto Updating;
                        }

                        break;

                    case 5:

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                               You Enter '5' for Delete Particular Books                            ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("--------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                    DeleteBook:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Book ID to delete: ");
                        Console.ResetColor();
                        string bookid = Console.ReadLine();

                        var books = File.ReadAllLines(FilePath).ToList();
                        bool bookFound = books.Any(x => x.Split(',')[0] == bookid);

                        if (bookFound)
                        {
                            var updatedDetails = books.Where(x => x.Split(',')[0] != bookid).ToList();

                            string deletedFilePath = Path.Combine(ContentFileDirectory, bookid + ".txt");
                            if (File.Exists(deletedFilePath))
                            {
                                File.Delete(deletedFilePath);
                            }

                            File.WriteAllLines(FilePath, updatedDetails);

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Book ID - {bookid} was deleted successfully 🙂");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Book ID not found. Please re-enter the Book ID.");
                            Console.ResetColor();
                            Console.WriteLine();
                            goto DeleteBook;
                        }

                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("                     You Choose to Exist :)                  ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();

                        for (int i = 5; i > 0; i--)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("                 Existing : ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($" {i} ");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                        }
                        break;
                }
                if (Choice == 6)
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("                      ~ * Thank You * ~                    ");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }
            }


            

        }
    }
}