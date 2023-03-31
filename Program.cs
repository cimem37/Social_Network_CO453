using System;
using System.Collections.Generic;

class SocialContent {
    public string Author { get; set; }
    public DateTime PostedOn { get; set; }

    public virtual void DisplayContent() {
        Console.WriteLine($"Author: {Author}\nPosted On: {PostedOn}");
    }
}

class Message : SocialContent {
    public string Text { get; set; }

    public override void DisplayContent() {
        base.DisplayContent();
        Console.WriteLine($"Text: {Text}");
    }
}

class Photo : SocialContent {
    public string Caption { get; set; }
    public string ImageUrl { get; set; }

    public override void DisplayContent() {
        base.DisplayContent();
        Console.WriteLine($"Caption: {Caption}\nImage URL: {ImageUrl}");
    }
}

class Program {
    static List<SocialContent> contentList = new List<SocialContent>();

    static void Main(string[] args) {
        Console.WriteLine("- - - - - - - - - - - - - - - - -");
        Console.WriteLine(" Bruno's - Social_Network_CO453 -");
        Console.WriteLine("- - - - - - - - - - - - - - - - -");

        while (true) {
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1. Add a message");
            Console.WriteLine("2. Add a photo");
            Console.WriteLine("3. Display all");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }
            switch (choice) {
                case 1:
                    Console.WriteLine("Adding a message");
                    AddMessage();
                    break;
                case 2:
                    Console.WriteLine("Adding a photo");
                    AddPhoto();
                    break;
                case 3:
                    Console.WriteLine("Displaying all content");
                    DisplayAllContent();
                    break;
                case 4:
                    Console.WriteLine("Exiting");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("[ERROR] Please enter a valid input from the display");
                    break;
            }
        }
    }

    static void AddMessage() {
        Console.Write("Author: ");
        string author = Console.ReadLine();
        Console.Write("Text: ");
        string text = Console.ReadLine();
        Message message = new Message {
            Author = author,
            Text = text,
            PostedOn = DateTime.Now
        };
        contentList.Add(message);
    }

    static void AddPhoto() {
        Console.Write("Author: ");
        string author = Console.ReadLine();
        Console.Write("Caption: ");
        string caption = Console.ReadLine();
        Console.Write("Image URL: ");
        string imageUrl = Console.ReadLine();
        Photo photo = new Photo {
            Author = author,
            Caption = caption,
            ImageUrl = imageUrl,
            PostedOn = DateTime.Now
        };
        contentList.Add(photo);
    }

    static void DisplayAllContent() {
        foreach (SocialContent content in contentList) {
            Console.WriteLine("- - - - - - - - - - - - - - - - -");
            content.DisplayContent();
        }
    }
}
