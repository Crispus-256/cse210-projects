using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Code", "John Doe", 300);
        Video video2 = new Video("Cooking Pasta", "Jane Smith", 600);

        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thank you!"));

        video2.AddComment(new Comment("Charlie", "I love this recipe!"));
        video2.AddComment(new Comment("Diana", "Could you add more details?"));

        List<Video> videos = new List<Video> { video1, video2 };

        foreach (var video in videos)
        {
            Console.WriteLine(video.GetDetails());
            Console.WriteLine();
        }
    }
}