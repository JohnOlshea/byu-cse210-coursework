using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Building a Budget App in Java Spring Boot", "John Akala", 742);
        video1.AddComment(new Comment("Amaka O.", "This helped me understand Spring Security so much better!"));
        video1.AddComment(new Comment("Tunde B.", "Great pacing, subscribed for more backend content."));
        video1.AddComment(new Comment("Priya S.", "Could you do a follow-up on JWT refresh tokens?"));
        video1.AddComment(new Comment("Chen W.", "The whiteboard explanation at 6:30 was clutch."));
        videos.Add(video1);

        Video video2 = new Video("Rhino MatrixGold: Modeling a Solitaire Ring", "GemCraft Studio", 915);
        video2.AddComment(new Comment("Blessing A.", "Never knew CAD jewelry design was this precise."));
        video2.AddComment(new Comment("Marcus T.", "What prong height do you usually start with?"));
        video2.AddComment(new Comment("Ifeoma K.", "The render at the end looks incredible."));
        videos.Add(video2);

        Video video3 = new Video("Structured Finance 101: CDOs Explained", "WQU Faculty", 1180);
        video3.AddComment(new Comment("Daniel R.", "Finally a clear explanation of tranching."));
        video3.AddComment(new Comment("Grace N.", "This ties in well with the MScFE coursework."));
        video3.AddComment(new Comment("Samuel O.", "Could you cover synthetic CDOs next?"));
        video3.AddComment(new Comment("Lea F.", "Watched this twice, very dense but clear."));
        videos.Add(video3);

        Video video4 = new Video("Family History Research: Getting Started", "FamilySearch Volunteers", 530);
        video4.AddComment(new Comment("Ruth P.", "This is exactly what I needed for my first pedigree chart."));
        video4.AddComment(new Comment("Emeka C.", "The tip about census records was gold."));
        video4.AddComment(new Comment("Nkechi I.", "Volunteering to help others with this sounds rewarding."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}